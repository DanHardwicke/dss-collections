using System;
using System.Collections;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace NCS.DSS.Collections.SysIntTests
{
    public class EnvironmentSettings 
    {
        private static readonly IConfiguration Configuration =
            new EnvironmentSettingsConfigurationBuilder(nameof(NCS.DSS.Collections.SysIntTests)).BuildConfiguration();

        public string BaseUrl => Configuration["RestService:BaseUrl"];
        public string TouchPointId => Configuration["RestService:TouchPointId"];
        public string SubscriptionKey => Configuration["RestService:SubscriptionKey"];
        public string CosmosEndPoint => Configuration["CosmosDB:EndPoint"];
        public string CosmosAccountKey => Configuration["CosmosDB:Key"];
        public string SqlConnectionString => Configuration["SQLDataStore:ConnectionString"];
    }
}
