using DFC.Common.Standard.Logging;
using DFC.Functions.DI.Standard;
using DFC.HTTP.Standard;
using DFC.JSON.Standard;
using DFC.Swagger.Standard;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NCS.DSS.Collections.Cosmos.Provider;
using NCS.DSS.Collections.GetCollectionByIdHttpTrigger.Service;
using NCS.DSS.Collections.GetCollectionsHttpTrigger.Service;
using NCS.DSS.Collections.IoC;
using NCS.DSS.Collections.PostCollectionHttpTrigger.Service;
using NCS.DSS.Collections.Validators;

[assembly: WebJobsStartup(typeof(DIConfig))]

namespace NCS.DSS.Collections.IoC
{
    public class DIConfig : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddDependencyInjection();

            ConfigureServices(builder);
            ConfigureHelpers(builder);
            ConfigureValidators(builder);            
            ConfigureLogging(builder);
            ConfigureSwaggerGeneration(builder);
            ConfigureDataStorage(builder);
        }

        private void ConfigureServices(IWebJobsBuilder builder)
        {
            builder.Services.AddScoped<IPostCollectionHttpTriggerService, PostCollectionHttpTriggerService>();
            builder.Services.AddScoped<IGetCollectionByIdHtppTriggerService, GetCollectionByIdHtppTriggerService>();
            builder.Services.AddScoped<IGetCollectionsHttpTriggerService, GetCollectionsHttpTriggerService>();
        }

        private void ConfigureHelpers(IWebJobsBuilder builder)
        {
            builder.Services.AddScoped<IHttpRequestHelper, HttpRequestHelper>();            
            builder.Services.AddScoped<IHttpResponseMessageHelper, HttpResponseMessageHelper>();
            builder.Services.AddScoped<IJsonHelper, JsonHelper>();
        }

        private void ConfigureValidators(IWebJobsBuilder builder)
        {            
            builder.Services.AddScoped<ICollectionValidator, CollectionValidator>();
            builder.Services.AddScoped<IDssCorrelationValidator, DssCorrelationValidator>();
            builder.Services.AddScoped<IDssTouchpointValidator, DssTouchpointValidator>();
        }        

        private void ConfigureLogging(IWebJobsBuilder builder)
        {
            builder.Services.AddScoped<ILoggerHelper, LoggerHelper>();
        }

        private void ConfigureSwaggerGeneration(IWebJobsBuilder builder)
        {
            builder.Services.AddScoped<ISwaggerDocumentGenerator, SwaggerDocumentGenerator>();
        }

        private void ConfigureDataStorage(IWebJobsBuilder builder)
        {
            builder.Services.AddScoped<IDocumentDBProvider, DocumentDBProvider>();
        }
    }
}
