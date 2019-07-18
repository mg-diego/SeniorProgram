using SeleniumProject.Session1.Containers;
using SeleniumProject.Session1.Contracts.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Unity.Resolution;

namespace SeleniumProject.Session1.TestScripts.Steps
{
    [Binding]
    public class NewCustomerSteps : StepBase
    {
        /// <summary>
        /// Instantiates the login page interface
        /// </summary>
        private readonly INewCustomer newCustomer;

        /// <summary>
        /// Instantiates the driver for use
        /// </summary>
        public NewCustomerSteps()
        {
            newCustomer = ContainerDependencies.Container.Resolve(typeof(INewCustomer), null,
                new ParameterOverride("driver", Driver)) as INewCustomer;
        }

        [Given(@"the user enters valid data for new customer")]
        public void GivenTheUserEntersValidDataForNewCustomer()
        {
            newCustomer.EnterValidDataForNewCustomer();
        }

        [When(@"the user clicks on submit new customer")]
        public void WhenTheUserClicksOn()
        {
            newCustomer.ClickSubmitButton();
        }


        [Given(@"the user opens the New Customer tab")]
        public void TheUserOpensTheNewCustomerTab()
        {
            newCustomer.ClickNewCustomerTab();
        }

        [Then(@"the new customer is created")]
        public void ThenTheNewCustomerIsCreated()
        {
            newCustomer.CheckNewCustomerIsCreated();
        }

    }
}
