using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using AutomationProject.Session1.Contracts;
using System;

namespace SeleniumScripts
{
    /// <summary>
    /// Setup Driver class
    /// </summary>
    public class SetupDriver : ISetupDriver
    {
        /// <summary>
        /// The browser
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// The web driver
        /// </summary>
        public IWebDriver Driver { get; set; }


        public object SeleniumExtrasWaitHelper { get; private set; }
        
        /// <summary>
        /// Goes to main URL.
        /// </summary>
        private void GoToMainUrl()
        {
            var mainUrl = new Uri("http://demo.guru99.com/V4/index.php");
            Driver.Navigate().GoToUrl(mainUrl);
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Implement ISetupDriver
        /// </summary>
        public void LoadWebDriver()
        {
            if (Driver == null)
            {
                Init();
            }
        }


        /// <summary>
        /// Defines the web driver depending on the browser specified
        /// </summary>
        private void Init()
        {
            switch (Browser.ToUpperInvariant())
            {
                case "CHROME":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("chrome.switches", "--disable-extensions " +
                        "--disable-extensions-file-access-check --disable-extensions-http-throttling " +
                        "--disable-infobars --enable-automation --start-maximized");
                    chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
                    chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
                    chromeOptions.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
                    this.Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(@"C:\Temp"), chromeOptions, TimeSpan.FromSeconds(10));                   
                    break;

                case "FIREFOX":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("--disable-extensions --disable-extensions-file-access-check " +
                        "--disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
                    firefoxOptions.AcceptInsecureCertificates = true;

                    this.Driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(@"C:\Temp"), firefoxOptions, TimeSpan.FromSeconds(10));
                    break;

                case "IE":
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        EnsureCleanSession = true,
                        EnableNativeEvents = true,
                        IgnoreZoomLevel = true
                    };

                    this.Driver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(@"C:\Temp"), ieOptions, TimeSpan.FromSeconds(10));
                    break;

                default:
                    throw new NotSupportedException($"The browser { Browser.ToUpperInvariant() } is not supported.");
            }

            GoToMainUrl();
        }
    }
}
