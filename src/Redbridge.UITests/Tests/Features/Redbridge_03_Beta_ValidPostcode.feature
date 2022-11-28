Feature: Redbridge_03_Beta_ValidPostcode

As a product Owner I need to test website for broken links

@regression
@redbridgecitycouncil
@beta
Scenario: Redbridge_03_Beta_ValidPostcode
	When the user selects an address
	Then the user should see the address summary
