using AutomationProject.Session1.Contracts.Pages;
using TechTalk.SpecFlow;
using Unity.Resolution;
using System.Configuration;
using AutomationProject.Session1.Containers;

namespace AutomationProject.Session1.TestScripts.Steps
{
    [Binding]
    public class LoginSteps : StepBase
    {
        /// <summary>
        /// Instantiates the login page interface
        /// </summary>
        private readonly ILoginPage loginPage;

        /// <summary>
        /// Instantiates the driver for use
        /// </summary>
        public LoginSteps()
        {
            loginPage = ContainerDependencies.Container.Resolve(typeof(ILoginPage), null,
                new ParameterOverride("driver", Driver)) as ILoginPage;
        }

        [Given(@"the user enters valid username")]
        public void GivenTheUserEntersValidUsername()
        {
            loginPage.EnterUserName(ConfigurationManager.AppSettings["UserName"]);
        }

        [Given(@"a user login into Guru99")]
        public void GivenAValidLogin()
        {
            GivenTheUserEntersValidUsername();
            GivenTheUserEntersValidPassword();
            WhenTheUserClicksSubmit();
            ThenTheUserCanLogin();
        }

        [Given(@"the user enters valid password")]
        public void GivenTheUserEntersValidPassword()
        {
            loginPage.EnterUserPassword(ConfigurationManager.AppSettings["Password"]);
        }

        [When(@"the user clicks submit")]
        public void WhenTheUserClicksSubmit()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"the user can login")]
        public void ThenTheUserCanLogin()
        {
            loginPage.CheckUserIsAtHomepage();
        }




    }
}
