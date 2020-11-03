using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationProject
{
    /// <summary>
    /// Testing the Login functionallity
    /// </summary>
    [TestClass]
    public class ChromeTests
    {
        /// <summary>
        /// The web driver
        /// </summary>
        private IWebDriver _webDriver;

        private string userId = "mngr293224";
        private string password = "qymuvut";


        [TestInitialize]
        public void SetUp()
        {
            //Set Up Web Driver
            this._webDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(@"C:\Temp"), new ChromeOptions(), TimeSpan.FromSeconds(10));

            // Go to the Web Page
            this._webDriver.Navigate().GoToUrl("http://demo.guru99.com/V4/index.php");
            this._webDriver.Manage().Window.FullScreen();
        }

        /// <summary>
        /// Cleans up.
        /// </summary>
        [TestCleanup]
        public void CleanUp()
        {
            this._webDriver.Close();
        }

        /// <summary>
        /// As a User, I can Logon into the web page.
        /// </summary>
        [TestMethod]
        public void UserLogon()
        {
            // -- Arrange --

            // Expected
            var expectedUrl = "http://demo.guru99.com/V4/manager/Managerhomepage.php";

            // Buttons
            var userIdTextBox = this._webDriver.FindElement(By.Name("uid"));
            var userPasswordTextBox = this._webDriver.FindElement(By.Name("password"));
            var clickLoginButton = this._webDriver.FindElement(By.Name("btnLogin"));

            // -- Act --

            // User enters the User ID
            userIdTextBox.SendKeys(userId);

            // User enters the Password
            userPasswordTextBox.SendKeys(password);

            // User clicks login button
            clickLoginButton.Click();

            // -- Assert --
            Assert.AreEqual(expectedUrl, this._webDriver.Url, string.Format("The url must be {0}", expectedUrl));
        }

        /// <summary>
        /// As a Invalid User, I cant Logon into the web page.
        /// </summary>
        [TestMethod]
        public void InvalidUserCantLogon()
        {
            // -- Arrange --

            // Buttons
            var userIdTextBox = this._webDriver.FindElement(By.Name("uid"));
            var userPasswordTextBox = this._webDriver.FindElement(By.Name("password"));
            var clickLoginButton = this._webDriver.FindElement(By.Name("btnLogin"));

            // -- Act --

            // User enters the User ID
            userIdTextBox.SendKeys(userId);

            // User enters the Password
            userPasswordTextBox.SendKeys("123");

            // User clicks login button
            clickLoginButton.Click();

            // -- Assert --

            // Expected
            var alertText = "User or Password is not valid";

            // Switch to Alert message
            var alert = this._webDriver.SwitchTo().Alert();

            // Get the text alert
            var realText = alert.Text;

            // Click accept button alert
            alert.Accept();

            Assert.AreEqual(alertText, realText, string.Format("The alert text must be {0}", alertText));
        }

        [TestMethod]
        public void CheckMenuLinks()
        {
            // -- Arrange --
            Dictionary<string, string> HomepageMenuLinks = new Dictionary<string, string>();
            HomepageMenuLinks.Add("Manager", "http://demo.guru99.com/V4/manager/Managerhomepage.php");
            HomepageMenuLinks.Add("New Customer", "http://demo.guru99.com/V4/manager/addcustomerpage.php");
            HomepageMenuLinks.Add("Edit Customer", "http://demo.guru99.com/V4/manager/EditCustomer.php");
            HomepageMenuLinks.Add("Delete Customer", "http://demo.guru99.com/V4/manager/DeleteCustomerInput.php");
            HomepageMenuLinks.Add("New Account", "http://demo.guru99.com/V4/manager/addAccount.php");
            HomepageMenuLinks.Add("Edit Account", "http://demo.guru99.com/V4/manager/editAccount.php");
            HomepageMenuLinks.Add("Delete Account", "http://demo.guru99.com/V4/manager/deleteAccountInput.php");
            HomepageMenuLinks.Add("Deposit", "http://demo.guru99.com/V4/manager/DepositInput.php");
            HomepageMenuLinks.Add("Withdrawal", "http://demo.guru99.com/V4/manager/WithdrawalInput.php");
            HomepageMenuLinks.Add("Fund Transfer", "http://demo.guru99.com/V4/manager/FundTransInput.php");
            HomepageMenuLinks.Add("Change Password", "http://demo.guru99.com/V4/manager/PasswordInput.php");
            HomepageMenuLinks.Add("Balance Enquiry", "http://demo.guru99.com/V4/manager/BalEnqInput.php");
            HomepageMenuLinks.Add("Mini Statement", "http://demo.guru99.com/V4/manager/MiniStatementInput.php");
            HomepageMenuLinks.Add("Customised Statement", "http://demo.guru99.com/V4/manager/CustomisedStatementInput.php");
            HomepageMenuLinks.Add("Log out", "http://demo.guru99.com/V4/manager/Logout.php");

            // -- Act --
            UserLogon();
            IWebElement tab;

            // -- Assert --
            foreach (var link in HomepageMenuLinks)
            {
                tab = this._webDriver.FindElement(By.LinkText(link.Key));
                Assert.AreEqual(tab.GetAttribute("href").ToString(), link.Value);
            }            
        }

        [TestMethod]
        public void CreateNewCustomer()
        {
            // -- Act --
            UserLogon();
            Random random = new Random();
            this._webDriver.FindElement(By.LinkText("New Customer")).Click(); 

            var customerNameInput = this._webDriver.FindElement(By.Name("name"));
            var genderMaleRadioButton = this._webDriver.FindElement(By.XPath("//*[@value='m']"));
            var genderFemaleRadioButton = this._webDriver.FindElement(By.XPath("//*[@value='f']"));
            var genderRadioButton = this._webDriver.FindElements(By.XPath("//*[@type='radio']"));
            var dateInput = this._webDriver.FindElement(By.Name("dob"));
            var addressInput = this._webDriver.FindElement(By.Name("addr"));
            var cityInput = this._webDriver.FindElement(By.Name("city"));
            var stateInput = this._webDriver.FindElement(By.Name("state"));
            var pinInput = this._webDriver.FindElement(By.Name("pinno"));
            var phoneInput = this._webDriver.FindElement(By.Name("telephoneno"));
            var emailInput = this._webDriver.FindElement(By.Name("emailid"));
            var passwordInput = this._webDriver.FindElement(By.Name("password"));
            var submitBtn = this._webDriver.FindElement(By.Name("sub"));
            var resetBtn = this._webDriver.FindElement(By.Name("res"));

            Dictionary<string, string> NewCustomer = new Dictionary<string, string>();
            NewCustomer.Add("Customer Name","Diego");
            NewCustomer.Add("Gender","male");
            NewCustomer.Add("Address","Plaza Cataluña");
            NewCustomer.Add("City","Barcelona");
            NewCustomer.Add("State","Barcelona");
            NewCustomer.Add("Pin","123321");
            NewCustomer.Add("Mobile No.", "123321123");
            NewCustomer.Add("Email", "diego"+ random.Next(1,10000).ToString() + "@erni.com");

            customerNameInput.SendKeys(NewCustomer["Customer Name"]);
            genderFemaleRadioButton.Click();
            genderRadioButton[0].Click();
            dateInput.SendKeys("22/05/19");
            addressInput.SendKeys(NewCustomer["Address"]);
            cityInput.SendKeys(NewCustomer["City"]);
            stateInput.SendKeys(NewCustomer["State"]);
            pinInput.SendKeys(NewCustomer["Pin"]);
            phoneInput.SendKeys(NewCustomer["Mobile No."]);
            emailInput.SendKeys(NewCustomer["Email"]);
            passwordInput.SendKeys("Password");

            submitBtn.Click();


            // -- Assert --
            var confirmationText = this._webDriver.FindElement(By.ClassName("heading3"));
            Assert.AreEqual(confirmationText.Text, "Customer Registered Successfully!!!");

            var confirmationTable = this._webDriver.FindElement(By.Id("customer"));
            var rows = confirmationTable.FindElements(By.TagName("tr"));
            IList<IWebElement> columns;

            //Check Confirmation Values

            foreach (var entry in NewCustomer)
            { 
                foreach (var row in rows)
                {
                    columns = row.FindElements(By.TagName("td"));

                    if (columns[0].Text == entry.Key)
                    {
                        Assert.AreEqual(columns[1].Text, entry.Value);
                    }
                }
            }

            Console.WriteLine("CustomerId: " + rows[3].FindElements(By.TagName("td"))[1].Text);

        }
    }
}

