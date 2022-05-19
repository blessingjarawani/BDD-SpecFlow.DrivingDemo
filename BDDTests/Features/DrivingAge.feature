Feature: DrivingAge
   Checks if a person is allowed to drive a car in a given country 

A short summary of the feature

Scenario: Permitted Driving in Switzerland
	Given Driver is 21 years old
	When They live in Switzerland
	Then They are permitted to drive
	
Scenario: 16 year can drive in USA
	Given Driver is 16 years old
	When They live in UnitedStates
	Then They are permitted to drive

	Scenario: 16 year can not drive in Germany
	Given Driver is 16 years old
	When They live in Germany
	Then They are not permitted to drive