Feature: Calculator


Scenario: Manipulations with Test Stack White with Calculator
	Given the calculator is opened 
	When user enteres 12
	And user clicks on the + button
	And user enteres 999
	And user clicks on the = button
	Then the result should be 1011
	When user clicks on the M+ button
	And user enteres 19
	And user clicks on the + button
	And user clicks on the MR button
	And user clicks on the = button
	Then the result should be 1030