﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace NCS.DSS.Collections.SysIntTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Post")]
    [NUnit.Framework.CategoryAttribute("Collections")]
    public partial class PostFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Post.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Post", "\tThe ABCs will request a year to day report via a POST to an Rest API service", ProgrammingLanguage.CSharp, new string[] {
                        "Collections"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
 #line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "LoaderRef",
                        "TouchPoint",
                        "Title",
                        "GivenName",
                        "FamilyName",
                        "DateofBirth",
                        "DateOfRegistration",
                        "UniqueLearnerNumber",
                        "OptInUserResearch",
                        "OptInMarketResearch",
                        "DateOfTermination",
                        "ReasonForTermination",
                        "IntroducedBy",
                        "IntroducedByAdditionalInfo",
                        "LastModifiedDate"});
            table1.AddRow(new string[] {
                        "18TMRW",
                        "9000000001",
                        "4",
                        "eighteenone",
                        "Smith",
                        "Today -18Y -1D",
                        "Now -3D",
                        "9999900001",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "18TODAY",
                        "9000000001",
                        "4",
                        "eighteentwo",
                        "Smithe",
                        "Today -18Y",
                        "Now -3D",
                        "9999900002",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "18YESTERDAY",
                        "9000000001",
                        "4",
                        "eighteenthree",
                        "Smythe",
                        "Today -18Y +1D",
                        "Now -3D",
                        "9999900003",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "100TMRW",
                        "9000000001",
                        "4",
                        "stilninetynine",
                        "Smith",
                        "Today -100Y -1D",
                        "Now -3D",
                        "9999900001",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "100TODAY",
                        "9000000001",
                        "4",
                        "onehundredtoday",
                        "Smithe",
                        "Today -100Y",
                        "Now -3D",
                        "9999900002",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "100YESTERDAY",
                        "9000000001",
                        "4",
                        "onehundredalready",
                        "Smythe",
                        "Today -100Y +1D",
                        "Now -3D",
                        "9999900003",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "DOB_UNKNOWN",
                        "9000000001",
                        "4",
                        "nodob",
                        "Smythe",
                        "",
                        "Now -3D",
                        "9999900003",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "SESSION_B4_CONTRACT_START",
                        "9000000001",
                        "4",
                        "darren",
                        "Smith",
                        "Today -21Y",
                        "Now -3D",
                        "9999900001",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "SESSION_ON_CONTRACT_START",
                        "9000000001",
                        "4",
                        "Bill",
                        "Smithe",
                        "Today -21Y",
                        "Now -3D",
                        "9999900002",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "SESSION_HAS_CURRENT_DATE",
                        "9000000001",
                        "4",
                        "Doris",
                        "Smithe",
                        "Today -21Y",
                        "Now -3D",
                        "9999900002",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "SESSION_NOW",
                        "9000000001",
                        "4",
                        "Dorren",
                        "Smithe",
                        "Today -21Y",
                        "Now -3D",
                        "9999900002",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "SESSION_HAS_FUTURE_DATE",
                        "9000000001",
                        "4",
                        "Denis",
                        "Smithe",
                        "Today -21Y",
                        "Now -3D",
                        "9999900002",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "MULTIPLE_SESSIONS_THIS_YR",
                        "9000000001",
                        "4",
                        "Denis",
                        "Smithe",
                        "Today -21Y",
                        "Now -3D",
                        "9999900002",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
            table1.AddRow(new string[] {
                        "MULTIPLE_SESSIONS_HISTORIC",
                        "9000000001",
                        "4",
                        "Denis",
                        "Smithe",
                        "Today -21Y",
                        "Now -3D",
                        "9999900002",
                        "true",
                        "false",
                        "",
                        "",
                        "1",
                        "ZZ_TESTDATA_ANON",
                        "2019-01-17T00:00:00Z"});
#line 8
 testRunner.Given("I load test customer data for this feature:", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "LoaderRef",
                        "Address1",
                        "Address2",
                        "Address3",
                        "Address4",
                        "Address5",
                        "PostCode",
                        "AlternativePostCode",
                        "Longitude",
                        "Latitude",
                        "EffectiveFrom",
                        "EffectiveTo",
                        "LastModifiedDate",
                        "LastModifiedTouchpointId"});
            table2.AddRow(new string[] {
                        "18TMRW",
                        "1 Lake Street",
                        "North Walsham",
                        "",
                        "",
                        "",
                        "B44 9UX",
                        "EC2P 2AG",
                        "",
                        "",
                        "",
                        "",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table2.AddRow(new string[] {
                        "18TODAY",
                        "2 Lake Street",
                        "North Walsham",
                        "",
                        "",
                        "",
                        "B44 9UX",
                        "EC2P 2AG",
                        "",
                        "",
                        "",
                        "",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table2.AddRow(new string[] {
                        "18YESTERDAY",
                        "3 Lake Street",
                        "North Walsham",
                        "",
                        "",
                        "",
                        "B44 9UX",
                        "EC2P 2AG",
                        "",
                        "",
                        "",
                        "",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table2.AddRow(new string[] {
                        "100TMRW",
                        "4 Lake Street",
                        "North Walsham",
                        "",
                        "",
                        "",
                        "B44 9UX",
                        "EC2P 2AG",
                        "",
                        "",
                        "",
                        "",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table2.AddRow(new string[] {
                        "100TODAY",
                        "5 Lake Street",
                        "North Walsham",
                        "",
                        "",
                        "",
                        "B44 9UX",
                        "EC2P 2AG",
                        "",
                        "",
                        "",
                        "",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table2.AddRow(new string[] {
                        "100YESTERDAY",
                        "6 Lake Street",
                        "North Walsham",
                        "",
                        "",
                        "",
                        "B44 9UX",
                        "EC2P 2AG",
                        "",
                        "",
                        "",
                        "",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
#line 26
 testRunner.Given("I load test address data for this feature:", ((string)(null)), table2, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "LoaderRef",
                        "PreferredContactMethod",
                        "MobileNumber",
                        "HomeNumber",
                        "AlternativeNumber",
                        "EmailAddress",
                        "LastModifiedDate",
                        "LastModifiedTouchpointId"});
            table3.AddRow(new string[] {
                        "18TMRW",
                        "4",
                        "07484503700",
                        "05100924950",
                        "08483057675",
                        "email1@domain2.test",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table3.AddRow(new string[] {
                        "18TODAY",
                        "4",
                        "07484503700",
                        "05100924950",
                        "08483057675",
                        "email2@domain2.test",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table3.AddRow(new string[] {
                        "18YESTERDAY",
                        "4",
                        "07484503700",
                        "05100924950",
                        "08483057675",
                        "email3@domain2.test",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table3.AddRow(new string[] {
                        "100TMRW",
                        "4",
                        "07484503700",
                        "05100924950",
                        "08483057675",
                        "email4@domain2.test",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table3.AddRow(new string[] {
                        "100TODAY",
                        "4",
                        "07484503700",
                        "05100924950",
                        "08483057675",
                        "email5@domain2.test",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table3.AddRow(new string[] {
                        "100YESTERDAY",
                        "4",
                        "07484503700",
                        "05100924950",
                        "08483057675",
                        "email6@domain2.test",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
#line 36
  testRunner.Given("I load test contact data for this feature:", ((string)(null)), table3, "Given ");
#line 141
 testRunner.Given("I have completed loading data and don\'t want to repeat for each test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 142
 testRunner.And("I have confirmed all test data is now in the backup data store", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer is less than 18 years old")]
        public virtual void CustomerIsLessThan18YearsOld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer is less than 18 years old", null, ((string[])(null)));
#line 147
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line 148
  testRunner.Given("a request has been made and the report data is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 150
  testRunner.Then("test customer \"18TODAY\" is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
  testRunner.And("test customer \"18YESTERDAY\" is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer is more than 100 years old")]
        public virtual void CustomerIsMoreThan100YearsOld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer is more than 100 years old", null, ((string[])(null)));
#line 154
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line 155
  testRunner.Given("a request has been made and the report data is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 156
  testRunner.Then("test customer \"100TMRW\" is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
  testRunner.And("test customer \"100TODAY\" is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
  testRunner.And("test customer \"100YESTERDAY\" is not included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer DOB is not known")]
        public virtual void CustomerDOBIsNotKnown()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer DOB is not known", null, ((string[])(null)));
#line 163
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line 164
  testRunner.Given("a request has been made and the report data is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 165
  testRunner.Then("test customer \"DOB_UNKNOWN\" is not included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A session exists which is dated before the contract start date")]
        public virtual void ASessionExistsWhichIsDatedBeforeTheContractStartDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A session exists which is dated before the contract start date", null, ((string[])(null)));
#line 167
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line 168
  testRunner.Given("a request has been made and the report data is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 169
  testRunner.Then("test customer \"SESSION_ON_CONTRACT_START\" is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 170
  testRunner.And("test customer \"SESSION_B4_CONTRACT_START\" is not included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A session exists which is dated in the future")]
        public virtual void ASessionExistsWhichIsDatedInTheFuture()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A session exists which is dated in the future", null, ((string[])(null)));
#line 172
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line 173
  testRunner.Given("a request has been made and the report data is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 174
  testRunner.Then("test customer \"SESSION_HAS_CURRENT_DATE\" is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 175
        testRunner.And("test customer \"SESSION_NOW\" is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
  testRunner.And("test customer \"SESSION_HAS_FUTURE_DATE\" is not included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("More than one sessions exist which relate to the current financial year")]
        public virtual void MoreThanOneSessionsExistWhichRelateToTheCurrentFinancialYear()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("More than one sessions exist which relate to the current financial year", null, ((string[])(null)));
#line 178
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line 179
  testRunner.Given("a request has been made and the report data is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 180
  testRunner.Then("test customer \"MULTIPLE_SESSIONS_THIS_YR\" is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion