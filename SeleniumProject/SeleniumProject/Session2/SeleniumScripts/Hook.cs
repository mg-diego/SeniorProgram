using AutomationProject.Containers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumScripts;
using System;
using System.Globalization;
using System.IO;
using TechTalk.SpecFlow;

namespace AutomationProject.SeleniumScripts
{
    [Binding]
    public sealed class Hook
    {
        enum Browser { Chrome, Firefox, IE, Opera };

        private IWebDriver driver;

        private TestContext testContext = ScenarioContext.Current.ScenarioContainer.Resolve<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>();
        private int _stepCounter = 0;
        private bool _isApiTestcase = false;
        private string _browserTag = "";
        private string TestResultsDirectory = @"C:\Temp";

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //RemoveDb();
            //InsertDefaultDBConfig();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            //RemoveDb();
            //InsertDefaultDBConfig();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //RemoveDb();
            //InsertDefaultDBConfig();

            //Get the browser + testcase TAG
            foreach (var tag in ScenarioContext.Current.ScenarioInfo.Tags)
            {
                _isApiTestcase = tag.Contains("api") ? true : _isApiTestcase;
                _browserTag = tag.Contains("api") ? "" : tag;
            }

            //Folder format:
            // "C:\Temp\<CurrentDate>\"
            // Ex: C:\Temp\2019-07-16 - 16_54_32\
            TestResultsDirectory = @"C:\Temp";
            TestResultsDirectory = TestResultsDirectory + @"\" + DateTime.UtcNow.ToString("yyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);

            if (!Directory.Exists(TestResultsDirectory) && !_isApiTestcase)
            {
                Directory.CreateDirectory(TestResultsDirectory);
            }

            LoadBrowserConfig();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //RemoveDb();
            //InsertDefaultDBConfig();

            driver?.Quit();
            driver?.Dispose();
        }

        [BeforeStep]
        public static void BeforeStep()
        {
        }

        /// <summary>
        /// Makes a screenshot after every step and save it at PATH
        /// </summary>
        [AfterStep]
        public void AfterStep()
        {
            var ScreenshotName = _browserTag + " - ";

            if (!_isApiTestcase)
            {
                _stepCounter++;

                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                //ScreenshotName format:
                // "<Browser> - <tc_tag> - <step_number><step_type> - <step_name>.png"
                // Ex: Chrome - tc_45993 - 0Given - the following users are inserted into the database.png

                ScreenshotName += _stepCounter;
                ScreenshotName += ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType + " - ";
                ScreenshotName += ScenarioContext.Current.StepContext.StepInfo.Text;
                ScreenshotName = ScreenshotName.Replace(":", "_");
                ScreenshotName = ScreenshotName.Replace($"\"", "");
                ScreenshotName = ScreenshotName.Replace($"\\", "");

                ss.SaveAsFile(TestResultsDirectory + @"\" + ScreenshotName + ".png");
                testContext.AddResultFile(TestResultsDirectory + @"\" + ScreenshotName + ".png");
            }
        }



        /// <summary>
        /// This will execute the browser based on the current scenario browser tag
        /// </summary>
        public void LoadBrowserConfig()
        {
            string browser_TagName = ScenarioContext.Current.ScenarioInfo.Tags.GetValue(ScenarioContext.Current.ScenarioInfo.Tags.Length - 1).ToString();

            switch (browser_TagName)
            {
                case "Chrome":
                    Load(Browser.Chrome);
                    break;

                case "Firefox":
                    Load(Browser.Firefox);
                    break;

                case "IE":
                    Load(Browser.IE);
                    break;

                case "api":
                    ContainerDependencies.CreateContainer();
                    var setupDriver = ContainerDependencies.Container.Resolve(typeof(SetupDriver), null, null) as SetupDriver;
                    setupDriver.LoadAPIDriver();
                    break;

                default:
                    throw new NotSupportedException("No browser tag name defined.");
            }
        }

        private void Load(Browser browser)
        {
            ContainerDependencies.CreateContainer();
            var setupDriver = ContainerDependencies.Container.Resolve(typeof(SetupDriver), null, null) as SetupDriver;

            setupDriver.Browser = browser.ToString();
            setupDriver.LoadWebDriver();

            driver = setupDriver.Driver;

            if (!ScenarioContext.Current.ContainsKey("currentDriver"))
            {
                ScenarioContext.Current.Add("currentDriver", setupDriver.Driver);
            }
        }
    }
}
