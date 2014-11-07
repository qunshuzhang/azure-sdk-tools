// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Management.StreamAnalytics.Models;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public class PSJob
    {
        private JobRequest jobRequest;

        public PSJob()
        {
            jobRequest = new JobRequest();
        }

        public PSJob(JobRequest jobRequest)
        {
            if (jobRequest == null)
            {
                throw new ArgumentNullException("jobRequest");
            }

            this.jobRequest = jobRequest;
        }

        public string JobName { get; set; }

        public string ResourceGroupName { get; set; }

        public string Location
        {
            get
            {
                return jobRequest.Location;
            }
            set
            {
                jobRequest.Location = value;
            }
        }

        public IDictionary<string, string> Tags
        {
            get
            {
                return jobRequest.Tags;
            }
            set
            {
                jobRequest.Tags = value;
            }
        }

        public JobRequestProperties Properties
        {
            get
            {
                return jobRequest.Properties;
            }
            set
            {
                jobRequest.Properties = value;
            }
        }
    }
}
