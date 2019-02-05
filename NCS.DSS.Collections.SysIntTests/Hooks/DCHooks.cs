using FluentAssertions;
using NCS.DSS.Collections.SysIntTests.Helpers;
using NCS.DSS.Collections.SysIntTests.Models;
using NCS.DSS.TestHelperLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;


namespace NCS.DSS.Collections.SysIntTests.Hooks
{
    [Binding]
    public sealed class DCHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ScenarioContext scenarioContext;
        private readonly EnvironmentSettings envSettings;

        public DCHooks(ScenarioContext context, EnvironmentSettings settings )
        {
            scenarioContext = context;
            envSettings = settings;
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            List<Loader> testData = (List<Loader>)scenarioContext["SearchTestData"];
            SQLServerHelper sqlHelper = new SQLServerHelper();
            CosmosHelper.Initialise(envSettings.CosmosEndPoint, envSettings.CosmosAccountKey);
            sqlHelper.SetConnection(envSettings.SqlConnectionString);
            // loop through the data load list and check each is now in the SQL server data store
            foreach (var item in testData)
            {
                if (item.LoadedToSqlServer) // temp measure until change feed has been delivered
                {
                    sqlHelper.AddReplacementRule(item.ParentType, "id");
                    Console.WriteLine("Delete from SQL server " + item.ParentType + " : " + item.ParentId);
                    var result = sqlHelper.DeleteRecord(constants.BackupTableNameFromId(item.ParentType), item.ParentType, item.ParentId);
                    result.Should().BeTrue("Because otherwise a record was not deleted");
                }

                // ?? does change feed send deletes?
                CosmosHelper.DeleteDocument(constants.CollectionNameFromId(item.ParentType), constants.BackupTableNameFromId(item.ParentType), item.ParentId);

            }
            sqlHelper.CloseConnection();
          /*  foreach (var item in testData)
            { 
                Console.WriteLine("TODO delete " + item.ParentType + " : " + item.ParentId);
            }
            */
        }
    }
}
