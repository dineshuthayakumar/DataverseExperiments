using Microsoft.Xrm.Sdk;
using System;
using DataverseExperiments.Plugins.Helper;

namespace DataverseExperiments.Plugins
{
    /// <summary>
    /// A plugin that restricts the update of description field on the contact table.
    /// This plugin is registered on the Pre-Operation stage of the Create and Update event pipeline for the contact table.
    /// </summary>
    public class RestrictFieldUpdate : PluginBase
    {
        public RestrictFieldUpdate(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(RestrictFieldUpdate))
        {
        }

        // Entry point for the plugin. The logic to remove the description field is implemented here.
        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            if (context.InputParameters.Contains(Constants.TARGET) && context.InputParameters[Constants.TARGET] is Entity)
            {
               var entity = (Entity)context.InputParameters[Constants.TARGET];

               if (entity.LogicalName.Equals(Constants.CONTACT, StringComparison.OrdinalIgnoreCase) && entity.Attributes.Contains(Constants.DESCRIPTION))
               {
                    localPluginContext.Trace($"Message Name: {context.MessageName}");
                    DataverseHelper.RemoveFieldValue(entity, Constants.DESCRIPTION);
                    localPluginContext.Logger.LogInformation("Exiting RestrictFieldUpdate plugin.");
               }
            }
        }
    }
}
