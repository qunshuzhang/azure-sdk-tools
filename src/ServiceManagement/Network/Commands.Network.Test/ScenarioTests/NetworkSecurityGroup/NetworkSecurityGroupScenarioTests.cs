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

using System.Net;
using Microsoft.WindowsAzure.Management.Network;

namespace Microsoft.Azure.Commands.Network.Test.ScenarioTests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Testing;
    using Xunit;
    using Microsoft.WindowsAzure.Management;

    public class NetworkSecurityGroupScenarioTests
    {
        public NetworkSecurityGroupScenarioTests()
        {
            this.RunPowerShellTest("Initialize-NetworkSecurityGroupTest");
        }

        private readonly EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAndRemoveNetworkSecurityGroup()
        {
            this.RunPowerShellTest("Test-CreateAndRemoveNetworkSecurityGroup");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNetworkSecurityGroupWithNonExistingName()
        {
            this.RunPowerShellTest("Test-RemoveNetworkSecurityGroupWithNonExistingName");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetMultipleNetworkSecurityGroups()
        {
            this.RunPowerShellTest("Test-GetMultipleNetworkSecurityGroups");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNetworkSecurityRule()
        {
            this.RunPowerShellTest("Test-SetNetworkSecurityRule");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNetworkSecurityRuleWithInvalidParameter()
        {
            this.RunPowerShellTest("Test-SetNetworkSecurityRuleWithInvalidParameter");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNetworkSecurityRule()
        {
            this.RunPowerShellTest("Test-RemoveNetworkSecurityRule");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAndGetNetworkSecurityGroupForSubnet()
        {
            this.RunPowerShellTest("Test-SetAndGetNetworkSecurityGroupForSubnet");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveNetworkSecurityGroupFromSubnet()
        {
            this.RunPowerShellTest("Test-RemoveNetworkSecurityGroupFromSubnet");
        }

        #region Test setup
        protected void SetupManagementClients()
        {
            var client = TestBase.GetServiceClient<NetworkManagementClient>(new RDFETestEnvironmentFactory());
            var client2 = TestBase.GetServiceClient<ManagementClient>(new RDFETestEnvironmentFactory());
            helper.SetupSomeOfManagementClients(client, client2);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                List<string> modules = Directory.GetFiles("ScenarioTests\\NetworkSecurityGroup", "*.ps1").ToList();
                modules.Add("Common.ps1"); 
                
                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());

                helper.RunPowerShellTest(scripts);
            }
        }
        #endregion
    }
}
