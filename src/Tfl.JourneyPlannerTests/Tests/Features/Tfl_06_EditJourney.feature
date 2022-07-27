Feature: Tfl_06_EditJourney

@journeyplanner
Scenario: Tfl_06_Edit a journey
	Given the user enters a valid locations
	When the user plan a journey
	Then the user can edit the journey
