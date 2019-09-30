using AutomationProject.Contracts.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumScripts;

namespace AutomationProject.SeleniumScripts.Pages
{
    public class BasicPage : ScriptBase, IBasicPage
    {
        [FindsBy(How = How.XPath, Using = "//android.widget.ImageButton[@content-desc='open']")]
        private IWebElement BasicTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/hq']")]
        private IWebElement ClosePopupButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/s2']")]
        private IWebElement Btn0 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rw']")]
        private IWebElement Btn1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/s1']")]
        private IWebElement Btn2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/s0']")]
        private IWebElement Btn3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rt']")]
        private IWebElement Btn4 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rs']")]
        private IWebElement Btn5 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rz']")]
        private IWebElement Btn6 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/ry']")]
        private IWebElement Btn7 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rp']")]
        private IWebElement Btn8 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rv']")]
        private IWebElement Btn9 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/en']")]
        private IWebElement FieldResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/ru']")]
        private IWebElement BtnMultiply { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/ro']")]
        private IWebElement BtnDivide { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rx']")]
        private IWebElement BtnSubstract { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rk']")]
        private IWebElement BtnAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/d5']")]
        private IWebElement BtnEqual { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rq']")]
        private IWebElement BtnClear { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rn']")]
        private IWebElement BtnDot { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rl']")]
        private IWebElement BtnOpenBracket { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@resource-id='all.in.one.photo.math.calculator:id/rm']")]
        private IWebElement BtnCloseBracket { get; set; }



        public BasicPage(AndroidDriver<RemoteWebElement> androidDriver) : base(androidDriver)
        {
            AndroidDriver = androidDriver;
            PageFactory.InitElements(AndroidDriver, this);
        }


        public void CheckIsAtBasicPage()
        {
            WaitThreadSleep(4);
        }

        public void ClickButton(string btnType)
        {
            switch (btnType)
            {
                case "0":
                    Btn0.Click();
                    break;
                case "1":
                    Btn1.Click();
                    break;
                case "2":
                    Btn2.Click();
                    break;
                case "3":
                    Btn3.Click();
                    break;
                case "4":
                    Btn4.Click();
                    break;
                case "5":
                    Btn5.Click();
                    break;
                case "6":
                    Btn6.Click();
                    break;
                case "7":
                    Btn7.Click();
                    break;
                case "8":
                    Btn8.Click();
                    break;
                case "9":
                    Btn9.Click();
                    break;
                case "=":
                    BtnEqual.Click();
                    break;
                case "x":
                    BtnMultiply.Click();
                    break;
                case "÷":
                    BtnDivide.Click();
                    break;
                case "-":
                    BtnSubstract.Click();
                    break;
                case "+":
                    BtnAdd.Click();
                    break;
                case "clear":
                    BtnClear.Click();
                    break;
                case "(":
                    BtnOpenBracket.Click();
                    break;
                case ")":
                    BtnCloseBracket.Click();
                    break;
            }
        }

        public void CheckResult(string expectedResult)
        {
            WaitThreadSleep(1);
            FieldResult.Text.Should().Be(expectedResult);
        }
    }
}
