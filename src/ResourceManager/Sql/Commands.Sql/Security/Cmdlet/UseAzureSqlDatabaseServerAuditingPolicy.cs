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

using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Commands.Sql.Properties;
using Microsoft.Azure.Commands.Sql.Security.Model;
using Microsoft.Azure.Commands.Sql.Security.Services;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet
{
    /// <summary>
    /// Marks the given database as using its server's default policy instead of its own policy.
    /// </summary>
    [Cmdlet(VerbsOther.Use, "AzureSqlDatabaseServerAuditingPolicy"), OutputType(typeof(AuditingPolicy))]
    public class UseAzureSqlDatabaseServerAuditingPolicy : SqlDatabaseSecurityCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "SQL Database name.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Provides the auditing policy that this cmdlet operates on
        /// </summary>
        /// <returns>An auditingPolicy object</returns>
        protected override AuditingPolicy GetPolicy()
        {
            return this.PolicyHandler.GetDatabaseAuditingPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.clientRequestId);
        }

        protected override void UpdatePolicy(AuditingPolicy policy)
        { 
            policy.UseServerDefault = true;
            policy.IsEnabled = true;
            policy.StorageAccountName = GetStorageAccountName();
        }
        protected override void SendPolicy(AuditingPolicy policy)
        {
            this.PolicyHandler.SetDatabaseAuditingPolicy(policy, clientRequestId);
        }

        protected string GetStorageAccountName()
        {
            string storageAccountName = this.PolicyHandler.GetServerStorageAccount(this.ResourceGroupName, this.ServerName, this.clientRequestId);
            if (string.IsNullOrEmpty(storageAccountName))
                throw new Exception(string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.UseServerWithoutStorageAccount));
            return storageAccountName;
        }

        protected override bool writeResult() { return PassThru; }
    }
}
