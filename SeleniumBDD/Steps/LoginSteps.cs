using NUnit.Framework;
using Reqnroll;
using SeleniumBDD.Pages;
using System;

namespace SeleniumBDD.Steps
{
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
        public void WhenIEnterValidCredentials(string email, string password)
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
    }
}