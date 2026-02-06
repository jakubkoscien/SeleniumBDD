using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;

namespace SeleniumBDD.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        protected void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        protected IWebElement Find(By locator)
        {
            return Wait.Until(driver => driver.FindElement(locator));
        }

        protected void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        protected void WaitUntilClickable(By locator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected void WaitUntilVisible(By locator)
        {             
            Wait.Until(driver => driver.FindElement(locator).Displayed);
        }

        protected IWebElement MoveToElement(By locator)
        {
            var element = Find(locator);
            new Actions(Driver)
            .MoveToElement(element)
            .Perform();
            return element;
        }
    }
}
