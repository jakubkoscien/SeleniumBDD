using OpenQA.Selenium;
using SeleniumBDD.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBDD.Pages;
public class RegistrationPage : BasePage
{
    private readonly TestSettings _settings;
    public RegistrationPage(IWebDriver driver, TestSettings settings) : base(driver) 
    {   
        _settings = settings;
    }

    private readonly By _emailInput = By.Id("");
    private readonly By _passwordInput = By.Id("");
    private readonly By _confirmPasswordInput = By.Id("");
    private readonly By _registerButton = By.CssSelector("");
    private readonly By _signInButton = By.LinkText("");
    private readonly By _backToLoginPageButton = By.LinkText("");

    public void GoToRegistrationPage() => GoToUrl(_settings.BaseUrl + "register");

}
