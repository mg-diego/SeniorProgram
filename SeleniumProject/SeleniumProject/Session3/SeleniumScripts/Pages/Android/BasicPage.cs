using AutomationProject.Contracts.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumScripts;

namespace AutomationProject.SeleniumScripts.Pages
{
    public class BasicPage : ScriptBase, IBasicPage
    {        
        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/hq']")]
        private IWebElement ClosePopupButton { get; set; }


        public BasicPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }


        public void ClosePopupOpenApp()
        {
            WaitUntilElementIsClickable(ClosePopupButton);
            ClosePopupButton.Click();
        }
    }
}
