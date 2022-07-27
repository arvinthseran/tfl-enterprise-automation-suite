Feature: Tfl_04_NoLocation

@journeyplanner
Scenario: Tfl_04_Verify that the widget is unable to plan a journey if no locations are entered
	Given the user does not have a location
	When the user plan a journey with no locations
	Then the user is unable to plan a journey
