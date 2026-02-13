using SeleniumBDD.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Sources;

namespace SeleniumBDD.Steps;
public class RegistrationSteps
{
    private readonly RegistrationPage _registrationPage;
    public RegistrationSteps(RegistrationPage registrationPage)
    {
        _registrationPage = registrationPage;
    }
}
