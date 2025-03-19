using Microsoft.Playwright.NUnit;
using SDETIIITestProject.Utilities;

namespace SDETIIITestProject.Hooks
{
    public class BaseTest : PageTest  
    {
        [SetUp]
        public async Task Setup()
        {
            // Navigate to bwin.sports home page
            await Page.GotoAsync("https://sports.bwin.com/en/sports/live/betting");

            await Page.WaitForTimeoutAsync(2000); // Small delay to let dynamic content settle

            // Dismiss cookie banner if it appears
            await HelperMethods.DismissCookieBanner(Page);
        }

        [TearDown]
        public async Task TearDown()
        {
            if (Page != null)
            {
                await Page.CloseAsync(); 
            }
        }
    }
}
