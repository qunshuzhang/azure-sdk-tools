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

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.FunctionalTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Utilities.Properties;

    [TestClass]
    public class SuspendWAPackVMTests : CmdletTestVirtualMachineStatusBase
    {
        [TestCleanup]
        public void Cleanup()
        {
            var vm = VirtualMachine;
            if(vm.Properties["StatusString"].Value.ToString() == "Paused")
                this.SetVirtualMachineState(vm, "Resume");
        }

        [TestMethod]
        [TestCategory("WAPackIaaS")]
        public void ShouldSuspendExistingVm()
        {
            var vm = VirtualMachine;
            var startedVm = this.SetVirtualMachineState(vm, "Start");
            Assert.AreEqual("Running", startedVm.Properties["StatusString"].Value);
            var suspendedVm = this.SetVirtualMachineState(startedVm, "Suspend");
            Assert.AreEqual("Paused", suspendedVm.Properties["StatusString"].Value);
        }

        [TestMethod]
        [TestCategory("WAPackIaaS")]
        [TestCategory("Negative")]
        public void SuspendVmThatNoLongerExistsFails()
        {
            var vm = VirtualMachine;
            var vmId = vm.Properties["ID"].Value;
            this.SetVirtualMachineState(vm, "Stop");
            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Remove-WAPackVM").AddParameter("VM", VirtualMachine).AddParameter("Force");
            PowerShell.InvokeAndAssertForNoErrors();

            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Suspend-WAPackVM").AddParameter("VM", vm);
            PowerShell.InvokeAndAssertForErrors(string.Format(Resources.OperationFailedErrorMessage, Resources.Suspend,
                vmId));
        }

        [TestMethod]
        [TestCategory("WAPackIaaS")]
        public void ShouldBeAbleToGetAndSuspendAVmUsingPipeline()
        {
            var vm = VirtualMachine;
            var startedVm = this.SetVirtualMachineState(vm, "Start");
            Assert.AreEqual("Running", startedVm.Properties["StatusString"].Value);

            PowerShell.Commands.Clear();
            PowerShell.AddCommand("Get-WAPackVM")
                .AddParameter("Id", startedVm.Properties["Id"].Value)
                .AddCommand("Suspend-WAPackVM");

            var stoppedVm = PowerShell.InvokeAndAssertForNoErrors();
            Assert.AreEqual("Paused", stoppedVm[0].Properties["StatusString"].Value);
        }
    }
}
