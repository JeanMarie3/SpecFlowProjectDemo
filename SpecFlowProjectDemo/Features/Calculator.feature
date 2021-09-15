Feature: Automate Calculator in Windows 10

Test objectives:
1. Create a Visual Studio solution to automate some scenarios in Windows 10 Calculator.
2. Use SpecFlow plugin and Microsoft UI Automation API to create test cases:

    @mytag
Scenario: Automate programmer mode
Given Launch calc
	And I navigate to programmer mode
	When I enter a value
	Then I verify HEX value is correct
	And I verify DEC value is correct
	And I verify OCT value is correct
	And I verify BIN value is correct
	And close calc


	@mytag
Scenario: Automate scientific mode
Given Launch calc
	And I navigate to scientific mode
	When perform some calculations
	Then verify the results
	And close calc


	@mytag
Scenario: Automate date calculation mode
Given Launch calc
	And I navigate to date calculation mode
	When enter dates
	Then verify day results
	And verify week results 
	And close calc


	@mytag
Scenario: Automate standard mode
Given Launch calc
	And I navigate to standard mode
	When perform some calculations for standard
	Then verify the results for standard
	And cancel
	And retrieve
	And validate from history
	And Verify some memory additional and retrieval
	And close calc