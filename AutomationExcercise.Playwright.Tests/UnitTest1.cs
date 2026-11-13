using AutomationExcercise.Test.Pages;
using AutomationExercise.Tests.Pages;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
namespace AutomationExercise.Tests
{
    [TestFixture]
    public class UserAccountTests : PageTest
    {
        [Test]
        public async Task Ticket1_RegisterNewUser_CreatesAccountAndLogsIn()
        {
            var signupPage = new SignupPage(Page);
            var accountCreatedPage = new AccountCreatedPage(Page);
            var navbar = new NavbarComponent(Page);
            string uniqueEmail = $"alen.qa.{DateTime.UtcNow.Ticks}@example.com";
            await signupPage.LoadAsync();
            await signupPage.StartSignupAsync("AlenQA", uniqueEmail);
            await signupPage.CompleteAccountDetailsAsync("SecurePass123!");
            Assert.That(await accountCreatedPage.IsAccountCreatedVisibleAsync(), Is.True);
            await accountCreatedPage.ClickContinueAsync();
            string loggedInStatus = await navbar.GetLoggedInTextAsync();
            Assert.That(loggedInStatus, Does.Contain("Logged in as AlenQA"));
        }
        [Test]
        public async Task Ticket2_SearchProductAndAddToCart_DisplaysAccurateCartDetails()
        {
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);
            await productsPage.LoadAsync();
            await productsPage.SearchProductAsync("Blue Top");
            await productsPage.AddFirstProductAndOpenCartAsync();
            Assert.That(await cartPage.GetProductNameAsync(), Is.EqualTo("Blue Top"));
            Assert.That(await cartPage.GetProductPriceAsync(), Is.EqualTo("Rs. 500"));
            Assert.That(await cartPage.GetProductQuantityAsync(), Is.EqualTo("1"));
        }
        [TestCase("wrong.user@example.com", "WrongPass123!")]
        [TestCase("unregistered.qa@test.co.uk", "InvalidPass99")]
        [TestCase("fake.account@domain.org", "BadPassword!")]
        public async Task Ticket3_InvalidLoginMatrix_DisplaysIncorrectCredentialsError(string email, string password)
        {
            var loginPage = new LoginPage(Page);
            await loginPage.LoadAsync();
            await loginPage.LoginAsync(email, password);
            string errorMessage = await loginPage.GetErrorMessageAsync();
            Assert.That(errorMessage, Is.EqualTo("Your email or password is incorrect!"));
        }
    }
}