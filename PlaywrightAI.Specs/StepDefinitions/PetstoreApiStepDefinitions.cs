using System.Net.Http;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace PetstoreApiTests.Steps
{
    // This class contains step definitions for API scenarios using HttpClient.
    // It logs request/response details and asserts status/content for API tests tagged @API.
    [Binding]
    public class PetstoreApiStepDefinitions
    {
        // Stores the HTTP response for each scenario
        private HttpResponseMessage? _response;

        // Step: Send a GET request to the given endpoint and log status
        [Given(@"I send a GET request to ""(.*)""")]
        public async Task GivenISendAGetRequestTo(string endpoint)
        {
            Console.WriteLine($"[API] Sending GET request to: {endpoint}");
            using var client = new HttpClient { BaseAddress = new Uri("https://petstore.swagger.io/v2") };
            _response = await client.GetAsync(endpoint);
            Console.WriteLine($"[API] Received response. Status code: {_response?.StatusCode}");
        }

        // Step: Assert the response status code and log the check
        [Then(@"the response status code should be (\d+)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.IsNotNull(_response);
            if (_response != null)
            {
                Console.WriteLine($"[API] Asserting status code. Expected: {statusCode}, Actual: {(int)_response.StatusCode}");
                Assert.AreEqual(statusCode, (int)_response.StatusCode);
            }
        }

        // Step: Assert the response contains expected text and log a snippet
        [Then(@"the response should contain ""(.*)""")]
        public async Task ThenTheResponseShouldContain(string expected)
        {
            Assert.IsNotNull(_response);
            if (_response != null)
            {
                var content = await _response.Content.ReadAsStringAsync();
                Console.WriteLine($"[API] Response content: {content.Substring(0, Math.Min(200, content.Length))}...");
                Assert.IsTrue(content.Contains(expected));
            }
        }
    }
}