using OpenQA.Selenium;
using SeleniumProject.Session1.Contracts.Pages;
using SeleniumScripts;
using SeleniumExtras.PageObjects;
using FluentAssertions;
using System.Collections.Generic;
using System;

namespace SeleniumProject.Session1.SeleniumScripts.Pages
{
    public class NewCustomerPage : ScriptBase, INewCustomer
    {
        Random random = new Random();

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
        }

        /// <inheritdoc cref="INewCustomer" />
        public void EnterValidDataForNewCustomer()
        {
            NewCustomer.Clear();
            NewCustomer.Add("Customer Name", "Diego");
            NewCustomer.Add("Gender", "male");
            NewCustomer.Add("Address", "Plaza Cataluña");
            NewCustomer.Add("City", "Barcelona");
            NewCustomer.Add("State", "Barcelona");
            NewCustomer.Add("Pin", "123321");
            NewCustomer.Add("Mobile No.", "123321123");
            NewCustomer.Add("Email", "diego" + random.Next(1, 10000).ToString() + "@erni.com");

            SendKeysElement(customerNameInput, (NewCustomer["Customer Name"]));
            ClickElement(genderMaleRadioButton);
            SendKeysElement(dateInput, "22/05/19");
            SendKeysElement(addressInput, NewCustomer["Address"]);
            SendKeysElement(cityInput, NewCustomer["City"]);
            stateInput.SendKeys(NewCustomer["State"]);
            pinInput.SendKeys(NewCustomer["Pin"]);
            phoneInput.SendKeys(NewCustomer["Mobile No."]);
            emailInput.SendKeys(NewCustomer["Email"]);
            passwordInput.SendKeys("Password");
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
            ClickElement(submitBtn);
        }

        /// <inheritdoc cref="INewCustomer" />

        public void ClickNewCustomerTab()
        {
            ClickElement(customerTab);
        }


    }
}
