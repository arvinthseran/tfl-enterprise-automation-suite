Feature: Redbridge_02_BinCollection

As a product Owner I need to test website for broken links

@regression
@redbridgecitycouncil
@prod
Scenario: Redbridge_02_CheckBinCollectionDays
	Given the user navigates to check your bin days page
	When the user selects an address
	Then the user should see the bin collection days
