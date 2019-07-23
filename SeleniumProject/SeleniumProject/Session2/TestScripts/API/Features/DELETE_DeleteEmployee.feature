Feature: DELETE_DeleteEmployee
	In order to test DELETE Api functionality

@api
Scenario: DELETE - Delete existin user returns success
	Given the following create employee api resource is requested
    | Resource | Value | Name    | Salary | Age |
    | Create   | POST  | test002 | 343    | 42  |
	When the following delete employee api resource is requested
    | Resource | Value  | Name    |
    | Delete   | DELETE | test002 |
    Then a response with http code '200' is received
    Then the response body contains '"text":"successfully! deleted Records"'
