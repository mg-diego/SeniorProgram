Feature: GET_Employee
	In order to test the GET Employee functionality

@api
Scenario: GET - Employees returns all employees
	Given '28' users are inserted into database
	When the following employees api resource is requested
    | Resource  | Value |
    | Employees | GET   |
	Then a response with http code '200' is received
    And the response body contains 'id' exactly '28' times

@api
Scenario: GET - Employee returns valid info for a concrete employee
	Given the following users are inserted into the database
    | Name | Salary | Age |
    | rss  | 343    | 43  |
	When the following employee api resource is requested
    | Resource | Value | Name |
    | Employee | GET   | rss  |
	Then a response with http code '200' is received
    And the response body contains '"employee_name":"rss"'
    And the response body contains '"employee_salary":"343"'
    And the response body contains '"employee_age":"43"'

@api
Scenario: GET - Employee returns false for invalid user
	When the following employee api resource is requested
    | Resource | Value | Name      |
    | Employee | GET   | WrongUser |
	Then a response with http code '200' is received
    And the response body contains 'false'

@api
Scenario: GET - Employee returns error for empty user
	When the following employee api resource is requested
    | Resource | Value | Name  |
    | Employee | GET   | Empty |
	Then a response with http code '404' is received
    And the response body contains '"message":"Not found"'

