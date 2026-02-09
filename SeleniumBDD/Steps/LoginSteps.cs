using NUnit.Framework;
using Reqnroll;
using SeleniumBDD.Pages;
using System;

namespace SeleniumBDD.Steps;

[Binding]
public class LoginSteps
{
    private readonly LoginPage _loginPage;

    public LoginSteps(LoginPage loginPage)
    {
        _loginPage = loginPage;
    }

    [Given("I am on the login page")]
    public void GivenIAmOnTheLoginPage()
    {
        _loginPage.GoToLoginPage();
    }

    [When("I enter valid credentials {string} and {string}")]
    [When("I enter invalid credentials {string} and {string}")]
    [When("I enter invalid email format {string} and {string}")]
    public void WhenIEnterCredentials(string email, string password)
    {
        _loginPage.EnterCredentials(email, password);
    }

    [When("I click the login button")]
    public void WhenIClickTheLoginButton()
    {
        _loginPage.ClickSignIn();
    }

    [Then("I should see successful login message")]
    public void ThenIShouldSeeSuccessfulLoginMessage()
    {
        Assert.That(_loginPage.IsLoginSuccessful(), "Login was successful");
    }

    [Then("I should see invalid credentials message")]
    public void ThenIShouldSeeInvalidCredentialsMessage()
    {
        Assert.That(_loginPage.IsInvalidCredentialsMessageDisplayed(), "Invalid credentials message is displayed");
    }

    [Then("I should see Login Page UI elements")]
    public void ThenIShouldSeeLoginPageUIElements()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_loginPage.IsEmailInputDisplayed(), "Email input is displayed");
            Assert.That(_loginPage.IsPasswordInputDisplayed(), "Password input is displayed");
            Assert.That(_loginPage.IsSignInButtonDisplayed(), "Sign in button is displayed");
            Assert.That(_loginPage.IsForgotPasswordLinkDisplayed(), "Forgot password link is displayed");
            Assert.That(_loginPage.IsRegisterNowLinkDisplayed(), "Register now link is displayed");
        });
    }

    [Then("I should see login button enabled")]
    public void ThenIShouldSeeLoginButtonEnabled()
    {
        Assert.That(_loginPage.IsSignInButtonEnabled(), "Sign in button is enabled");
    }

    [Then("I should see error message for empty fields")]
    public void ThenIShouldSeeErrorMessageForEmptyFields()
    {
        Assert.That(_loginPage.IsCredentialsRequiredMessageDisplayed(), "Error message for empty fields is displayed");
    }

    [Then("I should see password field is masked")]
    public void ThenIShouldSeePasswordFieldIsMasked()
    {
        Assert.That(_loginPage.IsPasswordInputMasked(), "Password field is masked");
    }

    [Then("I should see error message for empty password field")]
    public void ThenIShouldSeeErrorMessageForEmptyPasswordField()
    {
        Assert.That(_loginPage.IsPasswordRequiredMessageDisplayed(), "Error message for empty password field is displayed");
    }
    [Then("I should see HTML5 validation message for invalid email format")]
    public void ThenIShouldSeeHTML5ValidationMessageForInvalidEmailFormat()
    {
        var message = _loginPage.IsInvalidEmailFormatMessageDisplayed();
        Assert.That(message != null && message.Contains('@'), "HTML5 validation message for invalid email format is displayed");
    }
}