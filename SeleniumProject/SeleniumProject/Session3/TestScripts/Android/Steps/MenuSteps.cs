using AutomationProject.Containers;
using AutomationProject.Contracts.Pages;
using AutomationProject.TestScripts.Steps;
using TechTalk.SpecFlow;
using Unity.Resolution;

namespace SeleniumProject.Session3.TestScripts.Android.Steps
{
    [Binding]
    public class MenuSteps : StepBase
    {
        /// <summary>
        /// Instantiates the basicPage interface
        /// </summary>
        private readonly IMenuPage menuPage;

        public MenuSteps()
        {
            menuPage = ContainerDependencies.Container.Resolve(typeof(IMenuPage), null,
                new ParameterOverride("androidDriver", AndroidDriver)) as IMenuPage;
        }


        [When(@"the user opens the Equation Solver menu")]
        public void WhenTheUserOpensTheEquationSolverMenu()
        {
            menuPage.SwipeToLeft();
            menuPage.SwipeToLeft();
            menuPage.SwipeToLeft();
        }

    }
}
