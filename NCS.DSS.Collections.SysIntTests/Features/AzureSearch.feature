Feature: AzureSearch

Background: Data setup
	Given I load test customer data for this feature:
	#Parent for ADDRESS in CUSTOMER
	| LoaderRef | Title | GivenName | FamilyName          | DateofBirth | DateOfRegistration | UniqueLearnerNumber | OptInUserResearch | OptInMarketResearch | DateOfTermination | ReasonForTermination | IntroducedBy | IntroducedByAdditionalInfo | LastModifiedDate     |
	| ERIN      | 4     | Erin      | Surname[FEATURE_TS] | Today -20Y  | Now -3D            | 9999900001          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| AARON     | 4     | Aaron     | Surname[FEATURE_TS] | Today -21Y  | Now -3D            | 9999900002          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| VERONICA  | 4     | Veronica  | Surname[FEATURE_TS] | Today -22Y  | Now -3D            | 9999900003          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| CAMERON   | 4     | Cameron   | Surname[FEATURE_TS] | Today -23Y  | Now -3D            | 9999900004          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| RONALD    | 4     | Ronald    | Surname[FEATURE_TS] | Today -24Y  | Now -3D            | 9999900005          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| RON       | 4     | Ron       | Surname[FEATURE_TS] | Today -25Y  | Now -3D            | 9999900006          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| RONNIE    | 4     | Ronnie    | Surname[FEATURE_TS] | Today -26Y  | Now -3D            | 9999900007          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |

	Given I load test address data for this feature:
	#Parent for ADDRESS is CUSTOMER
	| LoaderRef | Address1      | Address2      | Address3 | Address4 | Address5 | PostCode | AlternativePostCode | Longitude | Latitude | EffectiveFrom | EffectiveTo | LastModifiedDate     | LastModifiedTouchpointId |
	| ERIN      | 1 Lake Street | North Walsham |          |          |          | B44 9UX  | EC2P 2AG            |           |          |               |             | 2019-01-23T00:00:00Z | 90000001                 |
	| AARON     | 2 Lake Street | North Walsham |          |          |          | B44 9UX  | EC2P 2AG            |           |          |               |             | 2019-01-23T00:00:00Z | 90000001                 |
	| VERONICA  | 3 Lake Street | North Walsham |          |          |          | B44 9UX  | EC2P 2AG            |           |          |               |             | 2019-01-23T00:00:00Z | 90000001                 |
	| CAMERON   | 4 Lake Street | North Walsham |          |          |          | B44 9UX  | EC2P 2AG            |           |          |               |             | 2019-01-23T00:00:00Z | 90000001                 |
	| RONALD    | 5 Lake Street | North Walsham |          |          |          | B44 9UX  | EC2P 2AG            |           |          |               |             | 2019-01-23T00:00:00Z | 90000001                 |
	| RON       | 6 Lake Street | North Walsham |          |          |          | B44 9UX  | EC2P 2AG            |           |          |               |             | 2019-01-23T00:00:00Z | 90000001                 |
	| RONNIE    | 7 Lake Street | North Walsham |          |          |          | B44 9UX  | EC2P 2AG            |           |          |               |             | 2019-01-23T00:00:00Z | 90000001                 |


	 Given I load test contact data for this feature:
	#Parent for CONTACT is CUSTOMER
	| LoaderRef | PreferredContactMethod | MobileNumber | HomeNumber  | AlternativeNumber | EmailAddress        | LastModifiedDate     | LastModifiedTouchpointId |
	| ERIN      | 4                      | 07484503700  | 05100924950 | 08483057675       | email1@domain2.test | 2019-01-23T00:00:00Z | 90000001                 |
	| AARON     | 4                      | 07484503700  | 05100924950 | 08483057675       | email2@domain2.test | 2019-01-23T00:00:00Z | 90000001                 |
	| VERONICA  | 4                      | 07484503700  | 05100924950 | 08483057675       | email3@domain2.test | 2019-01-23T00:00:00Z | 90000001                 |
	| CAMERON   | 4                      | 07484503700  | 05100924950 | 08483057675       | email4@domain2.test | 2019-01-23T00:00:00Z | 90000001                 |
	| RONALD    | 4                      | 07484503700  | 05100924950 | 08483057675       | email5@domain2.test | 2019-01-23T00:00:00Z | 90000001                 |
	| RON       | 4                      | 07484503700  | 05100924950 | 08483057675       | email6@domain2.test | 2019-01-23T00:00:00Z | 90000001                 |
	| RONNIE    | 4                      | 07484503700  | 05100924950 | 08483057675       | email7@domain2.test | 2019-01-23T00:00:00Z | 90000001                 |


	Given I have completed loading data and don't want to repeat for each test
	And I have confirmed all test data is now in the backup data store

Scenario: Synonym name search for Aaron
	Given I enter a search with the following terms
	| SearchTerm | Value    |
	| GivenName  | erin     |
	And I filter the results as follows
	| FilterTerm  | Value                   |
	| DateofBirth | gt 1953-02-13T00:00:00Z |
	When I submit the search
	Then there should be a 200 response
	And the response should include "GivenName" matches for:
	| Value1 | Value2 |
	| Aaron  | Erin   |
	And the response should include results for:
	| FieldName   | Value                |
	| DateofBirth | 1953-02-13T00:00:00Z |

Scenario: Synonym name search for Ronnie
	Given I enter a search with the following terms
	| SearchTerm | Value     |
	| GivenName  | Ronnie    |
	When I submit the search
	Then there should be a 200 response
	And the response should include "GivenName" matches for:
	| Value1 | Value2 | Value3   | Value4  | Value5 | Value6 |
	| Aaron  | Ron    | Veronica | Cameron | RONALD | Ronnie |

#Scenario: Synonym name search for Peter
#	Given I enter a search with the following terms
#	| SearchTerm | Value     |
#	| GivenName  | Peter     |
#	When I submit the search
#	Then there should be a 200 response
#	And the response should include "GivenName" matches for:
#	| Value1 | Value2 | Value3   | Value4  | Value5 |
#	| Aaron  | Ron    | Veronica | Cameron | RONALD |

Scenario: Search with OR 

Scenario: Search with AND

Scenario: Restrict search results
	Given I enter a search with the following terms
	| SearchTerm | Value    |
	| FamilyName  | SM*     |
	And I restrict the returned fields to
	| Field1     | Field2    | Field3     | Field4      |
	| CustomerId | GivenName | FamilyName | DateofBirth |
	And I filter the results as follows
	| FilterTerm  | Value                     |
	| DateofBirth | gt 1970-01-01 |
	When I submit the search
	Then there should be a 200 response
	And The response includes values for
	| Field1     | Field2    | Field3     | Field4      |
	| CustomerId | GivenName | FamilyName | DateofBirth |
	And The response includes no values for 
	| Field1             | Field2 | Field3              | Field4 | Field5            | Field6              | Field7            | Field8       | Field9                     | Field10          | Field11                  |
	| DateOfRegistration | Title  | UniqueLearnerNumber | Gender | OptInUserResearch | OptInMarketResearch | DateOfTermination | IntroducedBy | IntroducedByAdditionalInfo | LastModifiedDate | LastModifiedTouchpointID |

#| Field1     | Field2    | Field3     | Field4      |
Scenario: View 1st page of paginated results
	Given I enter a search with the following terms
         | SearchTerm | Value |
         | FamilyName | SM*   |
    And I request a count of records
	And I request a page limit of 10 records
	When I request page 1
	Then there should be a 200 response
	And the number of records returned should be 10

	Scenario: View 2nd page of paginated results
	Given I enter a search with the following terms
         | SearchTerm | Value |
         | FamilyName | SM*   |
    And I request a count of records
	And I request a page limit of 10 records
	And I request page 1
	And I remember the records returned
	When I request page 2
	Then there should be a 200 response
	And the number of records returned should be 10
	And the records should not include the ealier results

	Scenario: View last page of paginated results
	Given I enter a search with the following terms
         | SearchTerm | Value |
         | FamilyName | SM*   |
    And I request a count of records
	And I request a page limit of 10 records
	And I request page 1
	And I remember the records returned
	And I request page 2
	And I remember the records returned
	When I request the last page
	Then there should be a 200 response
	Then the remainder of the results are returned
	And the records should not include the ealier results


#Scenario: Filter by DOB

#Scenario: 


#GivenName	Searchable	Filterable
#FamilyName	Searchable	Filterable
#DateofBirth Filterable
#UniqueLearnerNumber	Searchable	
