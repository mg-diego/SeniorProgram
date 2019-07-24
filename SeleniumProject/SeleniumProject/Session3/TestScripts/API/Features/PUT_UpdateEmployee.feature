Feature: PUT_UpdateEmployee
	In order to test the PUT Update Employee

@api
Scenario: PUT - Update existing valid user returns success
	Given the following create employee api resource is requested
    | Resource | Value | Name    | Salary | Age |
    | Update   | POST  | test002 | 343    | 42  |
	When the following update employee api resource is requested
    | Resource | Value | Name    | Salary | Age | NewName |
    | Update   | PUT   | test002 | 434    | 41  | test003 |
	Then a response with http code '200' is received
    And the response body contains '"name":"test003","salary":"434","age":"41"'


@api
Scenario: PUT - Update non existing user returns error
	Given the following create employee api resource is requested
    | Resource | Value | Name    | Salary | Age |
    | Update   | POST  | test002 | 343    | 42  |
	When the following update employee api resource is requested
    | Resource | Value | Name      | Salary | Age | NewName |
    | Update   | PUT   | WrongUser | 434    | 41  | test003 |
	Then a response with http code '200' is received
    And the response body contains '"name":"test003","salary":"434","age":"41"'


@api
Scenario: PUT - Update empty user returns error
	Given the following create employee api resource is requested
    | Resource | Value | Name    | Salary | Age |
    | Update   | POST  | test002 | 343    | 42  |
	When the following update employee api resource is requested
    | Resource | Value | Name  | Salary | Age | NewName |
    | Update   | PUT   | Empty | 434    | 41  | test003 |
	Then a response with http code '404' is received
    And the response body contains '"message":"Not found"'