using Microsoft.Playwright;
using System.Text.RegularExpressions;
using SDETIIITestProject.Utilities;
using SDETIIITestProject.Hooks;

namespace SDETIIITestProject
{
    public class AutomationTasks : BaseTest
    {
        [Test]
        public async Task AddingPickToBetslip()
        {
            // Navigate to event page and allow it to fully render
            await Page.ClickAsync("text=Event View");

            // Wait for the event picks to load
            await Page.WaitForSelectorAsync("ms-event-pick.option-pick");

            // Find a valid pick
            var validPick = await HelperMethods.GetFirstAvailablePickAsync(Page);

            // Get the expected selection name (without odds)
            var expectedSelectionName = await validPick.InnerTextAsync();
            expectedSelectionName = HelperMethods.TrimExpectedSelectionName(expectedSelectionName);

            // Click the valid pick
            await validPick.ClickAsync();

            // Validate that the correct pick appears in the bet slip
            var actualSelectionName = await Page.Locator("span.betslip-digital-pick__line-0-container").InnerTextAsync();

            // Highlight the pick on the betslip in bold green
            await Page.EvaluateAsync(@"element => {
                                           element.style.border = '3px green';
                                           element.style.backgroundColor = 'green';
                                         }", await Page.Locator("span.betslip-digital-pick__line-0-container").ElementHandleAsync());

            // Verify highlighting
            var backgroundColor = await Page.Locator("span.betslip-digital-pick__line-0-container")
                .EvaluateAsync<string>("el => getComputedStyle(el).backgroundColor");

            Assert.That(validPick, Is.Not.Null, "No valid picks were found!");
            Assert.That(backgroundColor, Is.EqualTo("rgb(0, 128, 0)"), "Green highlighting is missing or incorrect.");
            Assert.That(actualSelectionName, Is.EqualTo(expectedSelectionName),
            $"Wanted to bet on {expectedSelectionName} but the market was not available. Suggested selection defaulted to: {actualSelectionName}");
        }

        [Test]
        public async Task ValidatingLiveOddsUpdate()
        {
            // await Page.ClickAsync("text=LIVE BETTING");
            await Page.ClickAsync("text=Table Tennis");

            await Page.WaitForTimeoutAsync(2000); // Small delay to let dynamic content settle

            var oddsElement = Page.Locator("div.option-indicator:visible").First;
            // Get initial odds (X)
            var initialOdds = await oddsElement.InnerTextAsync();

            // Handle edge case where "Set x + new line" is added to start of string
            initialOdds = initialOdds.Substring(initialOdds.IndexOf("\n") + 1);

            Console.WriteLine($"Initial odds: {initialOdds}");
            // Wait for the odds to change
            await Assertions.Expect(oddsElement).Not.ToHaveTextAsync(initialOdds, new() { Timeout = 60000 });
            // Get updated odds (Y)
            var updatedOdds = await oddsElement.InnerTextAsync();
            Console.WriteLine($"Updated odds: {updatedOdds}");

            string className = await oddsElement.GetAttributeAsync("class");

            Assert.IsTrue(className.Contains("increased") || className.Contains("decreased"),
            "Expected class to change to 'increased' or 'decreased', but it did not.");

            // Assert that odds changed from X to Y
            Assert.That(updatedOdds, Is.Not.EqualTo(initialOdds), $"Odds did not change as expected! Initial: {initialOdds}, Updated: {updatedOdds}");
        }

        [Test]
        public async Task SelectTennisandValidate()
        {         
            await Page.ClickAsync("text=A-Z Sports");
            await Page.ClickAsync("text=Tennis");
            var tennisElement = Page.Locator("div.main-items > vn-menu-item.menu-item:nth-child(5)");
            await Assertions.Expect(tennisElement).ToHaveClassAsync("menu-item active");
            await Assertions.Expect(tennisElement).ToHaveTextAsync(new Regex(".*Tennis.*"));
            await Assertions.Expect(Page).ToHaveURLAsync(new Regex(".*tennis.*"));
        }
    }
}
