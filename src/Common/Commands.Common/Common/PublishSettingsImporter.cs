﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common.XmlSchema;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    /// <summary>
    /// Class that handles loading publishsettings files
    /// and turning them into AzureSubscription objects.
    /// </summary>
    public static class PublishSettingsImporter
    {
        public static IEnumerable<AzureSubscription> ImportAzureSubscription(Stream stream, string environment)
        {
            var publishData = DeserializePublishData(stream);
            PublishDataPublishProfile profile = publishData.Items.Single();
            stream.Close();
            return profile.Subscription.Select(s => PublishSubscriptionToAzureSubscription(profile, s, environment));
        }

        private static PublishData DeserializePublishData(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(PublishData));
            return (PublishData)serializer.Deserialize(stream);
        }

        private static AzureSubscription PublishSubscriptionToAzureSubscription(
            PublishDataPublishProfile profile,
            PublishDataPublishProfileSubscription s,
            string environment)
        {
            var certificate = GetCertificate(profile, s);
            
            return new AzureSubscription
            {
                Id = new Guid(s.Id),
                Name = s.Name,
                Environment = environment,
                Account = certificate.Thumbprint
            };
        }

        private static X509Certificate2 GetCertificate(PublishDataPublishProfile profile,
            PublishDataPublishProfileSubscription s)
        {
            string certificateString;
            if (!string.IsNullOrEmpty(s.ManagementCertificate))
            {
                certificateString = s.ManagementCertificate;
            }
            else
            {
                certificateString = profile.ManagementCertificate;
            }

            X509Certificate2 certificate = new X509Certificate2(Convert.FromBase64String(certificateString), string.Empty);
            ProfileClient.DataStore.AddCertificate(certificate);
            
            return certificate;
        }

        private static Uri GetManagementUri(PublishDataPublishProfile profile, PublishDataPublishProfileSubscription s)
        {
            if (!string.IsNullOrEmpty(s.ServiceManagementUrl))
            {
                return new Uri(s.ServiceManagementUrl);
            }
            else if (!string.IsNullOrEmpty(profile.Url))
            {
                return new Uri(profile.Url);
            }
            return null;
        }
    }
}
