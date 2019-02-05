using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCS.DSS.TestHelperLibrary.Helpers;
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
        public void ComsmosTest()
        {
            CosmosHelper h = new CosmosHelper();
            h.DeleteDocument("1", "2").GetAwaiter();
                
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
