Feature: ValidJourneyPlanner

@journeyplanner
Scenario: Tfl_01_Verify that a valid journey can be planned using the widget.
	Given the user wants to travel from 'Sutton' to 'North Greenwich'
	When the user plan a journey
	Then the user should see valid journey results