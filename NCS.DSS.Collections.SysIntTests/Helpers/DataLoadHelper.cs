using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NCS.DSS.Collections.SysIntTests.Helpers;
using NCS.DSS.Collections.SysIntTests.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace NCS.DSS.Collections.SysIntTests.Helpers
{
    class DataLoadHelper<T> where T : ILoader
    {
        private EnvironmentSettings envSettings = new EnvironmentSettings();
        private readonly List<Loader> LoaderData = new List<Loader>();

        public List<Loader> ProcessDataTable (Table data, List<Loader> list, string path, string token = "")//, string parentToken = "")
        // if parentToken is set, try to insert this into the supplied. path
        // if parentToken is set, try to extract related reference from LoaderData
        // if parentToken not set, extract the token from the response and store it
        {
            var collection = data.CreateSet<T>();
            
            foreach (T item in collection)
            {
               // List<Loader> matchedList = new List<Loader>();
                string parentId = "";
                if (token.Length > 0)
                {
                    // find 
                    //matchedList.AddRange(LoaderData.Where(x => x.LoaderReference == item.LoaderRef).);
                    var matchedList = list.Where(x => x.LoaderReference == item.LoaderRef);
                    parentId = matchedList.First().CustomerID;
                    parentId.Should().NotBeNullOrEmpty();
                    item.CustomerId = parentId;
                }


                // submit customer
                string json = JsonConvert.SerializeObject(item, Formatting.Indented);//, settings);

                // don't want to send internal reference
                json = JsonHelper.RemovePropertyFromJsonString(json, "LoaderRef");

                //string lookupValue = parentToken;
                var pathToUse = (token.Length > 0 ? path.Replace(token, parentId) : path);

                var response = RestHelper.Post(envSettings.BaseUrl + pathToUse, json, envSettings.TouchPointId, envSettings.SubscriptionKey);

                response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

                if (token.Length.Equals(0) )
                {
                    // store returned customer ID with loader reference
                    LoaderData.Add(new Loader(item.LoaderRef, JsonHelper.GetPropertyFromJsonString(response.Content, "CustomerId")));
                }
            }

            return LoaderData;
        }

        public static Table ReplaceTokensInTable(Table table)
        {
            string[] headers = table.Header.ToArray();
            Table newTable = new Table(headers);
            foreach (var row in table.Rows)
            {
                IDictionary<string, string> newRow = new Dictionary<string, string>();
                foreach (var value in row)
                {
                    string newValue = string.Empty;
                    DateTime extractedDateTime = DateTime.MinValue;
                    bool longDate = false;

                    if (value.Key.ToLower().Contains("date"))
                    {
                        if (value.Value.Contains(" "))
                        {
                            // extract to componets
                            var parts = System.Text.RegularExpressions.Regex.Split(value.Value, @"\s+");
                            Regex rxv = new Regex(@"[+-]{0,1}\d+");
                            
                            foreach ( var part in parts)
                            {
                                switch (part.ToLower())
                                {                                     
                                    case "today":
                                        extractedDateTime = DateTime.Today;
                                        break;
                                    case "now":
                                        extractedDateTime = DateTime.Now;
                                        longDate = true;
                                    break;
                                    default:
                                        var number = rxv.Match(part).Value;
                                        if (Regex.IsMatch(part, @"[+-]{0,1}\d+[Y]"))
                                        {
                                            extractedDateTime = extractedDateTime.AddYears(Convert.ToInt32(number));
                                        }
                                        else if (Regex.IsMatch(part, @"[+-]{0,1}\d+[D]"))
                                        {
                                            extractedDateTime = extractedDateTime.AddDays(Convert.ToInt32(number));
                                        }
                                        break;

                                }
                            }
                            newValue = extractedDateTime.ToString("yyyy-MM-dd" + (longDate ? "THH:mm:ssZ" : "T00:00:00Z"));
                        }

                    }

                    if (value.Key.Length > 0)
                    {
                        newRow.Add(value.Key, (newValue == string.Empty) ? value.Value : newValue);
                    }
                    //Regex rxv = new Regex(@"[+-]{0,1}\d+");
                    //string newValue = string.Empty;
                    //bool longDate = false;

                    //Today - 1
              /*      if (Regex.IsMatch(value.Value, @"Today([ ]+[+-]{0,1}\d+[YD]{0,1})+") || (longDate = Regex.IsMatch(value.Value, @"Now([ ]+[+-]{0,1}\d+[YD]{0,1})+")))
                    {
                        newValue = rxv.Match(value.Value).Value;
                    }
                    else if (value.Value == "Today" || value.Value == "Now")
                    {
                        newValue = "0";
                    }
                    if (newValue.Length > 0)
                    {

                        newValue = DateTime.Now.AddDays(Convert.ToInt32(newValue)).ToString("dd/MM/yyyy" + (longDate ? " HH:mm:ss" : string.Empty));
                    }
                    if (value.Key.Length > 0)
                    {
                        newRow.Add(value.Key, (newValue == string.Empty) ? value.Value : newValue);
                    }
                    */
                }
                newTable.AddRow(newRow);
            }
            return newTable;
        }


    }
}
