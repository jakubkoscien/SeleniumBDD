using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;
using SeleniumBDD.Config;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;
namespace SeleniumBDD.DI;

	[Binding]
	public class Hooks
	{
    [AfterScenario]
    public void Cleanup(IWebDriver driver)
    {
        driver.Quit();
    }

}