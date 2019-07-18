using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Session1.TestScripts.Steps
{
    public abstract class StepBase : TechTalk.SpecFlow.Steps, IDisposable
    {
        /// <summary>
        /// instantiates a driver
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// instantiates the step base class
        /// </summary>
        protected StepBase()
        {
            Driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
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
