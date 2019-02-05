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
using NCS.DSS.TestHelperLibrary.Helpers;
using NCS.DSS.Collections.SysIntTests.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace NCS.DSS.Collections.SysIntTests.Helpers
{
    class DataLoadHelper<T> where T : ILoader
    {
        private EnvironmentSettings envSettings = new EnvironmentSettings();
        private static string TimestampString;// = DateTime.Now.ToString("yyMMddHHMMss");
        public bool LoadToBackupStore { get; set; } = true;

        public DataLoadHelper()
        {
            string tmp = DateTime.Now.ToString("yyMMddHHMMss");
            TimestampString = "";
            foreach ( var bit in tmp)
            {
                TimestampString += "ABCDEFGHIJKL".Substring(Convert.ToInt32(bit.ToString()),1); 


            }

        }

      
        public List<Loader> ProcessDataTable(Table data, List<Loader> existingList, string path, string ParentType, string tokenToStore = "")
        {
            Table updatedData = ReplaceTokensInTable(data);
            var collection = updatedData.CreateSet<T>();
            List<Loader> localList = new List<Loader>();
            SQLServerHelper sqlHelper = new SQLServerHelper();
            sqlHelper.SetConnection(envSettings.SqlConnectionString);
            sqlHelper.AddReplacementRule(tokenToStore, "id");

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

                // do we want to push this to the data store?
                newLoad.LoadedToSqlServer = false;
                switch ( tokenToStore )
                {
                    case "CustomerId":
                    case "OutcomeId":
                    case "ActionPlanId":
                        break;
                    default:
                        if (LoadToBackupStore)
                        {
                            sqlHelper.InsertRecordFromJson( constants.BackupTableNameFromId(tokenToStore) , response.Content);
                            newLoad.LoadedToSqlServer = true;
                        }
                    break;
                }


               

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

            sqlHelper.CloseConnection();
            return localList;
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
                    else if (value.Value.Contains("[FEATURE_TS]"))
                    {
                        newValue = value.Value.Replace("[FEATURE_TS]", TimestampString);
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
