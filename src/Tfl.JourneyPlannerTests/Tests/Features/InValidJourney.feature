Feature: InValidJourney

@journeyplanner
Scenario: Tfl_01_Verify that the widget is unable to provide results for an invalid journey
	Given the user wants to travel from 'SM3 9YY' to 'SM3 8YY'
	When the user plan a journey
	Then the user shouldn't find matching journey results
