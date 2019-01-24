using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using NCS.DSS.Collections.SysIntTests.Helpers;
using NCS.DSS.Collections.SysIntTests.Models;
using NCS.DSS.Collections.SysIntTests.Singletons;
using RestSharp;
using System.Text;
using TechTalk.SpecFlow;

namespace NCS.DSS.Collections.SysIntTests.Steps
{
    [Binding]
    public sealed class StepDefinitions : RestHelper
    {
        private string SearchClause = "";
        private string FilterClause = "";
        private string SelectClause = "";
        private string PagingClause = "";
        private String CountClause = "";
        private int PageSize;
        private int NumberOfPages;
        private List<string> PreviousResults = new List<string>();
        private IRestResponse response;
        private EnvironmentSettings envSettings = new EnvironmentSettings();
        private SearchResponse SearchResults;
        private readonly List<Loader> LoaderData = new List<Loader>();
        internal static readonly AzureSearchSingleton CustomerDataLoad = AzureSearchSingleton.Instance;


        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        public void SubmitTheSearch()
        {
            //string url = envSettings.BaseUrl + "customers/api/CustomerSearch/?" + dict["parameter1"] + "=" + CheckForSpaces(dict["parameter2"]);
            string url = "https://dss-at-shared-sch.search.windows.net/indexes/customer-search-index-v2/docs?api-version=2017-11-11&querytype=full" + SearchClause + FilterClause + SelectClause + PagingClause + CountClause;
            response = /*RestHelper.*/GetSearch(url, envSettings.TouchPointId, "39263CCAE9A631A1BD95ECF1FC75B676");

            SearchResults = JsonConvert.DeserializeObject<SearchResponse>(response.Content);
        }



        [When(@"I search")]
        public void WhenISearch()
        {
          //  ScenarioContext.Current.Pending();
        }

        [When(@"I submit the search")]
        public void WhenISubmitTheSearch()
        {
            SubmitTheSearch();
        }


        [Given(@"I filter the results as follows")]
        public void GivenIFilterTheResultsAsFollows(Table table)
        {
            // need to build a search clause with the items in the table
            string filterClause = @"";
            Boolean firstItem = true;
            Dictionary<string,string> dict = table.Rows.ToDictionary(r => r["FilterTerm"], r => r["Value"]);

            foreach (var item in dict)
            {
                filterClause += (firstItem ? "&$filter=" : " AND ") + item.Key + " " + item.Value;
                firstItem = false;
            }
            FilterClause = filterClause;
        }



        [Given(@"I enter a search with the following terms")]
        public void GivenIEnterASearchWithTheFollowingTerms(Table table)
        {
            // need to build a search clause with the items in the table
            string searchClause = @"&search=";
            bool firstItem = true;
            Dictionary<string, string> dict = table.Rows.ToDictionary(r => r["SearchTerm"], r => r["Value"]);
            
            foreach ( var item in dict)
            {
                searchClause += (firstItem ? "" : ", ") + item.Key + ":" + item.Value;
                firstItem = false;
            }
            SearchClause = searchClause;
        }

        [Given(@"I request a count of records")]
        public void GivenIRequestACountOfRecords()
        {
            CountClause = "&$count=true";
        }



        [Given(@"I request a page limit of (.*) records")]
        public void GivenIRequestAPageLimitOfRecords(int p0)
        {
            PageSize = p0;
        }

        [Given(@"I request page (.*)")]
        [When(@"I request page (.*)")]
        public void GivenIRequestPage(int p0)
        {
            // work out pagination requirements
            PagingClause = "&$top=" + PageSize;
            PagingClause += "&$skip=" + PageSize * (p0 - 1);

            SubmitTheSearch();
        }


        [When(@"I request the last page")]
        public void WhenIRequestTheLastPage()
        {
            // calculate number of pages expected
            NumberOfPages = Convert.ToInt32(Math.Ceiling((decimal) SearchResults.RecordCount / PageSize ));
            PagingClause = "&$top=" + PageSize;
            PagingClause += "&$skip=" + PageSize * ( NumberOfPages - 1 );

            SubmitTheSearch();
        }


        [Then(@"results are returned")]
        public void ThenResultsAreReturned()
        {
          //  ScenarioContext.Current.Pending();
        }

        [Then(@"there should be a (.*) response")]
        public void ThenThereShouldBeAResponse(int expectedResponseCode)
        {
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            numericStatusCode.Should().Be(expectedResponseCode);
        }

        [Then(@"the response should include ""(.*)"" matches for:")]
        public void ThenTheResponseShouldIncludeMatchesFor(string p0, Table table)
        {
            //ictionary<string,string> dict = table.Rows.ToDictionary(r =>  r => r["Value"]);
            int Tally = 0;

            foreach (var text in table.Rows[0].Values)
            {
                // first call to create the list (  haven't worked out how to do this more neatly yet )
                var list = SearchResults.Results.Where<Customer>(item => item.GivenName.ToLower() == "" /*&& TODO restrict by test tag*/);
                switch (p0)
                {
                    case "GivenName":
                        list = SearchResults.Results.Where<Customer>(item => item.GivenName.ToLower() == text.ToLower());
                        break;
                    case "FamilyName":
                        list = SearchResults.Results.Where<Customer>(item => item.FamilyName.ToLower() == text.ToLower());
                        break;
                    case "DateofBirth":
                        list = SearchResults.Results.Where<Customer>(item => item.DateofBirth.ToLower() == text.ToLower());
                        break;
                    default:
                        throw new Exception("The field: " + text + " is not supported");
                }
                // var list = SearchResults.value.Where<Customer>(item => item.GivenName.ToLower() == testCondition.Value.ToLower());
                list.Count().Should().BeGreaterThan(0);
                Tally += list.Count();
            }
            Tally.Should().Be(SearchResults.Results.Count());

        }

        [Then(@"The response includes values for")]
        public void ThenTheResponseIncludesValuesFor(Table table)
        {
            foreach (var result in SearchResults.Results)
            {
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                foreach (var text in table.Rows[0].Values)
                {
                    JsonHelper.CheckJsonPropertyHasValue(json, text).Should().BeTrue();
                }
            }
        }

        [Then(@"The response includes no values for")]
        public void ThenTheResponseIncludesNoValuesFor(Table table)
        {
            foreach (var result in SearchResults.Results)
            {
                string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                foreach (var text in table.Rows[0].Values)
                {
                    JsonHelper.CheckJsonPropertyHasNoValueValue(json, text).Should().BeTrue();
                }
            }
        }

        [Given(@"I remember the records returned")]
        public void GivenIRememberTheRecordsReturned()
        {
            var list = SearchResults.Results
                .Select(i => i.CustomerID);
            PreviousResults.AddRange(list);
        }
                



        [Given(@"I restrict the returned fields to")]
        public void GivenIRestrictTheReturnedFieldsTo(Table table)
        {
            bool firstItem = true;
            foreach (var text in table.Rows[0].Values)
            {
                SelectClause += (firstItem ? "&$select=" : ", ") + text;
                firstItem = false;
            }
        }



        [Then(@"the response should include results for:")]
        public void ThenTheResponseShouldIncludeResultsFor(Table table)
        {
            Dictionary<string, string> dict = table.Rows.ToDictionary(r => r["FieldName"], r => r["Value"]);
            int tally = 0;
             foreach ( var testCondition in dict)
            {
                var param = Expression.Parameter(typeof(Customer), "x");
                /*var predicate = Expression.Lambda<Func<Customer, bool>>(
                    Expression.Call(
                        Expression.PropertyOrField(param, testCondition.Key),
                        "Equals", null, Expression.Constant(testCondition.Value)
                    ), param);
                var projection = Expression.Lambda<Func<Customer, Tuple<int, string>>>(
                    Expression.Call(typeof(Tuple), "Create", new[] { typeof(int), typeof(string) },
                        Expression.PropertyOrField(param, "Id"),
                        Expression.PropertyOrField(param, testCondition.Key)), param);
                //var results = SearchResults.value.Where(predicate).Select(projection);*/
                //System.Linq.Enumerable.

                // first call to create the list (  haven't worked out how to do this more neatly yet )
                var list = SearchResults.Results.Where<Customer>(item => item.GivenName.ToLower() == "");
                switch (testCondition.Key)
                {
                    case "GivenName":
                        list = SearchResults.Results.Where<Customer>(item => item.GivenName.ToLower() == testCondition.Value.ToLower());
                        break;
                    case "FamilyName":
                        list = SearchResults.Results.Where<Customer>(item => item.FamilyName.ToLower() == testCondition.Value.ToLower());
                        break;
                    case "DateofBirth":
                        list = SearchResults.Results.Where<Customer>(item => item.DateofBirth.ToLower() == testCondition.Value.ToLower());
                        break;
                    default:
                        throw new Exception("The field: " + testCondition.Key  + " is not supported");
                }
                // var list = SearchResults.value.Where<Customer>(item => item.GivenName.ToLower() == testCondition.Value.ToLower());
                Console.WriteLine("Checking that " + testCondition.Key + ": " + testCondition.Value + " is inculded in the results");
                list.Count().Should().BeGreaterThan(0);
                tally += list.Count();
            }

            tally.Should().Be(SearchResults.Results.Count());
        }

        [Then(@"the number of records returned should be (.*)")]
        public void ThenTheNumberOfRecordsReturnedShouldBe(int p0)
        {
            SearchResults.Results.Count().Should().Be(p0);
        }

        [Then(@"the records should not include the ealier results")]
        public void ThenTheRecordsShouldNotIncludeTheEalierResults()
        {
            // check retured results do not include those previously returned
            var resultList = SearchResults.Results
                            .Select(s => s.CustomerID);
            bool matches = resultList.Any(x => PreviousResults.Any(y => y == x));
            matches.Should().BeFalse();
        }

        [Then(@"the remainder of the results are returned")]
        public void ThenTheRemainderOfTheResultsAreReturned()
        {
            SearchResults.Results.Count().Should().Be(SearchResults.RecordCount - ( PageSize * ( NumberOfPages - 1 ) ));
        }

        [Given(@"I load test customer data for this feature:")]
        public void GivenILoadTestCustomerDataForThisFeature(Table table)
        {
            if (CustomerDataLoad.DataSetupExecuted)
            {
                return;
            }
            DataLoadHelper<LoadCustomer> dataLoadHelper = new DataLoadHelper<LoadCustomer>();
            Table processedTable = DataLoadHelper<LoadCustomer>.ReplaceTokensInTable(table);
            var list = dataLoadHelper.ProcessDataTable(processedTable, LoaderData, "/customers/api/customers/");
            LoaderData.AddRange(list);
        }

        [Given(@"I load test address data for this feature:")]
        public void GivenILoadTestAddressDataForThisFeature(Table table)
        {
            if (CustomerDataLoad.DataSetupExecuted)
            {
                return;
            }

            DataLoadHelper<LoadAddress> dataLoadHelper = new DataLoadHelper<LoadAddress>();
            dataLoadHelper.ProcessDataTable(table, LoaderData, "addresses/api/Customers/CustomerId/addresses/", "CustomerId");

            
        }

        [Given(@"I load test contact data for this feature:")]
        public void GivenILoadTestContactDataForThisFeature(Table table)
        {
            if (CustomerDataLoad.DataSetupExecuted)
            {
                return;
            }

            DataLoadHelper<LoadContact> dataLoadHelper = new DataLoadHelper<LoadContact>();
            dataLoadHelper.ProcessDataTable(table, LoaderData, "contactdetails/api/Customers/CustomerId/contactdetails/", "CustomerId");

            CustomerDataLoad.DataSetupExecuted = true;
        }





    }
}
