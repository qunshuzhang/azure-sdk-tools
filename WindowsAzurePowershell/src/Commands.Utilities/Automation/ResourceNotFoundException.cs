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

namespace Microsoft.WindowsAzure.Commands.Utilities.Automation
{
    using System;

    [Serializable]
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(Type resourceType, string message) : base(message)
        {
            this.ResourceType = resourceType;
        }

        [NonSerialized]
        private Type resourceType;

        public Type ResourceType
        {
            get
            {
                return this.resourceType;
            }

            private set
            {
                this.resourceType = value;
            }
        }
    }
}
