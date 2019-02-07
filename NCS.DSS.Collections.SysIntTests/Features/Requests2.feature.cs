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
    [NUnit.Framework.DescriptionAttribute("Requests")]
    [NUnit.Framework.CategoryAttribute("Collections")]
    public partial class RequestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Requests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Requests", "\tThe ABCs will request a year to day report via a POST to an Rest API service", ProgrammingLanguage.CSharp, new string[] {
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
                        "TOOYOUNG",
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
                        "AGE99.9",
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
                        "SESSION_B4_CONTRACT_START",
                        "4",
                        "stilninetynine",
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
                        "4",
                        "onehundredtoday",
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
#line 7
 testRunner.Given("I load test customer data for this feature:", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "LoaderRef",
                        "TouchpointId",
                        "AdviserDetailsId",
                        "DateandTimeOfInteraction",
                        "Channel",
                        "InteractionType",
                        "LastModifiedDate",
                        "LastModifiedTouchpointId"});
            table2.AddRow(new string[] {
                        "TOOYOUNG",
                        "4",
                        "bb940afb-1423-4999-a234-5a64a5c00831",
                        "Today -180D",
                        "1",
                        "3",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table2.AddRow(new string[] {
                        "18TODAY",
                        "4",
                        "bb940afb-1423-4999-a234-5a64a5c00831",
                        "Today -180D",
                        "2",
                        "3",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table2.AddRow(new string[] {
                        "18YESTERDAY",
                        "4",
                        "bb940afb-1423-4999-a234-5a64a5c00831",
                        "Today -180D",
                        "2",
                        "3",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
#line 22
 testRunner.Given("I load test interaction data for this feature", ((string)(null)), table2, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "LoaderRef",
                        "ParentRef",
                        "DateandTimeOfSession",
                        "VenuePostCode",
                        "SessionAttended",
                        "ReasonForNonAttendance",
                        "LastModifiedDate",
                        "LastModifiedTouchpointId"});
            table3.AddRow(new string[] {
                        "TOOYOUNG",
                        "1",
                        "Today -180D",
                        "NE9 7RG",
                        "true",
                        "",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table3.AddRow(new string[] {
                        "18TODAY",
                        "1",
                        "Today -180D",
                        "NE9 7RG",
                        "true",
                        "1",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
            table3.AddRow(new string[] {
                        "18YESTERDAY",
                        "1",
                        "Today -180D",
                        "NE9 7RG",
                        "true",
                        "1",
                        "2019-01-23T00:00:00Z",
                        "90000001"});
#line 29
 testRunner.Given("I load test session data for the feature", ((string)(null)), table3, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "LoaderRef",
                        "ParentRef",
                        "DateActionPlanCreated",
                        "CustomerCharterShownToCustomer",
                        "DateAndTimeCharterShown",
                        "DateActionPlanSentToCustomer",
                        "ActionPlanDeliveryMethod",
                        "DateActionPlanAcknowledged",
                        "PriorityCustomer",
                        "CurrentSituation"});
            table4.AddRow(new string[] {
                        "BOB",
                        "1",
                        "2018-07-30T09:00:00Z",
                        "true",
                        "2018-07-30T09:00:00Z",
                        "2018-07-30T09:00:00Z",
                        "1",
                        "2018-07-30T09:00:00Z",
                        "1",
                        "looking for work"});
#line 36
 testRunner.Given("I load action plan data for the feature", ((string)(null)), table4, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "LoaderRef",
                        "ParentRef",
                        "DateActionAgreed",
                        "DateActionAimsToBeCompletedBy",
                        "ActionSummary",
                        "SignpostedTo",
                        "ActionType",
                        "ActionStatus",
                        "PersonResponsible",
                        "LastModifiedDate"});
            table5.AddRow(new string[] {
                        "BOB",
                        "1",
                        "2018-07-30T09:00:00Z",
                        "2018-08-08T09:00:00Z",
                        "Details of stuff",
                        "Someone",
                        "1",
                        "1",
                        "1",
                        "2018-07-30T09:00:00Z"});
#line 41
 testRunner.Given("I load action data for the feature", ((string)(null)), table5, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "LoaderRef",
                        "ParentRef",
                        "OutcomeType",
                        "OutcomeClaimedDate",
                        "OutcomeEffectiveDate"});
            table6.AddRow(new string[] {
                        "BOB",
                        "1",
                        "3",
                        "2018-07-20T21:45:00Z",
                        "2018-07-20T21:45:00Z"});
#line 46
 testRunner.Given("I load outcome data for the feature", ((string)(null)), table6, "Given ");
#line 50
 testRunner.Given("I have completed loading data and don\'t want to repeat for each test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer is less than 18 years old")]
        public virtual void CustomerIsLessThan18YearsOld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer is less than 18 years old", null, ((string[])(null)));
#line 57
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line 58
  testRunner.Given("a request has been made and the submission data is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
  testRunner.Then("test customer <TOOYOUNG> is not included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
  testRunner.And("test customer <18TODAY> is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
  testRunner.And("test customer <18YESTERDAY> is included in the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer is more than 100 years old")]
        public virtual void CustomerIsMoreThan100YearsOld()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer is more than 100 years old", null, ((string[])(null)));
#line 64
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line 65
  testRunner.Given("a request has been made and the submission data is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
  testRunner.Then("test customer <AGE99.9> is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
  testRunner.And("test customer <100TODAY> is included in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
  testRunner.And("test customer <100YESTERDAY> is not included in the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion