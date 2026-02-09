Feature: Login
  Login page functionalities and interface tests

    @Basic
    Scenario: Login with valid credentials
        Given I am on the login page
        When I enter valid credentials "<email>" and "<password>"
        And I click the login button
        Then I should see successful login message

    Examples: 
      | email                | password |
      | user@premiumbank.com | Bank@123 |

    @Basic
    Scenario: Login with invalid credentials
        Given I am on the login page
        When I enter valid credentials "<email>" and "<password>"
        And I click the login button
        Then I should see invalid credentials message

    Examples: 
      | email                | password  |
      | invalid@invalid.com  | WrongPass |

    @Basic
    Scenario: All UI elements should be displayed properly
        Given I am on the login page
        Then I should see Login Page UI elements

    @Basic
    Scenario: Login button should be enabled and validate error message when fields are empty displayed
        Given I am on the login page
        Then I should see login button enabled
        When I click the login button
	    Then I should see error message for empty fields

    @Basic
    Scenario: Password field should be masked
        Given I am on the login page
	    When I enter valid credentials "<email>" and "<password>"
	    Then I should see password field is masked
    
    Examples: 
    | email                | password |
    | user@premiumbank.com | Bank@123 |

    @Basic
    Scenario: When email is entered but password field is empty error message should be displayed
        Given I am on the login page
        When I enter valid credentials "<email>" and ""
        And I click the login button
	    Then I should see error message for empty password field

    Examples: 
    | email                     |
    | user@premiumbank.com      |

    @Basic
    Scenario: When email input is in invalid format html5 validation should be triggered
        Given I am on the login page
        When I enter invalid email format "<email>" and ""
        And I click the login button
	    Then I should see HTML5 validation message for invalid email format

    Examples: 
    | email                     |
    | userpremiumbank.com      |