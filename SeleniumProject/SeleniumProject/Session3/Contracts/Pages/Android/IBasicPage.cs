﻿namespace AutomationProject.Contracts.Pages
{
    public interface IBasicPage
    {
        void CheckIsAtBasicPage();

        void ClickButton(string btnType);

        void CheckResult(string expectedResult);
    }
}
