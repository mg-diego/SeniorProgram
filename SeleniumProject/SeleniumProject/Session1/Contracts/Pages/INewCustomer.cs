namespace SeleniumProject.Session1.Contracts.Pages
{
    public interface INewCustomer
    {
        /// <summary>
        /// Script to add valid data at new Customer
        /// </summary>
        void EnterValidDataForNewCustomer();

        /// <summary>
        /// Script to click Submit button
        /// </summary>
        void ClickSubmitButton();

        /// <summary>
        /// Script to click Submit button
        /// </summary>
        void ClickNewCustomerTab();

        /// <summary>
        /// Script to check if new Customer is created
        /// </summary>
        void CheckNewCustomerIsCreated();
    }
}
