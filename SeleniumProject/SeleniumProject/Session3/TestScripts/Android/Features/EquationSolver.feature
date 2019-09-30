Feature: EquationSolver


@Android
Scenario: Equation Solver - Solve first grade equation
    Given the user opens the calculator app
    When the user opens the Equation Solver menu
    And the user clicks button 'x' in Equation Solver
    And the user clicks button '+' in Equation Solver
    And the user clicks button '2' in Equation Solver
    And the user clicks button '=' in Equation Solver
    And the user clicks button '3' in Equation Solver
    And the user clicks button 'solve' in Equation Solver
    Then the result field shows 'x = 1' in Equation Solver

