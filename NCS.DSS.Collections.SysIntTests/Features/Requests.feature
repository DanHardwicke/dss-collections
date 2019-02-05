@Collections
Feature: Requests
	The ABCs will request a year to day report via a POST to an Rest API service


	Background:
	Given I load test customer data for this feature:
	#Parent for ADDRESS in CUSTOMER
	| LoaderRef                 | Title | GivenName         | FamilyName | DateofBirth     | DateOfRegistration | UniqueLearnerNumber | OptInUserResearch | OptInMarketResearch | DateOfTermination | ReasonForTermination | IntroducedBy | IntroducedByAdditionalInfo | LastModifiedDate     |
	| TOOYOUNG                  | 4     | eighteenone       | Smith      | Today -18Y -1D  | Now -3D            | 9999900001          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| 18TODAY                   | 4     | eighteentwo       | Smithe     | Today -18Y      | Now -3D            | 9999900002          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| 18YESTERDAY               | 4     | eighteenthree     | Smythe     | Today -18Y +1D  | Now -3D            | 9999900003          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| AGE99.9                   | 4     | stilninetynine    | Smith      | Today -100Y -1D | Now -3D            | 9999900001          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| 100TODAY                  | 4     | onehundredtoday   | Smithe     | Today -100Y     | Now -3D            | 9999900002          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| 100YESTERDAY              | 4     | onehundredalready | Smythe     | Today -100Y +1D | Now -3D            | 9999900003          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| SESSION_B4_CONTRACT_START | 4     | stilninetynine    | Smith      | Today -21Y      | Now -3D            | 9999900001          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |
	| SESSION_ON_CONTRACT_START | 4     | onehundredtoday   | Smithe     | Today -21Y      | Now -3D            | 9999900002          | true              | false               |                   |                      | 1            | ZZ_TESTDATA_ANON           | 2019-01-17T00:00:00Z |

	#Given I load a valid address data for each test customer
    #Given I load valid  contact data for each test customer

	Given I load test interaction data for this feature
	#Parent for INTERACTION is CUSTOMER
	| LoaderRef   | TouchpointId | AdviserDetailsId                     | DateandTimeOfInteraction | Channel | InteractionType | LastModifiedDate     | LastModifiedTouchpointId |
	| TOOYOUNG    | 4            | bb940afb-1423-4999-a234-5a64a5c00831 | Today -180D              | 1       | 3               | 2019-01-23T00:00:00Z | 90000001                 |
	| 18TODAY     | 4            | bb940afb-1423-4999-a234-5a64a5c00831 | Today -180D              | 2       | 3               | 2019-01-23T00:00:00Z | 90000001                 |
	| 18YESTERDAY | 4            | bb940afb-1423-4999-a234-5a64a5c00831 | Today -180D              | 2       | 3               | 2019-01-23T00:00:00Z | 90000001                 |

	Given I load test session data for the feature
	#Parent for SESSION is INTERACTION
	| LoaderRef   | ParentRef | DateandTimeOfSession | VenuePostCode | SessionAttended | ReasonForNonAttendance | LastModifiedDate     | LastModifiedTouchpointId |
	| TOOYOUNG    | 1         | Today -180D          | NE9 7RG       | true            |                        | 2019-01-23T00:00:00Z | 90000001                 |
	| 18TODAY     | 1         | Today -180D          | NE9 7RG       | true            | 1                      | 2019-01-23T00:00:00Z | 90000001                 |
	| 18YESTERDAY | 1         | Today -180D          | NE9 7RG       | true            | 1                      | 2019-01-23T00:00:00Z | 90000001                 |

	Given I load action plan data for the feature
	#Parent for ACTION PLAN is SESSION
	| LoaderRef | ParentRef | DateActionPlanCreated | CustomerCharterShownToCustomer | DateAndTimeCharterShown | DateActionPlanSentToCustomer | ActionPlanDeliveryMethod | DateActionPlanAcknowledged | PriorityCustomer | CurrentSituation |
	| BOB       | 1         | 2018-07-30T09:00:00Z  | true                           | 2018-07-30T09:00:00Z    | 2018-07-30T09:00:00Z         | 1                        | 2018-07-30T09:00:00Z       | 1                | looking for work |

	Given I load action data for the feature
	#Parent for ACTION is ACTION PLAN
	| LoaderRef | ParentRef | DateActionAgreed     | DateActionAimsToBeCompletedBy | ActionSummary    | SignpostedTo | ActionType | ActionStatus | PersonResponsible | LastModifiedDate     |
	| BOB       | 1         | 2018-07-30T09:00:00Z | 2018-08-08T09:00:00Z          | Details of stuff | Someone      | 1          | 1            | 1                 | 2018-07-30T09:00:00Z |

	Given I load outcome data for the feature
	| LoaderRef | ParentRef | OutcomeType | OutcomeClaimedDate   | OutcomeEffectiveDate |
	| BOB       | 1         | 3           | 2018-07-20T21:45:00Z | 2018-07-20T21:45:00Z | 

	Given I have completed loading data and don't want to repeat for each test

	#Given a request for a report is made.
	#

#Scenario: Invalid request

Scenario: Customer is less than 18 years old
		Given a request has been made and the submission data is available
		Then test customer <TOOYOUNG> is not included in the report
		And test customer <18TODAY> is included in the report
		And test customer <18YESTERDAY> is included in the response


Scenario: Customer is more than 100 years old
		Given a request has been made and the submission data is available
		Then test customer <AGE99.9> is included in the report
		And test customer <100TODAY> is included in the report
		And test customer <100YESTERDAY> is not included in the response


#Scenario: Customer date of birth is not known

#Scenario: A session exists which is dated before the contract start date

#Scenario: A session exists which is dated in the future

#Scenario Outline: More than one sessions exist which relate to the current financial year

#Scenario: Session date holds date only

#Scenario Outline: Multiple Customer Satisfaction outcomes exist with 12 month period
#12/13 months must start from the first Session with an ActionPlan 


#Scenario: One valid outcome exists with a 12 month period

#Scenario: Two valid outcome exists with a 12 month period

#Scenario Outline: Three valid outcome exists with a 12 month period
#12/13 months must start from the first Session with an ActionPlan 


#Scenario Outline: Multiple Career Management outcomes exist with 12 month period
#12/13 months must start from the first Session with an ActionPlan 

#Scenario Outline: Multiple Career Management outcomes exist with 12 month period
#12/13 months must start from the first Session with an ActionPlan 

#Scenario Outline: Multiple Sustainable Employment, Accredited Learning or Career Progression outcomes exist with 12/13 month period
#12/13 months must start from the first Session with an ActionPlan 

#Scenario: Outcome effective date is < 01/04/2019

#Scenario: Outcome effective date is in previous financial year

#Scenario: Outcome effective date is in a later collection period
#. if submitting in October's collection, the value must not be later than 31 October, even though the collection is open until 8th working day of November.


#Scenario: Outcome claimed date is blank

#Scenario: Career Progression outcome with at effective date < the session date

#Scenario: Career Progression outcome with at effective date > session date + 12 months

#Scenario: Sustainable Employment outcome with at effective date < the session date

#Scenario: Sustainable Employment with at effective date > session date + 13 months

#Scenario: OutcomeEffectiveDate date holds date only

#Scenario Outline: Priority Group Combinations



