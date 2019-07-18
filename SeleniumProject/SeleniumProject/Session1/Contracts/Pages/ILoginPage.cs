namespace SeleniumProject.Session1.Contracts.Pages
{
    public interface ILoginPage
    {
        /// <summary>
        /// Script to send User Name
        /// </summary>
        /// <param name="name"></param>
        void EnterUserName(string name);

        /// <summary>
        /// Script to send User Password
        /// </summary>
        /// <param name="name"></param>
        void EnterUserPassword(string password);

        /// <summary>
        /// Click in Login button
        /// </summary>
        void ClickLoginButton();

        /// <summary>
        /// Script to check that the user is at Manager/homepage tab
        /// </summary>
        void CheckUserIsAtHomepage();
    }
}
