Feature: Tfl_07_RecentJourney

@journeyplanner
@allowallcookies
Scenario: Tfl_07_Verify recent journey
	Given the user enters a valid locations
	When the user plan a journey from the suggestions
	Then the recent journey can be found in the recent tab