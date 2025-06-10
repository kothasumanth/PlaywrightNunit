using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;
using PlaywrightAI.Core.Pages;

namespace PlaywrightAI.Specs.StepDefinitions
{
    // This class contains step definitions for UI scenarios (Google, Amazon) using Playwright.
    // It manages browser lifecycle per scenario for safe parallel execution and only launches the browser for @UI-tagged scenarios.
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        // Playwright and browser objects for each scenario
        private IPlaywright? _playwright;
        private IBrowser? _browser;
        private IPage? _page;
        private GoogleHomePage? _googleHomePage;

        // Before each scenario, launch browser only if scenario is tagged @UI
        [BeforeScenario]
        public async Task BeforeScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext.ScenarioInfo.Tags.Contains("UI"))
            {
                _playwright = await Playwright.CreateAsync();
                _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
                _page = await _browser.NewPageAsync();
                _googleHomePage = new GoogleHomePage(_page);
            }
        }

        // After each scenario, close browser if it was launched
        [AfterScenario]
        public async Task AfterScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext.ScenarioInfo.Tags.Contains("UI"))
            {
                if (_browser != null)
                    await _browser.CloseAsync();
                if (_playwright != null)
                    _playwright.Dispose();
            }
        }

        // Step: Navigate to a URL and log the page title
        [Given(@"I navigate to ""(.*)""")]
        public async Task GivenINavigateTo(string url)
        {
            if (_googleHomePage != null)
            {
                await _googleHomePage.NavigateAsync(url);
                var title = await _googleHomePage.GetTitleAsync();
                Console.WriteLine($"[Playwright] Browser opened. Page title: {title}");
            }
        }

        // Step: Assert the page title
        [Then(@"the page title should be ""(.*)""")]
        public async Task ThenThePageTitleShouldBe(string expectedTitle)
        {
            if (_googleHomePage != null)
            {
                var title = await _googleHomePage.GetTitleAsync();
                Assert.AreEqual(expectedTitle, title);
            }
        }
    }
}
