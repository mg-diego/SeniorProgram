using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Appium.Android;
using AutomationProject.Contracts;
using System;
using System.IO;
using System.Reflection;
using AutomationProject.DataEntities.Library;
using OpenQA.Selenium.Remote;
using System.Diagnostics;

namespace SeleniumScripts
{
    /// <summary>
    /// Setup Driver class
    /// </summary>
    public class SetupDriver : ISetupDriver
    {
        /// <summary>
        /// Path for Selenium drivers
        /// </summary>
        private const string DriverPath = @"\Session3\Binaries\";

        /// <summary>
        /// The browser
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// The web driver
        /// </summary>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// The Android driver
        /// </summary>
        public AndroidDriver<RemoteWebElement> AndroidDriver { get; set; }

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

        /// <inheritdoc cref="ISetupDriver" />

        public void LoadWebDriver()
        {
            if (Driver == null)
            {
                InitWebDriver();
            }
        }

        public void LoadAndroidDriver()
        {
            if (AndroidDriver == null)
            {
                InitAndroidDriver();
            }
        }

        /// <inheritdoc cref="ISetupDriver" />
        public void LoadAPIDriver()
        {
            NodeServerLibrary nodeServerLibrary = new NodeServerLibrary();
            nodeServerLibrary.GetServerUrl();
        }


        /// <summary>
        /// Defines the web driver depending on the browser specified
        /// </summary>
        private void InitWebDriver()
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
                    this.Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath), chromeOptions, TimeSpan.FromSeconds(10));                   
                    break;

                case "FIREFOX":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("--disable-extensions --disable-extensions-file-access-check " +
                        "--disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
                    firefoxOptions.AcceptInsecureCertificates = true;

                    this.Driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath), firefoxOptions, TimeSpan.FromSeconds(10));
                    break;

                case "IE":
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        EnsureCleanSession = true,
                        EnableNativeEvents = true,
                        IgnoreZoomLevel = true
                    };

                    this.Driver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath), ieOptions, TimeSpan.FromSeconds(10));
                    break;

                default:
                    throw new NotSupportedException($"The browser { Browser.ToUpperInvariant() } is not supported.");
            }

            GoToMainUrl();
        }


        private void InitAndroidDriver()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("deviceName", GetDeviceName());
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("fullReset", "false");
            capabilities.SetCapability("noReset", "true");
            capabilities.SetCapability("unicodeKeyboard", true);
            capabilities.SetCapability("resetKeyboard", true);
            capabilities.SetCapability("autoAcceptAlerts", true);
            capabilities.SetCapability("autoGrantPermissions", true);
            capabilities.SetCapability("newCommandTimeout", 300);
            capabilities.SetCapability("app", @"C:\temp\calculator.apk");

            AndroidDriver = new AndroidDriver<RemoteWebElement>(new Uri("http://127.0.0.1:4725/wd/hub"), capabilities, TimeSpan.FromSeconds(120));
        }

        private string GetDeviceName()
        {
            //Execute adb command to get the deviceName
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Users\madi\AppData\Local\Android\Sdk\platform-tools\adb.exe",
                    Arguments = "devices",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            string deviceName = proc.StandardOutput.ReadToEnd().ToString();

            //Extract the deviceName for the capabilities
            deviceName = deviceName.Replace("List of devices attached", "");
            deviceName = deviceName.Replace("	device", "");
            deviceName = deviceName.Replace("\r\n", "");

            Console.WriteLine(" - deviceName: " + deviceName);
            return deviceName;
        }
    }
}
