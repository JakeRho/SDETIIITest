namespace SDETIIITestProject
{
    //[Test]
    //public async Task AddingPickToBetslip()
    //{
    //    // Navigatet to event page and allow it to fully render
    //    await Page.ClickAsync("text=Event View");

    //    // await Page.WaitForTimeoutAsync(3000);

    //    // Choose the first pick available on the page
    //    var homeTeamBet = Page.Locator("ms-event-pick.option-pick").First;

    //    // Compare expected pick with actual pick 
    //    var expectedSelectionName = await Page.Locator("ms-event-pick.option-pick").First.InnerTextAsync();

    //    // Remove odds information from the selection name capture
    //    expectedSelectionName = expectedSelectionName.Contains("\n") ? expectedSelectionName[..expectedSelectionName.IndexOf("\n")] : expectedSelectionName;
    //    await homeTeamBet.ClickAsync();
    //    var actualSelectionName = await Page.Locator("span.betslip-digital-pick__line-0-container").InnerTextAsync();           

    //    Assert.That(actualSelectionName, Is.EqualTo(expectedSelectionName), $"Wanted to bet on {expectedSelectionName} but the market was not available. Selection defaulted to: {actualSelectionName}");
    //    // Assert.That(expectedSelectionName, Does.Contain(actualSelectionName));

    //    await Page.Locator("span.betslip-digital-pick__line-0-container").HighlightAsync();


    //    // Highlight the pick on the betslip in bold green
    //    await Page.EvaluateAsync(@"element => {
    //                               element.style.border = '3px green';
    //                               element.style.backgroundColor = 'green';
    //                             }", await Page.Locator("span.betslip-digital-pick__line-0-container").ElementHandleAsync());

    //    // Assert that the pick on the betslip is highlighted in bold green
    //    var backgroundColor = await Page.Locator("span.betslip-digital-pick__line-0-container")
    //        .EvaluateAsync<string>("el => getComputedStyle(el).backgroundColor");
    //    Assert.That(backgroundColor, Is.EqualTo("rgb(0, 128, 0)"), "Green highlighting is missing or incorrect."); // 'green' in RGB

    //    // Close the browser
    //    await Page.CloseAsync();
    //}


    //[Test]
    //public async Task ValidatingLiveOddsUpdate()
    //{
    //    // await Page.ClickAsync("text=LIVE BETTING");
    //    await Page.ClickAsync("text=Table Tennis");

    //    await Page.WaitForTimeoutAsync(2000); // Small delay to let dynamic content settle

    //    var oddsElement = Page.Locator("div.option-indicator:visible").First;
    //    // Get initial odds (X)
    //    var initialOdds = await oddsElement.InnerTextAsync();

    //    // Handle edge case where "Set x + new line" is added to start of string
    //    initialOdds = initialOdds.Substring(initialOdds.IndexOf("\n") + 1);

    //    Console.WriteLine($"Initial odds: {initialOdds}");
    //    // Wait for the odds to change
    //    await Assertions.Expect(oddsElement).Not.ToHaveTextAsync(initialOdds, new() { Timeout = 60000 });
    //    // Get updated odds (Y)
    //    var updatedOdds = await oddsElement.InnerTextAsync();
    //    Console.WriteLine($"Updated odds: {updatedOdds}");

    //    string className = await oddsElement.GetAttributeAsync("class");

    //    Assert.IsTrue(className.Contains("increased") || className.Contains("decreased"),
    //    "Expected class to change to 'increased' or 'decreased', but it did not.");

    //    // Assert that odds changed from X to Y
    //    Assert.That(updatedOdds, Is.Not.EqualTo(initialOdds), $"Odds did not change as expected! Initial: {initialOdds}, Updated: {updatedOdds}");

    //    await Page.CloseAsync();
    //}


    //[Test]
    //public async Task SelectTennisandValidate()
    //{
    //    await Page.ClickAsync("text=A-Z Sports");
    //    await Page.ClickAsync("text=Tennis");
    //    var tennisElement = Page.Locator("div.main-items > vn-menu-item.menu-item:nth-child(5)");
    //    await Assertions.Expect(tennisElement).ToHaveClassAsync("menu-item active");
    //    await Assertions.Expect(tennisElement).ToHaveTextAsync(new Regex(".*Tennis.*"));
    //    await Assertions.Expect(Page).ToHaveURLAsync(new Regex(".*tennis.*"));



    //    await Page.CloseAsync();

    //    // Maybe explore nth-child selecting?
    //}
}
