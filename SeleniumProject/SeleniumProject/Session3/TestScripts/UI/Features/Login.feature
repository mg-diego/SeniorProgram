Feature: Login
    In order to test the Login functionality

@Chrome
Scenario: Chrome: Valid Login
	Given the user enters valid username
	And the user enters valid password
	When the user clicks submit
    Then the user can login
