Feature: Google Search
  As a web user
  I want to launch Google homepage
  So that I can verify it loads successfully

  @UI
  Scenario: Launch Google and verify title
    Given I navigate to "https://www.google.com"
    Then the page title should be "Google"

  @UI
  Scenario: Failing scenario for retry demo
    Given I navigate to "https://www.google.com"
    Then the page title should be "ThisWillFail"
