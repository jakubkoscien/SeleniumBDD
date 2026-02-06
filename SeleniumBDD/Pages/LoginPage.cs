using OpenQA.Selenium;
using SeleniumBDD.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBDD.Pages
{
    public class LoginPage : BasePage
    {
        private readonly TestSettings _settings;
        public LoginPage(IWebDriver driver, TestSettings settings) : base(driver) 
        {   
            _settings = settings;
        }

        By EmailInput => By.Id("formBasicEmail");
        By PasswordInput => By.Id("formBasicPassword");
        By SignInButton => By.CssSelector("button[type='submit']");
        By SuccessfulLoginMessage => By.CssSelector(".alert-success");

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
    }
}
