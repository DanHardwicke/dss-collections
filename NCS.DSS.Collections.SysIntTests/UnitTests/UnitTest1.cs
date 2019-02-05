using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;     
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NCS.DSS.Collections.SysIntTests.Helpers;
using NCS.DSS.Collections.SysIntTests.Models;
using NCS.DSS.TestHelperLibrary.Helpers;
using System.Reflection;

namespace NCS.DSS.Collections.SysIntTests.UnitTests
{

  /*  class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(Customer) && property.PropertyName == "LoaderRef")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        Customer e = (Customer)instance;
                        return e.LoaderRef != e.LoaderRef;
                    };
            }

            return property;
        }
    }*/

    [TestClass]
    public class UnitTest1
    {
        private EnvironmentSettings envSettings = new EnvironmentSettings();
        private readonly List<Loader> LoaderData = new List<Loader>();

        [TestMethod]
        public void DBTest()
        {
            SQLServerHelper sqlInstance = new SQLServerHelper();
            sqlInstance.ToString();

        }
        [TestMethod]
        public void RegexTest()
        {
            Regex rxv = new Regex(@"[+-]{0,1}\d+");
            var newValue = rxv.Match("b1").Value;
            var value2 = System.Text.RegularExpressions.Regex.Split("234234 23 234234", @"\s+");
        }
        [TestMethod]
        public void TimeTest()
        {
            var a = DateTime.Now.Ticks;
            Thread.Sleep(1000);
            var b = DateTime.Now.Ticks;
            var c = DateTime.Today;
            var d = DateTime.Now;
            var e = (int)(d - c).TotalSeconds;

        }

        //[TestMethod]
        //public void LoadCustomers()
        //{
            
        //    // open json file
        //    string fileName = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + $@"\json\test_customers.json";
        //    using (var sr = new StreamReader(fileName))
        //    {
        //        // load into collection
        //        var serializer = new JsonSerializer();
        //        using (var reader = new JsonTextReader(sr))
        //        {
        //            var customers = serializer.Deserialize<LoadCustomer[]>(reader);
        //            //var loaderItem = JsonConvert.DeserializeObject(Loader[] > (reader);

        //           /* JsonSerializerSettings settings = new JsonSerializerSettings
        //            {
        //                ContractResolver = new ShouldSerializeContractResolver()
        //            };*/

        //            // loop through collection
        //            foreach ( var customer in customers )
        //            {
        //                // submit customer
        //                string json = JsonConvert.SerializeObject(customer, Formatting.Indented);//, settings);

        //                // don't want to send internal reference
        //                json = JsonHelper.RemovePropertyFromJsonString(json, "LoaderRef");

        //                var response = RestHelper.Post(envSettings.BaseUrl + "/customers/api/customers/", json, envSettings.TouchPointId, envSettings.SubscriptionKey);

        //                if (response.StatusCode == System.Net.HttpStatusCode.Created)
        //                {
        //                    // store returned customer ID with loader reference
        //                   // // // LoaderData.Add(new Loader(customer.LoaderRef);//, JsonHelper.GetPropertyFromJsonString(response.Content,"CustomerId")));
        //                }

        //            }
        //        }
        //    }


        //    // now load address file
        //    fileName = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + $@"\json\test_addresses.json";
        //    using (var sr = new StreamReader(fileName))
        //    {
        //        // load into collection
        //        var serializer = new JsonSerializer();
        //        using (var reader = new JsonTextReader(sr))
        //        {
        //            var addresses = serializer.Deserialize<LoadAddress[]>(reader);
        //            //var loaderItem = JsonConvert.DeserializeObject(Loader[] > (reader);

        //            /* JsonSerializerSettings settings = new JsonSerializerSettings
        //             {
        //                 ContractResolver = new ShouldSerializeContractResolver()
        //             };*/



        //            // loop through collection
        //            foreach (var address in addresses)
        //            {
        //                // can we find the loader ref in the loaderdata

        //                var list = LoaderData.Where(item => item.LoaderReference == address.LoaderRef);
        //                foreach (var item in list)
        //                {
        //    //                address.CustomerId = item.CustomerID;

        //                    string json = JsonConvert.SerializeObject(address, Formatting.Indented);//, settings);

        //                    // don't want to send internal reference
        //                    json = JsonHelper.RemovePropertyFromJsonString(json, "LoaderRef");

        //                    var response = RestHelper.Post(envSettings.BaseUrl + "addresses/api/Customers/" + address.CustomerId + "/addresses/", json, envSettings.TouchPointId, envSettings.SubscriptionKey);

        //                    /* if (response.StatusCode == System.Net.HttpStatusCode.Created)
        //                     {
        //                         // store returned customer ID with loader reference
        //                         LoaderData.Add(new Loader(address.LoaderRef, GetPropertyFromJsonString(response.Content, "CustomerId")));
        //                     }*/
        //                }

        //            }
        //        }
        //    }
        //    // now load contact file
        //    fileName = Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") + $@"\json\test_contacts.json";
        //    using (var sr = new StreamReader(fileName))
        //    {
        //        // load into collection
        //        var serializer = new JsonSerializer();
        //        using (var reader = new JsonTextReader(sr))
        //        {
        //            var contacts = serializer.Deserialize<LoadContact[]>(reader);
        //            //var loaderItem = JsonConvert.DeserializeObject(Loader[] > (reader);

        //            /* JsonSerializerSettings settings = new JsonSerializerSettings
        //                {
        //                    ContractResolver = new ShouldSerializeContractResolver()
        //                };*/



        //            // loop through collection
        //            foreach (var contact in contacts)
        //            {
        //                // can we find the loader ref in the loaderdata

        //                var list = LoaderData.Where(item => item.LoaderReference == contact.LoaderRef);
        //                foreach (var item in list)
        //                {
        //       //             contact.CustomerId = item.CustomerID;

        //                    string json = JsonConvert.SerializeObject(contact, Formatting.Indented);//, settings);

        //                    // don't want to send internal reference
        //                    json = JsonHelper.RemovePropertyFromJsonString(json, "LoaderRef");

        //                    var response = RestHelper.Post(envSettings.BaseUrl + "contacts/api/Customers/" + contact.CustomerId + "/contacts/", json, envSettings.TouchPointId, envSettings.SubscriptionKey);

        //                    /* if (response.StatusCode == System.Net.HttpStatusCode.Created)
        //                        {
        //                            // store returned customer ID with loader reference
        //                            LoaderData.Add(new Loader(address.LoaderRef, GetPropertyFromJsonString(response.Content, "CustomerId")));
        //                        }*/
        //                }

        //            }
        //        }
        //    }
                
        //}
    }
}
