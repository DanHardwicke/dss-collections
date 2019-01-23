using DFC.Functions.DI.Standard.Attributes;
using DFC.Swagger.Standard;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace NCS.DSS.Collections.APIDefinition
{
    public static class ApiDefinition
    {
        public const string APITitle = "Collections";
        public const string APIDefinitionName = "API-Definition";
        public const string APIDefRoute = APITitle + "/" + APIDefinitionName;
        public const string APIDescription = "Basic details of a National Careers Service " + APITitle + " Resource";

        [FunctionName(APIDefinitionName)]
        public static HttpResponseMessage RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = APIDefRoute)] HttpRequest req,
            ILogger log,
            [Inject]ISwaggerDocumentGenerator swaggerGenerator)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(swaggerGenerator.GenerateSwaggerDocument(req, APITitle, APIDescription, APIDefinitionName, Assembly.GetExecutingAssembly()))
            };           
        }        
    }
}
