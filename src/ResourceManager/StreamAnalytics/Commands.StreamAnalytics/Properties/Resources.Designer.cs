﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StreamAnalytics.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Azure.Commands.StreamAnalytics.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} name provided using -Name switch: &apos;{1}&apos; in cmdlet doesn&apos;t match with {0} name: &apos;{2}&apos; in JSON file. {0} will be created with name: &apos;{1}&apos;.
        /// </summary>
        internal static string ExtractedNameFromJsonMismatchWarning {
            get {
                return ResourceManager.GetString("ExtractedNameFromJsonMismatchWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to HTTP Status Code: {0}
        ///Error Code: {1}
        ///Error Message: {2}
        ///Request Id: {3}
        ///Timestamp (Utc):{4}.
        /// </summary>
        internal static string FormattedCloudExceptionMessageTemplate {
            get {
                return ResourceManager.GetString("FormattedCloudExceptionMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating input &apos;{0}&apos; in stream analytics job {1} in resource group &apos;{2}&apos;..
        /// </summary>
        internal static string InputCreating {
            get {
                return ResourceManager.GetString("InputCreating", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An input with the name {0} in the stream analytics job {1} in the resource group {2} already exists. 
        ///Continuing execution may overwrite the exisiting one. 
        ///Are you sure you want to continue?.
        /// </summary>
        internal static string InputExists {
            get {
                return ResourceManager.GetString("InputExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input &apos;{0}&apos; does not exist in the stream analytics job {1} in the resource group &apos;{2}&apos;..
        /// </summary>
        internal static string InputNotFound {
            get {
                return ResourceManager.GetString("InputNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to parse input JSON file. {0}. Please correct the error in the JSON file and re-deploy {1} again..
        /// </summary>
        internal static string InvalidJson {
            get {
                return ResourceManager.GetString("InvalidJson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating job &apos;{0}&apos; in resource group &apos;{1}&apos;..
        /// </summary>
        internal static string JobCreating {
            get {
                return ResourceManager.GetString("JobCreating", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A job with the name {0} in the resource group {1} already exists. 
        ///Continuing execution may overwrite the exisiting one. 
        ///Are you sure you want to continue?.
        /// </summary>
        internal static string JobExists {
            get {
                return ResourceManager.GetString("JobExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stream analytics job name cannot be null..
        /// </summary>
        internal static string JobNameCannotBeEmpty {
            get {
                return ResourceManager.GetString("JobNameCannotBeEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Job &apos;{0}&apos; does not exist in the resource group &apos;{1}&apos;..
        /// </summary>
        internal static string JobNotFound {
            get {
                return ResourceManager.GetString("JobNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating output &apos;{0}&apos; in stream analytics job {1} in resource group &apos;{2}&apos;..
        /// </summary>
        internal static string OutputCreating {
            get {
                return ResourceManager.GetString("OutputCreating", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An output with the name {0} in the stream analytics job {1} in the resource group {2} already exists. 
        ///Continuing execution may overwrite the exisiting one. 
        ///Are you sure you want to continue?.
        /// </summary>
        internal static string OutputExists {
            get {
                return ResourceManager.GetString("OutputExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Output &apos;{0}&apos; does not exist in the stream analytics job {1} in the resource group &apos;{2}&apos;..
        /// </summary>
        internal static string OutputNotFound {
            get {
                return ResourceManager.GetString("OutputNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Resource group name cannot be null..
        /// </summary>
        internal static string ResourceGroupNameCannotBeEmpty {
            get {
                return ResourceManager.GetString("ResourceGroupNameCannotBeEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating transformation &apos;{0}&apos; in stream analytics job {1} in resource group &apos;{2}&apos;..
        /// </summary>
        internal static string TransformationCreating {
            get {
                return ResourceManager.GetString("TransformationCreating", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An transformation with the name {0} in the stream analytics job {1} in the resource group {2} already exists. 
        ///Continuing execution may overwrite the exisiting one. 
        ///Are you sure you want to continue?.
        /// </summary>
        internal static string TransformationExists {
            get {
                return ResourceManager.GetString("TransformationExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transformation &apos;{0}&apos; does not exist in the stream analytics job {1} in the resource group &apos;{2}&apos;..
        /// </summary>
        internal static string TransformationNotFound {
            get {
                return ResourceManager.GetString("TransformationNotFound", resourceCulture);
            }
        }
    }
}
