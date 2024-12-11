using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace NobelPrizeApp.Tests
{
    public class LaureatesTests
    {
        [Fact]
        public async Task SearchLaureates_ShouldDisplayResults()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            // Navigate to the application
            await page.GotoAsync("http://localhost:5000/laureates");

            // Wait for the page to load
            await page.WaitForSelectorAsync("input[placeholder='Search laureates...']");

            // Enter a search term
            await page.FillAsync("input[placeholder='Search laureates...']", "Einstein");

            // Wait for the results to update
            await page.WaitForTimeoutAsync(1000); // Adjust the timeout as needed

            // Verify that the results contain the search term
            var results = await page.QuerySelectorAllAsync("li");
            Assert.NotEmpty(results);

            foreach (var result in results)
            {
                var textContent = await result.TextContentAsync();
                Assert.Contains("Einstein", textContent, System.StringComparison.OrdinalIgnoreCase);
            }

            await browser.CloseAsync();
        }

        [Fact]
        public async Task SearchLaureates_ShouldDisplayNoResultsForInvalidTerm()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            // Navigate to the application
            await page.GotoAsync("http://localhost:5000/laureates");

            // Wait for the page to load
            await page.WaitForSelectorAsync("input[placeholder='Search laureates...']");

            // Enter an invalid search term
            await page.FillAsync("input[placeholder='Search laureates...']", "InvalidTerm");

            // Wait for the results to update
            await page.WaitForTimeoutAsync(1000); // Adjust the timeout as needed

            // Verify that no results are displayed
            var results = await page.QuerySelectorAllAsync("li");
            Assert.Empty(results);

            await browser.CloseAsync();
        }
    }
}