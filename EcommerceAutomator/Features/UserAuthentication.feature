Feature: UserAuthentication

A short summary of the feature

@loginfeature
Scenario: Valid Login
    Given I launch the website
    When I enter the user name into the text box "standard_user"
    And I enter the password into the password box "secret_sauce"
    And I login
    Then I verify if I have logged in or not
    Then I log out and verify if I have logged out

@loginfeature
  Scenario Outline: Login with different user credentials
    Given I launch the website
    When I enter the user name into the text box "<username>"
    And I enter the password into the password box "<password>"
    And I login
    Then I verify if I get the error message "<error_message>"

    Examples:
      | username        | password       | error_message                                                   |
      | only_username_entered   |               | Epic sadface: Password is required                             |
      |                | only_password_entered    | Epic sadface: Username is required                             |
      | wrong_user      | wrong_password | Epic sadface: Username and password do not match any user in this service      |
      | locked_out_user | secret_sauce   | Epic sadface: Sorry, this user has been locked out.             |

