using Microsoft.Playwright;
using System.Threading.Tasks;
namespace AutomationExercise.Tests.Pages
{
    public class AccountCreatedPage
    {
        private readonly IPage _page;
        public AccountCreatedPage(IPage page)
        {
            _page = page;
        }
        private ILocator AccountCreatedHeader => _page.Locator("[data-qa='account-created']");
        private ILocator ContinueButton => _page.Locator("[data-qa='continue-button']");
        public async Task<bool> IsAccountCreatedVisibleAsync()
        {
            return await AccountCreatedHeader.IsVisibleAsync();
        }
        public async Task ClickContinueAsync()
        {
            await ContinueButton.ClickAsync();
        }
    }
}