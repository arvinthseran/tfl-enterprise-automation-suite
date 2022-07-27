Feature: Tfl_03_MultipleValidLocation

@journeyplanner
Scenario: Tfl_03_Verify that more than one matching location can be found using the widget.
	Given the user wants to travel from 'Sutton' to 'North Greenwich'
	When the user plan a journey
	Then the user should see more than one matching location