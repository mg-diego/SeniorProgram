using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Threading;
using SeleniumExtrasWaitHelper = SeleniumExtras.WaitHelpers;
using AutomationProject.Session1.SeleniumScripts.Helpers;

namespace SeleniumScripts
{
    public class ScriptBase : SeleniumHelpers
    {
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ScriptBase(IWebDriver driver) { }

        /// <summary>
        /// Wait method
        /// Used to specify for how long the scripts will wait before proceeding
        /// </summary>
        /// <param name="seconds">number of seconds to wait</param>
        protected static void WaitThreadSleep(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        /// <summary>
        /// IsElementPresent
        /// Verifies if an element is present on the page
        /// </summary>
        /// <param name="by">element to search for via 'by' value</param>
        /// <returns>True | False</returns>
        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the element is present in the document using WebElement
        /// </summary>
        /// <param name="webElement">Reference in finding the Element in the document</param>
        /// <returns>True | False</returns>
        public bool IsElementPresent(IWebElement webElement)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                wait.Until(SeleniumExtrasWaitHelper.ExpectedConditions.ElementToBeClickable(webElement));
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether [is element enabled] [the specified web element].
        /// </summary>
        /// <param name="webElement">The web element.</param>
        /// <returns> Boolean representing if the element is enabled or not.</returns>
        public bool IsElementEnabled(IWebElement webElement)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
                wait.Until(SeleniumExtrasWaitHelper.ExpectedConditions.ElementToBeClickable(webElement));
                return webElement.Enabled && webElement.Displayed;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Clicks the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <exception cref="ArgumentNullException">element</exception>
        protected void ClickElement(IWebElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            try
            {
                var policy = RetryPolicy.Handle<StaleElementReferenceException>()
                    .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                    });

                policy.Execute(() =>
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(800));
                    this.WaitUntilElementIsClickable(element);
                    element.Click();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Doubles the click element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <exception cref="ArgumentNullException">element</exception>
        protected void DoubleClickElement(IWebElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            try
            {
                var policy = RetryPolicy.Handle<StaleElementReferenceException>()
                    .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                    });

                policy.Execute(() =>
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(800));
                    this.WaitUntilElementIsClickable(element);
                    new Actions(Driver).DoubleClick(element).Build().Perform();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Clicks the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <exception cref="ArgumentNullException">element</exception>
        protected void ClickInnerElement(IWebElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            try
            {
                var policy = RetryPolicy.Handle<StaleElementReferenceException>()
                    .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                    });

                policy.Execute(() =>
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(800));
                    this.WaitUntilElementIsClickable(element);
                    Actions action = new Actions(Driver);
                    action.MoveToElement(element).Click().Perform();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected void ClickTableCheckBoxElement(IWebElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            try
            {
                var policy = RetryPolicy.Handle<StaleElementReferenceException>()
                    .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                    });

                policy.Execute(() =>
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(800));
                    this.WaitUntilElementIsClickable(element);
                    Actions action = new Actions(Driver);
                    action.MoveToElement(element).Click().Perform();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Waits the until element is clickable.
        /// </summary>
        /// <param name="element">The element.</param>
        protected void WaitUntilElementIsClickable(IWebElement element)
        {
            try
            {
                var webDriverWait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(15));
                webDriverWait.Until(SeleniumExtrasWaitHelper.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Sends the keys element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="keys">The keys.</param>
        /// <exception cref="ArgumentNullException">element</exception>
        protected void SendKeysElement(IWebElement element, string keys)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            this.WaitUntilElementIsClickable(element);
            element.SendKeys(keys);
        }

        /// <summary>
        /// Clears the content of the element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <exception cref="ArgumentNullException">element</exception>
        protected void ClearElementContent(IWebElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            try
            {
                var policy = RetryPolicy.Handle<StaleElementReferenceException>()
                    .WaitAndRetry(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                    });

                policy.Execute(() =>
                {
                    this.WaitUntilElementIsClickable(element);
                    element.Clear();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Returns web element of a table based on the submitted value
        /// </summary>
        /// <param name="UserTable">Ilist Table to inspect</param>
        /// <param name="strValue">Value to look for</param>
        /// <returns>Returns IWebElement of the value within the table</returns>
        protected IWebElement FindUserWithValue(IList<IWebElement> UserTable, string strValue)
        {
            IList<IWebElement> rowTD;
            IWebElement ActiveTableRow = null;
            foreach (var row in UserTable)
            {
                rowTD = row.FindElements(By.TagName("td"));
                var cell = 0;
                while (cell < rowTD.Count)
                {
                    if (rowTD[cell].Text.ToString() == strValue)
                    {
                        ActiveTableRow = rowTD[cell];
                        return ActiveTableRow;
                    }
                    cell++;
                }
            }
            return ActiveTableRow;
        }

        /// <summary>
        /// Finds the checkbox element of a row given the existence of a specific value
        /// </summary>
        /// <param name="table">table to search in</param>
        /// <param name="strValue">string to search for</param>
        /// <returns>Returns the web element of the checkbox in the specified table</returns>
        public IWebElement FindTableCheckboxWithValue(IList<IWebElement> table, string strValue)
        {
            IWebElement ActiveTableRow = table[0].FindElement(By.XPath("//*[contains(text(),'" + strValue + "')]"));

            return ActiveTableRow;
        }

        /// <summary>
        /// Finds the table row with value.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="strValue">The string value.</param>
        /// <returns>The row cell that specifically contains that value.</returns>
        public IWebElement FindTableRowWithValue(IList<IWebElement> table, string strValue)
        {
            IList<IWebElement> rowTD;
            IWebElement ActiveTableRow = null;
            foreach (var row in table)
            {
                rowTD = row.FindElements(By.TagName("td"));
                var cell = 0;
                while (cell < rowTD.Count)
                {
                    if (rowTD[cell].Text.Contains(strValue))
                    {
                        return rowTD[cell];
                    }
                    cell++;
                }
            }
            return ActiveTableRow;
        }

    }
}
