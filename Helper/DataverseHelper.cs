using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Extensions;
using Microsoft.Xrm.Sdk.PluginTelemetry;
using System;
using System.Runtime.CompilerServices;
using System.ServiceModel;

namespace DataverseExperiments.Helper
{
    public static class DataverseHelper
    {
        public static void RemoveFieldValue(Entity entity, string fieldName)
        {
            entity[fieldName] = null;
        }
    }
}