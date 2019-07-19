Feature: NewCustomer
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Chrome
Scenario: Chrome: Create new valid user
	Given a user login into Guru99
    And the user opens the New Customer tab
	And the user enters valid data for new customer
	When the user clicks on submit new customer
	Then the new customer is created

@Chrome
Scenario: Chrome: Cant create two duplicated users
    Given a user login into Guru99
    And a new valid user is created
    And the user opens the New Customer tab
	And the user enters valid data for new customer
	When the user clicks on submit new customer
	Then the new customer is not created