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
        //private readonly List<Loader> LoaderData = new List<Loader>();

      /*  public List<Loader> ProcessDataTable (Table data, List<Loader> list, string path, string parentToken = "")//, string parentToken = "")
        // if parentToken is set, try to insert this into the supplied. path
        // if parentToken is set, try to extract related reference from LoaderData
        // if parentToken not set, extract the token from the response and store it
        {
            var collection = data.CreateSet<T>();
            
            foreach (T item in collection)
            {
               // List<Loader> matchedList = new List<Loader>();
                string parentId = "";
                if (parentToken.Length > 0)
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
                var pathToUse = (parentToken.Length > 0 ? path.Replace(parentToken, parentId) : path);

                var response = RestHelper.Post(envSettings.BaseUrl + pathToUse, json, envSettings.TouchPointId, envSettings.SubscriptionKey);

                response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

                if (parentToken.Length.Equals(0) )
                {
                    // store returned customer ID with loader reference
                    LoaderData.Add(new Loader(item.LoaderRef, JsonHelper.GetPropertyFromJsonString(response.Content, "CustomerId")));
                }
            }

            return LoaderData;
        }
        */


        public List<Loader> ProcessDataTable(Table data, List<Loader> existingList, string path, string ParentType, string tokenToStore = "")
        {
            var collection = data.CreateSet<T>();
            List<Loader> localList = new List<Loader>();

            foreach (T item in collection)
            {
                Loader newLoad = new Loader();// ("", "");
                var pathToUse = path;
                //if a parent name is supplied want to look up the parent ID in the list of loader items (list) 
                if (ParentType != String.Empty)
                {
                    int count = 0;
                    foreach ( var l in existingList.Where( x => x.LoaderReference == item.LoaderRef && x.ParentType == ParentType))
                    {
                        count++;
                        if ( count == Convert.ToInt32( (string.IsNullOrEmpty(item.ParentRef) ? "1" : item.ParentRef) ))
                        {
                            //clone the dictionary into the new loader item newLoad
                            newLoad.AllParents.AddRange(l.AllParents);
                            
                            // increment newLoader order?? leave for now (don't know what max is and ordering is probably guaranteed by the list
                        }
                    }
                    newLoad.AllParents.Count.Should().BeGreaterThan(0);

                    //use the dictionary in the new loader item to replace the tokens in the supplied path

                    foreach (var refIndex in newLoad.AllParents)
                    {
                        pathToUse = pathToUse.Replace(refIndex.Key, refIndex.Value);

                    }

                }

                // prep request json
                string json = JsonConvert.SerializeObject(item, Formatting.Indented);//, settings);

                // don't want to send internal reference
                json = JsonHelper.RemovePropertyFromJsonString(json, "LoaderRef");
                json = JsonHelper.RemovePropertyFromJsonString(json, "ParentRef");


                //submit the request
                var response = RestHelper.Post(envSettings.BaseUrl + pathToUse, json, envSettings.TouchPointId, envSettings.SubscriptionKey);

                response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

                var idToStore = JsonHelper.GetPropertyFromJsonString(response.Content, tokenToStore);

                // capture the json element in the response json and add it to the dictionary in newLoad item
                newLoad.AllParents.Add(new FamilyTreeItem(tokenToStore, idToStore));

                // set the direct parent IT in newLoad item
                newLoad.ParentType = tokenToStore;
                newLoad.ParentId = idToStore;
                newLoad.LoaderReference = item.LoaderRef;

                // add the new loader item to the list
                localList.Add(newLoad);
            }
          

            return localList;
        }
 /*       public List<Loader> ProcessDataTableWIP(Table data, List<Loader> list, string path, string[] tokenPath, string tokenToStore = "")
        // if parentToken is set, try to insert this into the supplied. path
        // if parentToken is set, try to extract related reference from LoaderData
        // if parentToken not set, extract the token from the response and store it
        {
            var collection = data.CreateSet<T>();

            foreach (T item in collection)
            {
                // List<Loader> matchedList = new List<Loader>();
                string parentId = "";
                List<string> tokenValues = new List<string>();

                foreach (var token in tokenPath)
                {

                }
                if (tokenPath.Count() > 0)
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
                string pathToUse = path;
                foreach (var token in parentToken)//.Select(( value, index) => new { value, index }))
                {
                    //pathToUse = pathToUse.Replace(token.value.Key, token.value.Value);
                    pathToUse = pathToUse.Replace(token.Key, token.Value);
                }
                
                var response = RestHelper.Post(envSettings.BaseUrl + pathToUse, json, envSettings.TouchPointId, envSettings.SubscriptionKey);

                response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

                // does an item exist for this loader ref?

                if (parentToken.Count.Equals(0))
                {
                    // store returned customer ID with loader reference
                    LoaderData.Add(new Loader(item.LoaderRef, JsonHelper.GetPropertyFromJsonString(response.Content, "CustomerId")));
                }
            }

            return LoaderData;
        }*/

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
