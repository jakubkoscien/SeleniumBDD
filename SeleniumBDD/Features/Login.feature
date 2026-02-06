Feature: Login
  Login page functionalities and interface tests

Scenario: Login with valid credentials
    Given I am on the login page
    When I enter valid credentials "<email>" and "<password>"
    And I click the login button
    Then I should see successful login message

Examples: 
  | email                | password |
  | user@premiumbank.com | Bank@123 |
