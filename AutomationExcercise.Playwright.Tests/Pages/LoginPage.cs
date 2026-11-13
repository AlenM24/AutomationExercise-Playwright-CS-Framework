using Microsoft.Playwright;
using System.Threading.Tasks;
namespace AutomationExercise.Tests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page)
        {
            _page = page;
        }
        private ILocator LoginEmailInput => _page.Locator("[data-qa='login-email']");
        private ILocator LoginPasswordInput => _page.Locator("[data-qa='login-password']");
        private ILocator LoginButton => _page.Locator("[data-qa='login-button']");
        private ILocator ErrorMessageText => _page.Locator("form[action='/login'] p");
        public async Task LoadAsync()
        {
            await _page.GotoAsync("https://automationexercise.com/login");
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
        public async Task LoginAsync(string email, string password)
        {
            await LoginEmailInput.FillAsync(email);
            await LoginPasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }
        public async Task<string> GetErrorMessageAsync()
        {
            return await ErrorMessageText.TextContentAsync() ?? "";
        }
    }
}