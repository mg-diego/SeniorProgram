using AutomationProject.Contracts.Pages;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumScripts;

namespace SeleniumProject.Session3.SeleniumScripts.Pages
{
    public class MenuPage : ScriptBase, IMenuPage
    {
        public MenuPage(AndroidDriver<RemoteWebElement> androidDriver) : base(androidDriver)
        {
            AndroidDriver = androidDriver;
            PageFactory.InitElements(AndroidDriver, this);
        }


        public void SwipeToLeft()
        {
            SwipeRightToLeft();
        }

        public void SwipeToRight()
        {
            SwipeLeftToRight();
        }
    }
}
