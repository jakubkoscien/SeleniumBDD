Feature: Registration page tests
  Registration page functionalities and interface tests
	
	@Basic
	Scenario: Registration with valid credentials
		Given I am on the registration page
		When I enter valid credentials "<email>" and "<password>" and "<confirmPassword>"
		And I click the register button
		Then I should see successful registration message
	Examples: 
	  | email                | password | confirmPassword |
	  | newuser@user.com     | Pass@123 | Pass@123        |
	
	@Basic
	Scenario: Verify validation for error message when Email Address left blank
		Given I am on the registration page
		When I leave email field empty "" and enter "<password>" and "<confirmPassword>"
		And I click the register button
		Then I should see error message for empty email field


	@Basic
	Scenario: Verify validation for error message when Password left blank
	Given I am on the registration page
		When I enter valid email "<email>" and leave password field empty "" and enter "<confirmPassword>"
		And I click the register button
		Then I should see error message for empty password field

	@Basic
	Scenario: Verify validation for error message when Confirm Password left blank
		Given I am on the registration page
		When I enter valid email "<email>" and enter valid password "<password>" and leave confirm password field empty ""
		And I click the register button
		Then I should see error message for empty confirm password field

