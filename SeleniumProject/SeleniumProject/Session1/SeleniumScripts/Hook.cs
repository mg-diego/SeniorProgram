using TechTalk.SpecFlow;
using SeleniumScripts;
using System;
using OpenQA.Selenium;
using SeleniumProject.Session1.Contracts.Pages;
using SeleniumProject.Session1.SeleniumScripts.Pages;
using Unity.Lifetime;
using Unity.Injection;
using SeleniumProject.Session1.Containers;

namespace SeleniumProject.Session1.SeleniumScripts
{
    [Binding]
    public sealed class Hook
    {
        enum Browser { Chrome, Firefox, IE, Opera };
        private IWebDriver driver;


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            LoadBrowserConfig();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }

        [BeforeStep]
        public static void BeforeStep()
        {
        }

        [AfterStep]
        public static void AfterStep()
        {
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

                case "Win10_Ent_Firefox":
                    Load(Browser.Firefox);
                    break;

                case "Win10_Ent_IE":
                    Load(Browser.IE);
                    break;

                case "Win10_Pro_Chrome":
                    Load(Browser.Chrome);
                    break;

                case "Win10_Pro_Firefox":
                    Load(Browser.Firefox);
                    break;

                case "Win10_Pro_IE":
                    Load(Browser.IE);
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
