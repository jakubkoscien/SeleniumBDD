using OpenQA.Selenium;
using SeleniumBDD.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBDD.Pages;

public class LoginPage : BasePage
{
    private readonly TestSettings _settings;
    public LoginPage(IWebDriver driver, TestSettings settings) : base(driver) 
    {   
        _settings = settings;
    }

    private readonly By _emailInput = By.Id("formBasicEmail");
    private readonly By _passwordInput = By.Id("formBasicPassword");
    private readonly By _signInButton = By.CssSelector("button[type='submit']");
    private readonly By _successfulLoginMessage = By.CssSelector(".alert-success");
    private readonly By _invalidCredenialsMessage = By.CssSelector(".alert-danger");
    private readonly By _forgotPasswordLink = By.LinkText("Forgot password?");
    private readonly By _registerNowLink = By.LinkText("Register now");
    private readonly By _credentialsRequiredMessage = By.CssSelector(".alert-danger");
    private readonly By _passwordRequiredMessage = By.CssSelector(".alert-danger");

    public void GoToLoginPage() => GoToUrl(_settings.BaseUrl + "practice-login-form");

    public void ClickSignIn() => Click(_signInButton);

    public void EnterCredentials(string email, string password)
    {
        EnterText(_emailInput, email);
        EnterText(_passwordInput, password);
    }

    public void LoginAs(string email, string password)
    {
        EnterCredentials(email, password);
        ClickSignIn();
    }
    public bool IsSignInButtonEnabled() => WaitUntilEnabled(_signInButton);
    public bool IsSuccessfulLoginMessageDisplayed() => WaitUntilVisible(_successfulLoginMessage);
    public bool IsInvalidCredentialsMessageDisplayed() => WaitUntilVisible(_invalidCredenialsMessage);
    public bool IsEmailInputDisplayed() => WaitUntilVisible(_emailInput);
    public bool IsPasswordInputDisplayed() => WaitUntilVisible(_passwordInput);
    public bool IsForgotPasswordLinkDisplayed() => WaitUntilVisible(_forgotPasswordLink);
    public bool IsRegisterNowLinkDisplayed() => WaitUntilVisible(_registerNowLink);
    public bool IsSignInButtonDisplayed() => WaitUntilVisible(_signInButton);
    public bool IsCredentialsRequiredMessageDisplayed() => WaitUntilVisible(_credentialsRequiredMessage);
    public bool IsPasswordRequiredMessageDisplayed() => WaitUntilVisible(_passwordRequiredMessage);

    public bool IsPasswordInputMasked()
    {
        var element = Find(_passwordInput);
        return element.GetAttribute("type") == "password";
    }

    public string? IsInvalidEmailFormatMessageDisplayed()
    {
        var element = Find(_emailInput);
        var js = (IJavaScriptExecutor)Driver;
        return js.ExecuteScript("return arguments[0].validationMessage;", element) as string;
    }
}
