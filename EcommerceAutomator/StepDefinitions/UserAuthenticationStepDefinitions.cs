using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestChromeSpec.Pages;

namespace TestChromeSpec.StepDefinitions
{
    [Binding]
    public class UserAuthenticationStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;

        public UserAuthenticationStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = scenarioContext["WebDriver"] as IWebDriver;
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
        }

        [Given(@"I launch the website")]
        public void GivenIOpenABrowser()
        {
            Assert.AreEqual("Swag Labs", loginPage.Login_Page_Heading());
        }


        [When(@"I enter the user name into the text box ""([^""]*)""")]
        public void ThenITypeTheUserNameIntoTheTextBox(string username)
        {
            loginPage.EnterUserName(username);
        }

        [When(@"I enter the password into the password box ""([^""]*)""")]
        public void ThenITypeThePasswordIntoThePasswordBox(string password)
        {
            loginPage.EnterPassWord(password);
        }

        [When(@"I login")]
        public void ThenILogin()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I verify if I have logged in or not")]
        public void ThenIVerifyIfIHaveLoggedInOrNot()
        {
            Assert.AreEqual("Swag Labs", homePage.GrabHeadingText());
        }

        [Then(@"I log out and verify if I have logged out")]
        public void ThenILogOutAndVerifyIfIHaveLoggedOut()
        {
            homePage.ClickSideBurgerMenuButton();
            homePage.ClickLogOutButton();
        }

        [Then(@"I verify if I get the error message ""(.*)""")]
        public void ThenIVerifyIfIGetTheErrorMessage(string expectedErrorMessage)
        {
            string actualErrorMessage = loginPage.ErrorText();

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage,
                $"Expected: '{expectedErrorMessage}', but got: '{actualErrorMessage}'");
        }

    }
}
