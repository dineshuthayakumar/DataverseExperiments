using Microsoft.Xrm.Sdk;
using System;
using DataverseExperiments.Plugins.Helper;

namespace DataverseExperiments.Plugins
{
    /// <summary>
    /// A plugin that restricts the update of description field on the contact table.
    /// This plugin is registered on the Pre-Operation stage of the Create and Update event pipeline for the contact table.
    /// </summary>
    public class PluginTracer : PluginBase
    {
        public PluginTracer(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(PluginTracer))
        {
        }

        protected override void ExecuteDataversePlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }
            IPluginExecutionContext context = localPluginContext.PluginExecutionContext;

            localPluginContext.Trace($"Message Name: {context.MessageName}");
            localPluginContext.Trace($"Stage: {context.Stage}");
            localPluginContext.Trace($"Mode: {context.Mode}"); 
            localPluginContext.Trace($"Primary Entity Name: {context.PrimaryEntityName}");
            localPluginContext.Trace($"Secondary Entity Name: {context.SecondaryEntityName}");
            localPluginContext.Trace($"Primary Entity Id: {context.PrimaryEntityId}");
            localPluginContext.Trace($"Initiating User Id: {context.InitiatingUserId}");
            localPluginContext.Trace($"Correlation Id: {context.CorrelationId}");
            localPluginContext.Trace($"Operation Id: {context.OperationId}");
        }
    }
}