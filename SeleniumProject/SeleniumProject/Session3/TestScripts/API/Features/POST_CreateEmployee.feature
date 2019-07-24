Feature: POST_CreateEmployee
	In order to test the POST Create Employee functionality

@api
Scenario: POST - Create new user returns success
	Given the following create employee api resource is requested
    | Resource | Value | Name    | Salary | Age |
    | Create   | POST  | test002 | 343    | 42  |
	Then a response with http code '200' is received
    And the response body contains '"name":"test002","salary":"343","age":"42"'


@api
Scenario: POST - Cant create a duplicated user
	Given the following create employee api resource is requested
    | Resource | Value | Name    | Salary | Age |
    | Create   | POST  | test002 | 343    | 42  |
	Given the following create employee api resource is requested
    | Resource | Value | Name    | Salary | Age |
    | Create   | POST  | test002 | 343    | 42  |
	Then a response with http code '200' is received
    And the response body contains 'Duplicate entry 'test002' for key 'employee_name_unique''