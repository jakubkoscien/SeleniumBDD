using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;

namespace SeleniumBDD.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    }

    protected IWebElement Find(By locator)
    {
        return Wait.Until(driver => driver.FindElement(locator));
    }

    protected void GoToUrl(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    protected void EnterText(By locator, string text)
    {
        var element = Find(locator);
        element.Clear();
        element.SendKeys(text);
    }

    protected void Click(By locator)
    {
        MoveToElement(locator);
        Driver.FindElement(locator).Click();
    }

    protected void WaitUntilClickable(By locator)
    {
        Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    protected bool WaitUntilVisible(By locator)
    {             
        return Wait.Until(driver => driver.FindElement(locator).Displayed);
    }

    protected bool WaitUntilEnabled(By locator)
    {
        return Wait.Until(driver => driver.FindElement(locator).Enabled);
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
