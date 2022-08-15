Feature: Tfl_07_RecentJourney

@journeyplanner
@allowallcookies
Scenario: Tfl_07_Verify recent journey
	When the user plans for multiple journeys
	Then the recent journeys can be found in the recent tab