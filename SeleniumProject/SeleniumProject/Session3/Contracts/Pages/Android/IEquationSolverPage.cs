namespace AutomationProject.Contracts.Pages
{
    public interface IEquationSolverPage
    {
        void ClickButton(string btnType);

        void CheckResult(string expectedResult);
    }
}