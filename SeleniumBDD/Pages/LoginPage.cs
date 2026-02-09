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

    private readonly By EmailInput = By.Id("formBasicEmail");
    private readonly By PasswordInput = By.Id("formBasicPassword");
    private readonly By SignInButton = By.CssSelector("button[type='submit']");
    private readonly By SuccessfulLoginMessage = By.CssSelector(".alert-success");
    private readonly By InvalidCredenialsMessage = By.CssSelector(".alert-danger");
    private readonly By ForgotPasswordLink = By.LinkText("Forgot password?");
    private readonly By RegisterNowLink = By.LinkText("Register now");
    private readonly By CredentialsRequiredMessage = By.CssSelector(".alert-danger");
    private readonly By PasswordRequiredMessage = By.CssSelector(".alert-danger");

    public void GoToLoginPage() => GoToUrl(_settings.BaseUrl + "practice-login-form");

    public void ClickSignIn()
    {
        Click(SignInButton);
    }

    public void EnterCredentials(string email, string password)
    {
        EnterText(EmailInput, email);
        EnterText(PasswordInput, password);
    }

    public void LoginAs(string email, string password)
    {
        EnterCredentials(email, password);
        ClickSignIn();
    }

    public bool IsLoginSuccessful()
    {
        return WaitUntilVisible(SuccessfulLoginMessage); 
    }

    public bool IsInvalidCredentialsMessageDisplayed()
    {
        return WaitUntilVisible(InvalidCredenialsMessage);
    }

    public bool IsEmailInputDisplayed()
    {
        return WaitUntilVisible(EmailInput);
    }

    public bool IsPasswordInputDisplayed()
    {
        return WaitUntilVisible(PasswordInput);
    }

    public bool IsForgotPasswordLinkDisplayed()
    {
        return WaitUntilVisible(ForgotPasswordLink);
    }

    public bool IsRegisterNowLinkDisplayed()
    {
        return WaitUntilVisible(RegisterNowLink);
    }

    public bool IsSignInButtonDisplayed()
    {
        return WaitUntilVisible(SignInButton);
    }

    public bool IsCredentialsRequiredMessageDisplayed()
    {
        return WaitUntilVisible(CredentialsRequiredMessage);
    }

    public bool IsPasswordRequiredMessageDisplayed()
    {
        return WaitUntilVisible(PasswordRequiredMessage);
    }

    public bool IsSignInButtonEnabled()
    {
        return WaitUntilEnabled(SignInButton);
    }

    public bool IsPasswordInputMasked()
    {
        var element = Find(PasswordInput);
        return element.GetAttribute("type") == "password";
    }

    public string? IsInvalidEmailFormatMessageDisplayed()
    {
        var element = Find(EmailInput);
        var js = (IJavaScriptExecutor)Driver;
        return js.ExecuteScript("return arguments[0].validationMessage;", element) as string;
    }
}
