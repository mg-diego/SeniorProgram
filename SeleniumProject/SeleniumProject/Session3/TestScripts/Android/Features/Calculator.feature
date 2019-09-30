Feature: Calculator


@Android
Scenario: Calculator - Multiply values
    Given the user opens the calculator app
    When the user clicks button '7' in Basic Calculator
    When the user clicks button 'x' in Basic Calculator
    When the user clicks button '8' in Basic Calculator
    When the user clicks button '=' in Basic Calculator
    Then the result field shows '56' in Basic Calculator

@Android
Scenario: Calculator - Add values
    Given the user opens the calculator app
    When the user clicks button '3' in Basic Calculator
    When the user clicks button '+' in Basic Calculator
    When the user clicks button '8' in Basic Calculator
    When the user clicks button '=' in Basic Calculator
    Then the result field shows '11' in Basic Calculator

@Android
Scenario: Calculator - Substract values
    Given the user opens the calculator app
    When the user clicks button '3' in Basic Calculator
    When the user clicks button '-' in Basic Calculator
    When the user clicks button '4' in Basic Calculator
    When the user clicks button '=' in Basic Calculator
    Then the result field shows '-1' in Basic Calculator

@Android
Scenario: Calculator - Divide values
    Given the user opens the calculator app
    When the user clicks button '6' in Basic Calculator
    When the user clicks button '÷' in Basic Calculator
    When the user clicks button '3' in Basic Calculator
    When the user clicks button '=' in Basic Calculator
    Then the result field shows '2' in Basic Calculator


