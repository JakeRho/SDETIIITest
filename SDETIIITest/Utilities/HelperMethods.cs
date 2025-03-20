using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace SDETIIITestProject.Utilities
{
    public class HelperMethods : PageTest
    {
        public static async Task<ILocator?> GetFirstAvailablePickAsync(IPage page)
        {
            var picks = page.Locator("ms-event-pick.option-pick");
            var count = await picks.CountAsync();

            for (int i = 0; i < count; i++)
            {
                var pick = picks.Nth(i);

                // Look for the "option-indicator" inside the current pick
                var optionIndicator = pick.Locator("div.option-indicator");

                // Get the class attribute of the option-indicator 
                var classAttribute = await optionIndicator.GetAttributeAsync("class");

                // Skip picks where option-indicator contains "offline"
                if (classAttribute == null || !classAttribute.Contains("offline"))
                {
                    return pick; // Return the first valid pick
                }
            }

            return null; // No available picks found
        }

        public static string TrimExpectedSelectionName(string expectedSelectionName) 
        {
            string result = expectedSelectionName.Contains("\n") ?
                                    expectedSelectionName[..expectedSelectionName.IndexOf("\n")] :
                                    expectedSelectionName;
            return result;
        }
    }
}
