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
using Microsoft.Azure.Management.StreamAnalytics.Models;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public class PSJob
    {
        private Job job;

        public PSJob()
        {
            job = new Job();
        }

        public PSJob(Job job)
        {
            if (job == null)
            {
                throw new ArgumentNullException("job");
            }

            this.job = job;
        }

        public string JobName { get; set; }

        public string ResourceGroupName { get; set; }

        public string Location
        {
            get
            {
                return job.Location;
            }
            set
            {
                job.Location = value;
            }
        }

        public IDictionary<string, string> Tags
        {
            get
            {
                return job.Tags;
            }
            set
            {
                job.Tags = value;
            }
        }

        public JobProperties Properties
        {
            get
            {
                return job.Properties;
            }
            set
            {
                job.Properties = value;
            }
        }
    }
}
