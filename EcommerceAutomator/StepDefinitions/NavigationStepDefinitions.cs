using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TestChromeSpec.Pages;

namespace EcommerceAutomator.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        private readonly HomePage homePage;
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;

        public NavigationStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = scenarioContext["WebDriver"] as IWebDriver;
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            homePage = new HomePage(driver);
        }

        [Given(@"I am a valid User")]
        public void GivenIAmAValidUser()
        {
            loginPage.EnterUserName("standard_user");
            loginPage.EnterPassWord("secret_sauce");
            loginPage.ClickLoginButton();
        }

        [When(@"I Navigate to each and every product page")]
        public void WhenINavigateToEachAndEveryProductPage()
        {
            homePage.NavigateToProductPage();
        }

        [When(@"I return back to the home page")]
        public void WhenIReturnBackToTheHomePage()
        {
            homePage.NavigateToHomePageFromProductPage();
        }
    }
}
