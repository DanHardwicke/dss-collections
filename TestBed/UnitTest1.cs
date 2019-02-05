using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCS.DSS.TestHelperLibrary.Helpers;
using NCS.DSS.Collections.SysIntTests.Models;
//using NCS.DSS.TestHelperLibrary.Models;



namespace TestBed
{
    public class FamilyTreeItem
    {
        public FamilyTreeItem(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Loader
        {
            //public Loader( string loaderRef), string customerId)
            //{
            //    LoaderReference = loaderRef;
            // //   CustomerID = customerId;
            //  //  ParentIds = new OrderedDictionary();
            //}

            public string LoaderReference { get; set; }
            // public string CustomerID { get; set; }
            //  public OrderedDictionary ParentIds;

            public string ParentType { get; set; }
            public string ParentId { get; set; }
            public List<FamilyTreeItem> AllParents = new List<FamilyTreeItem>();
            //  public int order { get; set; }


        }
    


    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void DBTest()
        {

            SQLServerHelper sqlInstance = new SQLServerHelper();
            //  sqlInstance.test();

             sqlInstance.InsertRecordFromJson("dbo-diversitydetails", "{ \"id\": \"5e89e22c-8195-4daa-871f-7b36618673c3\",    \"CustomerId\": \"3c1b94e9-ef46-4098-bc0e-2e9f82c0e462\",    \"ConsentToCollectLLDDHealth\": true,    \"LearningDifficultyOrDisabilityDeclaration\": 1} ");
        }
    
        [TestMethod]
        public void CosmosTest()
        {
            /*    CosmosHelper h = new CosmosHelper();
                h.BaseUrl = 
                h.AutorizationKey = @"hbCu1uQMgFA8JzZ25afJj2r43X6CPzPHmpkA6yokoedvCVFj3D6iXyHTFa0l9W8WJudYW7xFvFT5JUZf9XJnow==";
                h.DeleteDocument("customers", "customers", "4a30dcb6-c27c-4626-8dcc-d1f9f61685cf");
    */
     //       CosmosHelper.Initialise("
     //       CosmosHelper.DeleteDocument("customers", "customers", "3c1b94e9-ef46-4098-bc0e-2e9f82c0e462");

            CosmosHelper.Initialise("/", @"");
            CosmosHelper.DeleteDocument("customers", "customers", "3c1b94e9-ef46-4098-bc0e-2e9f82c0e462");


        }

        [TestMethod]
        public void ComsmosTestQuickStartITEM()
        {
            DocumentDBRepository<Models.Item>.Initialize();

            Models.Item item = new Models.Item();
            item.Name = "From test";
            item.Description = "To the db";
            DocumentDBRepository<Models.Item>.CreateItemAsync(item).GetAwaiter().GetResult();
            
            //await DocumentDBRepository<Item>.CreateItemAsync(item);
            //DocumentDBRepository<Models.Item>.CreateItemAsync(item).GetAwaiter();

        }

        [TestMethod]
        public void ComsmosTestQuickStartAsync()
        {
            DocumentDBRepository<NCS.DSS.Collections.SysIntTests.Models.Customer>.Initialize();

            NCS.DSS.Collections.SysIntTests.Models.Customer customer = new Customer();
            customer.DateofBirth = "12/12/1971";
            customer.FamilyName = "Jones";
            //await DocumentDBRepository<Item>.CreateItemAsync(item);
            dynamic a =  DocumentDBRepository<NCS.DSS.Collections.SysIntTests.Models.Customer>.CreateItemAsync(customer).GetAwaiter().GetResult();

            DocumentDBRepository<NCS.DSS.Collections.SysIntTests.Models.Customer>.DeleteItemAsync(a.Id).GetAwaiter().GetResult();
            DocumentDBRepository<NCS.DSS.Collections.SysIntTests.Models.Customer>.DeleteItemAsync("f72c07d6-e3a6-4dc2-9e62-2e91f09e484e").GetAwaiter().GetResult();

        }
        [TestMethod]
        public void TestMethod1()
        {
            List<Loader> localList1 = new List<Loader>();
            List<Loader> localList2 = new List<Loader>();

            Loader newOne = new Loader();
            Loader newTwo = new Loader();

            newOne.AllParents.Add(new FamilyTreeItem("1", "1"));
            newOne.AllParents.Add(new FamilyTreeItem("1", "2"));
            newTwo.AllParents.Add(new FamilyTreeItem("1", "2"));
            newTwo.AllParents.Add(new FamilyTreeItem("1", "2"));

            localList1.Add(newOne);
            localList2.Add(newTwo);

            localList1.AddRange(localList2);

            var list = AddSomeMore(localList1);
            localList1.AddRange(list);

        }

        public List<Loader> AddSomeMore ( List<Loader> existingList)
        {
            List<Loader> newList = new List<Loader>();

            Loader newOne = new Loader();
            newOne.AllParents.Add(new FamilyTreeItem("3", "2"));
            newOne.AllParents.Add(new FamilyTreeItem("3", "2"));

            newList.Add(newOne);

            return newList;

        }
    }
}
