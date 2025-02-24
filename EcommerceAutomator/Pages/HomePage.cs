using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChromeSpec.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver; // restricts access outside the class and made it read only so that it cannot be modified 

        public HomePage(IWebDriver driver) // Setting a constructer object
        {
            this.driver = driver; // connectection between object and web browser 
        }

        // storing the web elements in a variable of type web element and making it private so that it won't be accessed outside

        private IWebElement PageHeading => driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[1]/div[2]/div"));

        private IWebElement SideBurgerMenuButton => driver.FindElement(By.XPath("//button[@id=\"react-burger-menu-btn\"]"));

        private IWebElement LogOutButton => driver.FindElement(By.XPath("//*[@id=\"logout_sidebar_link\"]"));

        private IWebElement ProductPage => driver.FindElement(By.XPath("//div[@class=\"inventory_item_name \"][1]"));

        private IWebElement ProductPageBackButton => driver.FindElement(By.XPath("//*[@id=\"back-to-products\"]"));

        public void WaitForElementText(IWebElement element, string expectedText, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(driver => element.Text.Contains(expectedText));
        }

        public void NavigateToProductPage()
        {
            ProductPage.Click();    
        }

        public void NavigateToHomePageFromProductPage()
        {
            ProductPageBackButton.Click();  
        }

        public void ClickSideBurgerMenuButton()
        {
            SideBurgerMenuButton.Click();
        }
        
        public void ClickLogOutButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            WaitForElementText(LogOutButton, "Logout", 3);
            LogOutButton.Click();
        }

        public String GrabHeadingText()
        {
            string x = PageHeading.Text;
            return x;
        }
    }
}
