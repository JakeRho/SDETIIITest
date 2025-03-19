using Microsoft.Playwright.NUnit;

namespace SDETIIITestProject

    // To make the browser headed, use "Set HEADED=1" from Developer Powershell
{
    public class NUnitPlaywright : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("http://www.eaapp.somee.com");
        }

        [Test]
        public async Task Test1()
        {
            await Page.ClickAsync("text=Login");
            await Page.FillAsync("#UserName", "admin");
            await Page.FillAsync("#Password", "password");
            await Page.ClickAsync("text=Log in");
            await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
            await Page.CloseAsync();
        }
    }
}
