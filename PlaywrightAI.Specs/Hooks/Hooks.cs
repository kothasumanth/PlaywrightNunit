using System.Threading.Tasks;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using PlaywrightAI.Core.Pages;

namespace PlaywrightAI.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        public static IPlaywright? PlaywrightInstance;
        public static IBrowser? BrowserInstance;
        public static IPage? PageInstance;
        public static GoogleHomePage? GoogleHomePageInstance;

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            PlaywrightInstance = Playwright.CreateAsync().GetAwaiter().GetResult();
            BrowserInstance = PlaywrightInstance.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }).GetAwaiter().GetResult();
            PageInstance = BrowserInstance.NewPageAsync().GetAwaiter().GetResult();
            GoogleHomePageInstance = new GoogleHomePage(PageInstance);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            if (BrowserInstance != null)
                BrowserInstance.CloseAsync().GetAwaiter().GetResult();
            if (PlaywrightInstance != null)
                PlaywrightInstance.Dispose();
        }
    }
}
