Feature: AzureSearch

Background:
	Given I load test customer data for this feature:
	| LoaderRef | Title | GivenName | FamilyName   | DateofBirth          | DateOfRegistration   | UniqueLearnerNumber | OptInUserResearch | OptInMarketResearch | DateOfTermination    | ReasonForTermination | IntroducedBy | IntroducedByAdditionalInfo | LastModifiedDate     |
	| 1         | 4     | AARON     | O'Connors    | 1953-02-13T00:00:00Z | 2018-10-28T00:00:00Z | 9999900001          | true              | false               | 2018-11-27T00:00:00Z | 1                    | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| 2         | 3     | ab        | Manning      | 1994-06-07T00:00:00Z | 2018-11-15T00:00:00Z | 9999900002          | true              | true                |                      |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-16T00:00:00Z |
	| 3         | 99    | Abbie     | Marshall     | 1993-04-10T00:00:00Z | 2018-11-28T00:00:00Z | 9999900003          | true              | true                |                      |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| 4         | 2     | Abby      | MacLeod      | 1973-05-10T00:00:00Z | 2018-10-21T00:00:00Z | 9999900004          | false             | false               |                      |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-16T00:00:00Z |
	| 5         | 5     | Abe       | O'Connors    | 1963-12-22T00:00:00Z | 2018-11-16T00:00:00Z | 9999900005          | false             | true                |                      |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-16T00:00:00Z |
	| 6         | 1     | Abednego  | N'Dours      | 1989-04-10T00:00:00Z | 2019-01-03T00:00:00Z | 9999900006          | true              | true                |                      |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-16T00:00:00Z |
	| 7         | 4     | ABEL      | D' Angelos   | 1993-06-13T00:00:00Z | 2019-01-07T00:00:00Z | 9999900007          | true              | true                |                      |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| 8         | 2     | Abiel     | D' Artagnans | 1969-06-13T00:00:00Z | 2018-11-26T00:00:00Z | 9999900008          | false             | true                |                      |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-16T00:00:00Z |
	| 9         | 99    | ABIGAIL   | D' Artagnans | 1959-08-11T00:00:00Z | 2018-12-13T00:00:00Z | 9999900009          | false             | false               |                      |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-16T00:00:00Z |


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
