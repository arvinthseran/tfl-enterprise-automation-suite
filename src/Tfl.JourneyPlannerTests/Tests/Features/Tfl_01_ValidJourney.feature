Feature: Tfl_01_ValidJourney

@journeyplanner
Scenario: Tfl_01_Verify that a valid journey can be planned using the widget
	Given the user wants to travel from 'West Sutton Rail Station' to 'North Greenwich Underground Station'
	When the user plan a journey
	Then the user should see valid journey results
	But should not see more than one matching location
