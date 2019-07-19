using OpenQA.Selenium;
using SeleniumProject.Session1.Contracts.Pages;
using SeleniumScripts;
using SeleniumExtras.PageObjects;
using FluentAssertions;
using System.Collections.Generic;
using System;
using System.Configuration;
using SeleniumProject.Session1.SeleniumScripts.Helpers;
using SeleniumProject.Session1.DataEntities.Library;

namespace SeleniumProject.Session1.SeleniumScripts.Pages
{
    public class NewCustomerPage : ScriptBase, INewCustomer
    {
        private readonly CustomerLibrary customerLibrary;

        [FindsBy(How = How.LinkText, Using = "New Customer")]
        private IWebElement customerTab { get; set; }

        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement customerNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='m']")]
        private IWebElement genderMaleRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='f']")]
        private IWebElement genderFemaleRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@type='radio']")]
        private IWebElement genderRadioButton { get; set; }

        [FindsBy(How = How.Name, Using = "dob")]
        private IWebElement dateInput { get; set; }

        [FindsBy(How = How.Name, Using = "addr")]
        private IWebElement addressInput { get; set; }

        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement cityInput { get; set; }

        [FindsBy(How = How.Name, Using = "state")]
        private IWebElement stateInput { get; set; }        

        [FindsBy(How = How.Name, Using = "pinno")]
        private IWebElement pinInput { get; set; }       

        [FindsBy(How = How.Name, Using = "telephoneno")]
        private IWebElement phoneInput { get; set; }  

        [FindsBy(How = How.Name, Using = "emailid")]
        private IWebElement emailInput { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordInput { get; set; }

        [FindsBy(How = How.Name, Using = "sub")]
        private IWebElement submitBtn { get; set; }

        [FindsBy(How = How.Name, Using = "res")]
        private IWebElement resetBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "heading3")]
        private IWebElement confirmationText { get; set; }

        [FindsBy(How = How.Id, Using = "customer")]
        private IWebElement confirmationTable { get; set; }

        public Dictionary<string, string> NewCustomer = new Dictionary<string, string>();
        


        public NewCustomerPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
            customerLibrary = new CustomerLibrary();
        }

        /// <inheritdoc cref="INewCustomer" />
        public void EnterValidDataForNewCustomer()
        {
            var customerDetails = customerLibrary.GetCustomerDetails("Diego");

            var email = ConfigurationManager.AppSettings["NewCustomerEmail"] == "" ? "diego" + GenerateRandomNumberBetween(1,10000).ToString() + "@erni.com" : ConfigurationManager.AppSettings["NewCustomerEmail"];
            ConfigurationManager.AppSettings["NewCustomerEmail"] = email;

            NewCustomer.Clear();
            NewCustomer.Add("Customer Name", customerDetails[0]);
            NewCustomer.Add("Gender", customerDetails[1]);
            NewCustomer.Add("Address", customerDetails[2]);
            NewCustomer.Add("City", customerDetails[3]);
            NewCustomer.Add("State", customerDetails[4]);
            NewCustomer.Add("Pin", customerDetails[5]);
            NewCustomer.Add("Mobile No.", customerDetails[6]);
            NewCustomer.Add("Email", email);

            SendKeysElement(customerNameInput, NewCustomer["Customer Name"]);
            if (customerDetails[1] == "male") { ClickElement(genderMaleRadioButton); }
            else { ClickElement(genderMaleRadioButton); }
            ClickElement(genderMaleRadioButton);
            SendKeysElement(dateInput, "22/05/19");
            SendKeysElement(addressInput, NewCustomer["Address"]);
            SendKeysElement(cityInput, NewCustomer["State"]);
            SendKeysElement(stateInput, NewCustomer["City"]);            
            SendKeysElement(pinInput, NewCustomer["Pin"]);
            SendKeysElement(phoneInput, NewCustomer["Mobile No."]);
            SendKeysElement(emailInput, NewCustomer["Email"]);
            SendKeysElement(passwordInput, "Password");
        }

        /// <inheritdoc cref="INewCustomer" />
        public void CheckNewCustomerIsCreated()
        {
            WaitUntilElementIsClickable(confirmationText);
            confirmationText.Text.Should().Be("Customer Registered Successfully!!!");

            var rows = confirmationTable.FindElements(By.TagName("tr"));
            IList<IWebElement> columns;

            foreach (var entry in NewCustomer)
            {
                foreach (var row in rows)
                {
                    columns = row.FindElements(By.TagName("td"));

                    if (columns[0].Text == entry.Key)
                    {
                        columns[1].Text.Should().Be(entry.Value);
                    }
                }
            }
        }

        /// <inheritdoc cref="INewCustomer" />

        public void ClickSubmitButton()
        {
           submitBtn.Click();
        }

        /// <inheritdoc cref="INewCustomer" />

        public void ClickNewCustomerTab()
        {
            ClickElement(customerTab);
        }

        /// <inheritdoc cref="INewCustomer" />
        public void CheckNewUserIsNotCreated()
        {
            Driver.SwitchTo().Alert().Text.Should().Be("Email Address Already Exist !!");
        }


    }
}
