Feature: Tfl_03_MultipleValidLocation

@journeyplanner
Scenario: Tfl_03_Verify that more than one matching location can be found using the widget.
	Given the user enters a multiple locations
	When the user plan a journey
	Then the user should see more than one matching location