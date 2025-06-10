Feature: Petstore API
  As an API user
  I want to fetch pet details by ID
  So that I can verify the API returns correct data

  @API
  Scenario: Get pet details by ID
    Given I send a GET request to "/pet/1"
    Then the response status code should be 200
    And the response should contain "doggie"
