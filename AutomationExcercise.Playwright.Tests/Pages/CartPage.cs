using Microsoft.Playwright;
using System.Threading.Tasks;


namespace AutomationExcercise.Test.Pages
{
    public class CartPage
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
            
        }
        private ILocator ProductNameCell => _page.Locator(".cart_description h4 a");
        private ILocator ProductPriceCell => _page.Locator(".cart_price p");
        private ILocator ProductQuantityButton => _page.Locator(".cart_quantity button");
        public async Task<string> GetProductNameAsync()
        {
            return await ProductNameCell.TextContentAsync() ?? "";
        }
        public async Task<string> GetProductPriceAsync()
        {
            return await ProductPriceCell.TextContentAsync() ?? "";
        }
        public async Task<string> GetProductQuantityAsync()
        {
            return await ProductQuantityButton.TextContentAsync() ?? "";
        }
    }
}
    
