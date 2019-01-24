Feature: AzureSearch

Background:
	Given I load test customer data for this feature:
	| LoaderRef | Title | GivenName | FamilyName | DateofBirth    | DateOfRegistration   | UniqueLearnerNumber | OptInUserResearch | OptInMarketResearch | DateOfTermination | ReasonForTermination | IntroducedBy | IntroducedByAdditionalInfo | LastModifiedDate     |
	| 1         | 4     | AARON     | O'Connors  | Today -18Y +1D | Now -3D              | 9999900001          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |

	Given I load test address data for this feature:
	| LoaderRef | Address1      | Address2      | Address3 | Address4 | Address5 | PostCode | AlternativePostCode | Longitude | Latitude | EffectiveFrom | EffectiveTo | LastModifiedDate     | LastModifiedTouchpointId |
	| 1         | 6 Lake Street | North Walsham |          |          |          | B44 9UX  | EC2P 2AG            |           |          |               |             | 2019-01-23T00:00:00Z | 90000001                 |

	 Given I load test contact data for this feature:
	| LoaderRef | PreferredContactMethod | MobileNumber | HomeNumber  | AlternativeNumber | EmailAddress        | LastModifiedDate     | LastModifiedTouchpointId |
	| 1         | 4                      | 07484503700  | 05100924950 | 08483057675       | email2@domain2.test | 2019-01-23T00:00:00Z | 90000001                 |



@mytag
Scenario: Synonym name search for Aaron
	Given I enter a search with the following terms
	| SearchTerm | Value    |
	| GivenName  | erin     |
	| FamilyName | O'Connors |
	And I filter the results as follows
	| FilterTerm  | Value                   |
	| DateofBirth | eq 1953-02-13T00:00:00Z |
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
	| Value1 | Value2 | Value3   | Value4  | Value5 |
	| Aaron  | Ron    | Veronica | Cameron | RONALD |

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
	| DateofBirth | DateofBirth gt 1970-01-01 |
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


Scenario: Filter by DOB

#Scenario: 


#GivenName	Searchable	Filterable
#FamilyName	Searchable	Filterable
#DateofBirth Filterable
#UniqueLearnerNumber	Searchable	
