using Microsoft.Playwright;
using System.Threading.Tasks;
namespace AutomationExercise.Tests.Pages
{
    public class SignupPage
    {
        private readonly IPage _page;
        public SignupPage(IPage page)
        {
            _page = page;
        }
       
        // Initial Signup Box
        private ILocator SignupNameInput => _page.Locator("[data-qa='signup-name']");
        private ILocator SignupEmailInput => _page.Locator("[data-qa='signup-email']");
        private ILocator SignupButton => _page.Locator("[data-qa='signup-button']");
        // Account Information Form
        private ILocator GenderMrRadio => _page.Locator("#id_gender1");
        private ILocator PasswordInput => _page.Locator("[data-qa='password']");
        private ILocator FirstNameInput => _page.Locator("[data-qa='first_name']");
        private ILocator LastNameInput => _page.Locator("[data-qa='last_name']");
        private ILocator AddressInput => _page.Locator("[data-qa='address']");
        private ILocator CountryDropdown => _page.Locator("[data-qa='country']");
        private ILocator StateInput => _page.Locator("[data-qa='state']");
        private ILocator CityInput => _page.Locator("[data-qa='city']");
        private ILocator ZipcodeInput => _page.Locator("[data-qa='zipcode']");
        private ILocator MobileInput => _page.Locator("[data-qa='mobile_number']");
        private ILocator CreateAccountButton => _page.Locator("[data-qa='create-account']");
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
        public async Task StartSignupAsync(string name, string email)
        {
            await SignupNameInput.FillAsync(name);
            await SignupEmailInput.FillAsync(email);
            await SignupButton.ClickAsync();
        }
        public async Task CompleteAccountDetailsAsync(string password)
        {
            await GenderMrRadio.CheckAsync();
            await PasswordInput.FillAsync(password);
            await FirstNameInput.FillAsync("Alen");
            await LastNameInput.FillAsync("Tester");
            await AddressInput.FillAsync("123 High Street");
            await CountryDropdown.SelectOptionAsync("India");
            await StateInput.FillAsync("Greater London");
            await CityInput.FillAsync("Orpington");
            await ZipcodeInput.FillAsync("BR5 1AA");
            await MobileInput.FillAsync("07700900077");
            await CreateAccountButton.ClickAsync();
        }
    }
}