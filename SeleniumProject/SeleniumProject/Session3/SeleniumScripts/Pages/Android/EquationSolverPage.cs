using AutomationProject.Contracts.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumScripts;

namespace SeleniumProject.Session3.SeleniumScripts.Pages.Android
{
    public class EquationSolverPage : ScriptBase, IEquationSolverPage
    {
        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/d1']")]
        private IWebElement BtnSolve { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/d2']")]
        private IWebElement BtnX { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/d3']")]
        private IWebElement BtnY { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/bw']")]
        private IWebElement BtnAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/bq']")]
        private IWebElement BtnEqual { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/br']")]
        private IWebElement BtnClear { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/bg']")]
        private IWebElement Btn2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/bh']")]
        private IWebElement Btn3 { get; set; }



        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.RelativeLayout[2]/android.widget.LinearLayout/android.webkit.WebView/android.webkit.WebView/android.view.View[2]/android.view.View']")]
        private IWebElement TextEquationResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/p0']")]
        private IWebElement BtnCancelPopup { get; set; }




        public EquationSolverPage(AndroidDriver<RemoteWebElement> androidDriver) : base(androidDriver)
        {
            AndroidDriver = androidDriver;
            PageFactory.InitElements(AndroidDriver, this);
        }

        public void ClickButton(string btnType)
        {
            switch (btnType)
            {
                case "2":
                    Btn2.Click();
                    break;
                case "3":
                    Btn3.Click();
                    break;                
                case "=":
                    BtnEqual.Click();
                    break;
                case "+":
                    BtnAdd.Click();
                    break;
                case "clear":
                    BtnClear.Click();
                    break;
                case "x":
                    BtnX.Click();
                    break;
                case "y":
                    BtnY.Click();
                    break;
                case "solve":
                    BtnSolve.Click();
                    break;
            }
        }


        public void CheckResult(string expectedResult)
        {
            WaitThreadSleep(2);
            AndroidDriver.FindElements(By.XPath("//*[(@class='android.view.View')]"))[2].Text.Should().Contain(expectedResult);
        }
    }
}
