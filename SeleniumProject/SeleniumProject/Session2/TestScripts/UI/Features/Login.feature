Feature: Login
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Chrome
Scenario: Chrome: Valid Login
	Given the user enters valid username
	And the user enters valid password
	When the user clicks submit
    Then the user can login
