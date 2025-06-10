Feature: Amazon Navigation
  As a web user
  I want to launch Amazon homepage
  So that I can verify it loads successfully

  @UI
  Scenario: Launch Amazon and verify title
    Given I navigate to "https://www.amazon.com"
    Then the page title should be "Amazon.com. Spend less. Smile more."
