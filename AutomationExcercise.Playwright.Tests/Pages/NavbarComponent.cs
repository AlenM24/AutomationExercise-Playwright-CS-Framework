using Microsoft.Playwright;
using System.Threading.Tasks;
namespace AutomationExercise.Tests.Pages
{
    public class NavbarComponent
    {
        private readonly IPage _page;
        public NavbarComponent(IPage page)
        {
            _page = page;
        }
        private ILocator LoggedInBanner => _page.Locator("a:has-text('Logged in as')");
        private ILocator ProductsLink => _page.Locator("a[href='/products']");
        //private ILocator CartLink => _page.Locator("a[href='/view_cart']");
        public async Task<string> GetLoggedInTextAsync()
        {
            return await LoggedInBanner.TextContentAsync() ?? "";
        }
        public async Task GoToProductsAsync()
        {
            await ProductsLink.ClickAsync();
        }
    }
}