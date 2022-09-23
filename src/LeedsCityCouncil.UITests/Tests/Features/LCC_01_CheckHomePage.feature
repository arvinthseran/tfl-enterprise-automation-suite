Feature: LCC_01_CheckHomePage

As a product Owner I need to test website for broken links

@regression
@leedscitycouncil
Scenario: LCC_01_CheckHomePage
	Given the user navigates to check your bin days page
	When the user selects an address
	Then the user should see the bin collection days
