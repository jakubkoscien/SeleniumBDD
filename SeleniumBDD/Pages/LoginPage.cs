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

        IWebElement EmailInput => Find(By.Id("formBasicEmail"));
        IWebElement PasswordInput => Find(By.Id("formBasicPassword"));
        IWebElement SignInButton => Find(By.CssSelector("button[type='submit']"));
        //IWebElement EmptyCredentialsMessage => Find(By.XPath());

        public void GoToLoginPage()
        {
            GoToUrl(_settings.BaseUrl + "practice-login-form");
        }

        public void EnterEmail(string email) => EnterText(EmailInput, email);

        public void EnterPassword(string email) => EnterText(PasswordInput, email);

        public void ClickSignIn() => SignInButton.Click();

        public void LoginAs(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            ClickSignIn();
        }


    }
}
