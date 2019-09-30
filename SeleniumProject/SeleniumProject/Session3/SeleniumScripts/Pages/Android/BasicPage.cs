using AutomationProject.Contracts.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumScripts;

namespace AutomationProject.SeleniumScripts.Pages
{
    public class BasicPage : ScriptBase, IBasicPage
    {        
        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/hq']")]
        private IWebElement ClosePopupButton { get; set; }


        public BasicPage(AndroidDriver<RemoteWebElement> androidDriver) : base(androidDriver)
        {
            AndroidDriver = androidDriver;
            PageFactory.InitElements(AndroidDriver, this);
        }


        public void ClosePopupOpenApp()
        {
            WaitThreadSleep(1);
        }
    }
}
