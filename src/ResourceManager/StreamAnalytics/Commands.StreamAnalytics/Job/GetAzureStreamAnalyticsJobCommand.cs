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

using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.StreamAnalytics.Models;

namespace Microsoft.Azure.Commands.StreamAnalytics
{
    [Cmdlet(VerbsCommon.Get, Constants.StreamAnalytics), OutputType(typeof(List<PSJob>), typeof(PSJob))]
    public class GetAzureStreamAnalyticsJobCommand : StreamAnalyticsBaseCmdlet
    {
        [Parameter(ParameterSetName = ByStreamAnalyticsName, Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The azure resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ByStreamAnalyticsName, Position = 1, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The azure stream analytics job name.")]
        [ValidateNotNullOrEmpty]
        public string JobName { get; set; }

        [Parameter(ParameterSetName = ByStreamAnalyticsName, Position = 2, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The properties of the azure stream analytics job that need to be expanded.")]
        [ValidateNotNullOrEmpty]
        public string PropertiesToExpand { get; set; }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName != null && string.IsNullOrWhiteSpace(ResourceGroupName))
            {
                throw new PSArgumentNullException("ResourceGroupName");
            }

            if (JobName != null && string.IsNullOrWhiteSpace(JobName))
            {
                throw new PSArgumentNullException("JobName");
            }

            if (PropertiesToExpand != null && string.IsNullOrWhiteSpace(PropertiesToExpand))
            {
                throw new PSArgumentNullException("PropertiesToExpand");
            }

            JobFilterOptions filterOptions = new JobFilterOptions()
            {
                JobName = JobName,
                ResourceGroupName = ResourceGroupName,
                PropertiesToExpand = PropertiesToExpand
            };

            List<PSJob> jobs = StreamAnalyticsClient.FilterPSDataFactories(filterOptions);

            if (jobs != null)
            {
                if (jobs.Count == 1 && Name != null)
                {
                    WriteObject(jobs[0]);
                }
                else
                {
                    WriteObject(jobs, true);
                }
            }
        }
    }
}