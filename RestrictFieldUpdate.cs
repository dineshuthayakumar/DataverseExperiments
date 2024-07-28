using Microsoft.Xrm.Sdk;
using System;
using DataverseExperiments.Helper; // Why am I getting this error?

namespace DataverseExperiments
{
    /// <summary>
    /// A plugin that restricts the update of description field on the contact table.
    /// </summary>
    public class RestrictFieldUpdate : PluginBase
    {
        public RestrictFieldUpdate(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(RestrictFieldUpdate))
        {
        }

        // Entry point for custom business logic execution
        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
               var entity = (Entity)context.InputParameters["Target"];

               if (entity.LogicalName.Equals("contact", StringComparison.OrdinalIgnoreCase) && entity.Attributes.Contains("description"))
               {
                    DataverseHelper.RemoveFieldValue(entity, "description");
                    
                    localPluginContext.Logger.LogInformation("Test Log Information");
                    localPluginContext.Trace($"Message Name: {context.MessageName}");
               }
            }
        }
    }
}
