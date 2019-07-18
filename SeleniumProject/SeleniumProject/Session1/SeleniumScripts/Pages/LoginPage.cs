using OpenQA.Selenium;
using SeleniumProject.Session1.Contracts.Pages;
using SeleniumScripts;
using SeleniumExtras.PageObjects;
using FluentAssertions;

namespace SeleniumProject.Session1.SeleniumScripts.Pages
{
    public class LoginPage : ScriptBase, ILoginPage
    {
        [FindsBy(How = How.Name, Using = "uid")]
        private IWebElement userIdTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement userPasswordTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "btnLogin")]
        private IWebElement loginButton { get; set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        /// <inheritdoc cref="ILoginPage" />
        public void EnterUserName(string name)
        {
            WaitUntilElementIsClickable(userIdTextBox);
            ClearElementContent(userIdTextBox);
            SendKeysElement(userIdTextBox, name);
        }


        /// <inheritdoc cref="ILoginPage" />
        public void EnterUserPassword(string password)
        {
            WaitUntilElementIsClickable(userPasswordTextBox);
            ClearElementContent(userPasswordTextBox);
            SendKeysElement(userPasswordTextBox, password);
        }

        /// <inheritdoc cref="ILoginPage" />

        public void ClickLoginButton()
        {
            ClickElement(loginButton);
        }

        /// <inheritdoc cref="ILoginPage" />

        public void CheckUserIsAtHomepage()
        {
            this.Driver.Url.Should().Be("http://demo.guru99.com/V4/manager/Managerhomepage.php");
        }

    }
}
