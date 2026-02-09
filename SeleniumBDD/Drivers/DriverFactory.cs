using Microsoft.Extensions.Options;
using Microsoft.Testing.Platform.CommandLine;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumBDD.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBDD.Drivers;

public interface IDriverFactory
{
    IWebDriver Create();
}

public class DriverFactory : IDriverFactory
{
    private readonly TestSettings _settings;
    public DriverFactory(TestSettings settings)
    {
        _settings = settings;
    }

    public IWebDriver Create()
    {
        return _settings.Browser?.ToLower() switch
        {
            "chrome" => CreateChrome(),
            "firefox" => CreateFirefox(),
            _ => throw new ArgumentException($"Unsupported browser: {_settings.Browser}")
        };
    }

    private IWebDriver CreateChrome()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        return new ChromeDriver(options);
    }

    private IWebDriver CreateFirefox()
    {
        var options = new FirefoxOptions();
        return new FirefoxDriver(options);
    }
}
