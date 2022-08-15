Feature: Toyota_01_BookTestDrive

@booktestdrive
Scenario: User books Test drive
	Given A user wants to book a test drive
	When the user selects a car from new vehicle 
	Then the user is taken to Book a test drive page
	And All New Aygo X should be pre selected
