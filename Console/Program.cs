using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using System;

namespace Dynamics365ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "AuthType=ClientSecret;ClientId=;ClientSecret=;Url=https://duitmanaged.crm8.dynamics.com";
            CrmServiceClient conn = new CrmServiceClient(connectionString);

            if (conn.IsReady)
            {
                IOrganizationService service = (IOrganizationService)conn.OrganizationWebProxyClient ?? (IOrganizationService)conn.OrganizationServiceProxy;

                Guid userId = ((WhoAmIResponse)service.Execute(new WhoAmIRequest())).UserId;
                Console.WriteLine("Connected to Dynamics 365 CRM Online. User ID: " + userId);

                ExecuteMultipleRequest executeMultipleRequest = new ExecuteMultipleRequest()
                {
                    Settings = new ExecuteMultipleSettings()
                    {
                        ContinueOnError = true,
                        ReturnResponses = true
                    },
                    Requests = new OrganizationRequestCollection()
                };
                CreateRequest createRequest1 = new CreateRequest()
                {
                    Target = new Entity("contact")
                    {
                        ["firstname"] = "Test Contact from Console"
                    }
                };
                CreateRequest createRequest2 = new CreateRequest()
                {
                    Target = new Entity("contact")
                    {
                        ["firstname"] = "Test Contact from Console"
                    }
                };
                UpdateRequest updateRequest1 = new UpdateRequest()
                {
                    Target = new Entity("contact", new Guid("a8e15723-2623-4d3a-8428-0f0b8c2b5f6c"))
                    {
                        ["description"] = DateTime.Now.ToString()
                    }
                };
                executeMultipleRequest.Requests.Add(createRequest1);
                executeMultipleRequest.Requests.Add(createRequest2);
                executeMultipleRequest.Requests.Add(updateRequest1);
                ExecuteMultipleResponse executeMultipleResponse = (ExecuteMultipleResponse)service.Execute(executeMultipleRequest);
            }
            else
            {
                Console.WriteLine("Failed to connect to Dynamics 365 CRM Online.");
                Console.WriteLine(conn.LastCrmError);
            }
        }
    }
}