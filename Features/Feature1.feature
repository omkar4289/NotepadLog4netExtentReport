Feature: Feature1

A short summary of the feature

@tag1
Scenario: Add numbers
	Given User opened Calculator app
	When user entered first number
	And Addition performed
	And user entered second number
	Then User pressed Equals

Scenario: Subtract numbers
	Given User opened Calculator app
	When user entered first number
	And Subtraction performed
	And user entered second number
	Then User pressed Equals