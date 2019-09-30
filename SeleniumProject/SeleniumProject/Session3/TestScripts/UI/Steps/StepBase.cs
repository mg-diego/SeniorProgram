using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace AutomationProject.TestScripts.Steps
{
    public abstract class StepBase : TechTalk.SpecFlow.Steps, IDisposable
    {
        /// <summary>
        /// instantiates a driver
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// instantiates a driver
        /// </summary>
        public AndroidDriver<RemoteWebElement> AndroidDriver { get; set; }


        /// <summary>
        /// instantiates the step base class
        /// </summary>
        protected StepBase()
        {
            Driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
            AndroidDriver = ScenarioContext.Current.Get<AndroidDriver<RemoteWebElement>>("currentDriver");
        }

        /// <summary>
        /// Implements IDisposable
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// overloads Dispose method, and disposes the driver
        /// </summary>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                //FREE MANAGED RESOURCE HERE
            }

            if (Driver != null)
            {
                Driver.Dispose();
            }
        }
    }
}
