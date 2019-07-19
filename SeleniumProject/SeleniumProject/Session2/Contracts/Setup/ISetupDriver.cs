
namespace AutomationProject.Contracts
{
    /// <summary>
    /// Interface that defines the methods that the Setup Driver has to implement.
    /// </summary>
    public interface ISetupDriver
    {
        /// <summary>
        /// Prepares the web driver
        /// </summary>
        void LoadWebDriver();

        /// <summary>
        /// Prepares the api driver
        /// </summary>
        void LoadAPIDriver();
    }
}
