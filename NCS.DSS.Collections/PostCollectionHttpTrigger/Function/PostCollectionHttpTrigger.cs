using DFC.Functions.DI.Standard.Attributes;
using DFC.HTTP.Standard;
using DFC.JSON.Standard;
using DFC.Swagger.Standard.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using NCS.DSS.Collections.Models;
using NCS.DSS.Collections.PostCollectionHttpTrigger.Service;
using NCS.DSS.Collections.Validators;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.PostCollectionHttpTrigger.Function
{
    public static class PostCollectionHttpTrigger
    {
        [FunctionName("Post")]
        [Response(HttpStatusCode = (int)HttpStatusCode.Created, Description = "Collection Created", ShowSchema = true)]
        [Response(HttpStatusCode = (int)HttpStatusCode.NoContent, Description = "Collection does not exist", ShowSchema = false)]
        [Response(HttpStatusCode = (int)HttpStatusCode.BadRequest, Description = "Request was malformed", ShowSchema = false)]
        [Response(HttpStatusCode = (int)HttpStatusCode.Unauthorized, Description = "API key is unknown or invalid", ShowSchema = false)]
        [Response(HttpStatusCode = (int)HttpStatusCode.Forbidden, Description = "Insufficient access", ShowSchema = false)]
        [Response(HttpStatusCode = 422, Description = "Collection validation error(s)", ShowSchema = false)]
        [Display(Name = "Post", Description = "Ability to create a new collection for a touchpoint.")]
        public static async Task<HttpResponseMessage> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "collections")] HttpRequest req,
            ILogger log,
            [Inject]IPostCollectionHttpTriggerService service,
            [Inject]IHttpRequestHelper requestHelper,
            [Inject]IHttpResponseMessageHelper responseMessageHelper,
            [Inject]IJsonHelper jsonHelper,
            [Inject]IDssCorrelationValidator dssCorrelationValidator,
            [Inject]IDssTouchpointValidator dssTouchpointValidator)
        {
            log.LogInformation("Post Collection C# HTTP trigger function processing a request. Touchpoint " + requestHelper.GetDssTouchpointId(req));

            var correlationId = dssCorrelationValidator.Extract(req, log);

            var touchpointId = dssTouchpointValidator.Extract(req, log);

            if (string.IsNullOrEmpty(touchpointId))
            {
                return responseMessageHelper.BadRequest();
            }

            Collection collection;

            try
            {
                collection = await requestHelper.GetResourceFromRequest<Collection>(req);
            }
            catch (JsonException ex)
            {
                return responseMessageHelper.UnprocessableEntity(ex);
            }            

            var result = await service.ProcessRequestAsync(collection);

            if (result == null)
            {
                return responseMessageHelper.BadRequest();
            }

            return responseMessageHelper.Created(jsonHelper.SerializeObjectAndRenameIdProperty(result, "id", "CollectionId"));                         
        }
    }
}