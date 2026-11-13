using Microsoft.Playwright;
using System.Threading.Tasks;
namespace AutomationExercise.Tests.Pages
{
    public class ProductsPage
    {
        private readonly IPage _page;
        public ProductsPage(IPage page)
        {
            _page = page;
        }
        private ILocator SearchInput => _page.Locator("#search_product");
        private ILocator SearchButton => _page.Locator("#submit_search");
        private ILocator FirstAddToCartButton => _page.Locator(".productinfo a.add-to-cart").First;
        private ILocator ViewCartModalLink => _page.Locator("#cartModal a[href='/view_cart']");
        public async Task LoadAsync()
        {
            await _page.GotoAsync("https://automationexercise.com/products");
            var consentButton = _page.GetByRole(AriaRole.Button, new() { Name = "Consent" });
            try
            {
                await consentButton.WaitForAsync(new() { Timeout = 3000 });
                await consentButton.ClickAsync();
            }
            catch
            {
            }
        }
        public async Task SearchProductAsync(string productName)
        {
            await SearchInput.FillAsync(productName);
            await SearchButton.ClickAsync();
        }
        public async Task AddFirstProductAndOpenCartAsync()
        {
            await FirstAddToCartButton.ClickAsync();
            await ViewCartModalLink.ClickAsync();
        }
    }
}