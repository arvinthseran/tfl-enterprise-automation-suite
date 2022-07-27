Feature: Tfl_02_InValidJourney

@journeyplanner
Scenario: Tfl_02_Verify that the widget is unable to provide results for an invalid journey
	Given the user enters an invalid locations
	When the user plan a journey
	Then the user shouldn't find matching journey results
