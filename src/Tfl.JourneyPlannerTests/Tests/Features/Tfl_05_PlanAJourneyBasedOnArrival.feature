Feature: Tfl_05_PlanAJourneyBasedOnArrival

@journeyplanner
Scenario: Tfl_05_Plan a journey based on arrival time
	Given the user wants to travel from 'West Sutton Rail Station' to 'North Greenwich Underground Station'
	When the user plan a journey based on arrival time
	Then the user should see valid journey results
