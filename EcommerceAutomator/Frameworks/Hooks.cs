using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Security.Policy;
using TechTalk.SpecFlow;
using TestChromeSpec.Pages;

namespace TestChromeSpec.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        private readonly LoginPage loginPage;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string browser = _scenarioContext.ScenarioContainer.Resolve<TestContext>().Properties["Browser"]?.ToString() ?? "chrome";
            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException($"Browser not supported: {browser}");
            }
            driver.Manage().Window.Maximize();
            _scenarioContext["WebDriver"] = driver;
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
