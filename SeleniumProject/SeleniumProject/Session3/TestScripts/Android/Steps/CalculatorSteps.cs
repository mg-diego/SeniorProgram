using AutomationProject.Containers;
using AutomationProject.Contracts.Pages;
using TechTalk.SpecFlow;
using Unity.Resolution;

namespace AutomationProject.TestScripts.Steps
{
    [Binding]
    public class CalculatorSteps : StepBase
    {
        /// <summary>
        /// Instantiates the basicPage interface
        /// </summary>
        private readonly IBasicPage basicPage;

        public CalculatorSteps()
        {
            basicPage = ContainerDependencies.Container.Resolve(typeof(IBasicPage), null,
                new ParameterOverride("androidDriver", AndroidDriver)) as IBasicPage;
        }


        [Given(@"the user opens the calculator app")]
        public void GivenTheUserOpensTheCalculatorApp()
        {
            basicPage.ClosePopupOpenApp();
        }

    }
}
