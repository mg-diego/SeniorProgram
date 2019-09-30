using AutomationProject.Containers;
using AutomationProject.Contracts.Pages;
using AutomationProject.TestScripts.Steps;
using TechTalk.SpecFlow;
using Unity.Resolution;

namespace SeleniumProject.Session3.TestScripts.Android.Steps
{
    [Binding]
    public class EquationSolverSteps : StepBase
    {
        /// <summary>
        /// Instantiates the basicPage interface
        /// </summary>
        private readonly IEquationSolverPage equationSolverPage;

        public EquationSolverSteps()
        {
            equationSolverPage = ContainerDependencies.Container.Resolve(typeof(IEquationSolverPage), null,
                new ParameterOverride("androidDriver", AndroidDriver)) as IEquationSolverPage;
        }

        [When(@"the user clicks button '(.*)' in Equation Solver")]
        public void WhenTheUserInputsEquation(string button)
        {
            equationSolverPage.ClickButton(button);
        }

        [Then(@"the result field shows '(.*)' in Equation Solver")]
        public void ThenTheResultFieldShowsInEquationSolver(string expectedResult)
        {
            equationSolverPage.CheckResult(expectedResult);
        }


    }
}
