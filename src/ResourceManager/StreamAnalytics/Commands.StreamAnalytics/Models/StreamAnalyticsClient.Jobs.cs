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
using Microsoft.Azure.Commands.StreamAnalytics.Models;
using Microsoft.Azure.Commands.StreamAnalytics.Properties;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    public partial class StreamAnalyticsClient
    {
        public virtual PSJob GetJob(string resourceGroupName, string jobName, string propertiesToExpand)
        {
            JobGetParameters parameters = new JobGetParameters(propertiesToExpand);
            var response = StreamAnalyticsManagementClient.Job.Get(
                resourceGroupName, jobName, parameters);

            return new PSJob(response.Job)
            {
                ResourceGroupName = resourceGroupName,
                JobName = jobName
            };
        }

        public virtual List<PSJob> ListJobs(string resourceGroupName, string propertiesToExpand)
        {
            List<PSJob> jobs = new List<PSJob>();
            JobListParameters parameters = new JobListParameters(propertiesToExpand);
            var response = StreamAnalyticsManagementClient.Job.ListJobsInResourceGroupAsync(resourceGroupName, parameters);

            if (response != null && response.Result.Value != null)
            {
                foreach (var job in response.Result.Value)
                {
                    jobs.Add(new PSJob(job)
                        {
                            ResourceGroupName = resourceGroupName
                        });
                }
            }

            return jobs;
        }

        public virtual List<PSJob> ListJobs(string propertiesToExpand)
        {
            List<PSJob> jobs = new List<PSJob>();
            JobListParameters parameters = new JobListParameters(propertiesToExpand);
            var response = StreamAnalyticsManagementClient.Job.ListJobsInSubscriptionAsync(parameters);

            if (response != null && response.Result.Value != null)
            {
                foreach (var job in response.Result.Value)
                {
                    jobs.Add(new PSJob(job));
                }
            }

            return jobs;
        }

        public virtual List<PSJob> FilterPSJobs(JobFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }

            if (string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                throw new ArgumentException(Resources.ResourceGroupNameCannotBeEmpty);
            }

            List<PSJob> jobs = new List<PSJob>();

            if (!string.IsNullOrWhiteSpace(filterOptions.JobName))
            {
                jobs.Add(GetJob(filterOptions.ResourceGroupName, filterOptions.JobName,
                    filterOptions.PropertiesToExpand));
            }
            else if (!string.IsNullOrWhiteSpace(filterOptions.ResourceGroupName))
            {
                jobs.AddRange(ListJobs(filterOptions.ResourceGroupName, filterOptions.PropertiesToExpand));
            }
            else
            {
                jobs.AddRange(ListJobs(filterOptions.PropertiesToExpand));
            }

            return jobs;
        }
    }
}