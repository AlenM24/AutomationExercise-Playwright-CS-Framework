using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Text.Json;
using System.Threading.Tasks;
namespace AutomationExercise.Tests
{
    [TestFixture]
    public class ApiTests : PlaywrightTest
    {
        [Test]
        public async Task Ticket4A_GetAllProductsList_Returns200AndProducts()
        {
            var requestContext = await Playwright.APIRequest.NewContextAsync();
            var response = await requestContext.GetAsync("https://automationexercise.com/api/productsList");
            Assert.That(response.Status, Is.EqualTo(200));
            string rawBody = await response.TextAsync();
            using JsonDocument doc = JsonDocument.Parse(rawBody);
            int responseCode = doc.RootElement.GetProperty("responseCode").GetInt32();
            int productCount = doc.RootElement.GetProperty("products").GetArrayLength();
            Assert.That(responseCode, Is.EqualTo(200));
            Assert.That(productCount, Is.GreaterThan(0));
        }
        [Test]
        public async Task Ticket4B_SearchProductApi_ReturnsMatchingItems()
        {
            var requestContext = await Playwright.APIRequest.NewContextAsync();
            //Creates an empty form container simulating a HTML form subnission
            var formData = requestContext.CreateFormData();
            formData.Set("search_product", "top");
            //Sends an HTTP POST request to the search endpoint and attaches the form data payload
            var response = await requestContext.PostAsync(
            "https://automationexercise.com/api/searchProduct",
            new APIRequestContextOptions { Form = formData }
            );
            Assert.That(response.Status, Is.EqualTo(200));
            string rawBody = await response.TextAsync();
            using JsonDocument doc = JsonDocument.Parse(rawBody);
            int responseCode = doc.RootElement.GetProperty("responseCode").GetInt32();
            int matchingProducts = doc.RootElement.GetProperty("products").GetArrayLength();
            Assert.That(responseCode, Is.EqualTo(200));
            Assert.That(matchingProducts, Is.GreaterThan(0));
        }
    }
}