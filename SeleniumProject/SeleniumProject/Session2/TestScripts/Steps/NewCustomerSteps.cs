using AutomationProject.Session1.Containers;
using AutomationProject.Session1.Contracts.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Unity.Resolution;

namespace AutomationProject.Session1.TestScripts.Steps
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
        [Given(@"the user enters same data for new customer")]
        public void GivenTheUserEntersValidDataForNewCustomer()
        {
            newCustomer.EnterValidDataForNewCustomer();
        }

        [When(@"the user clicks on submit new customer")]
        public void WhenTheUserClicksOnSubmit()
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


        [Given(@"a new valid user is created")]
        public void NewValidUserIsCreated()
        {
            TheUserOpensTheNewCustomerTab();
            GivenTheUserEntersValidDataForNewCustomer();
            WhenTheUserClicksOnSubmit();
            ThenTheNewCustomerIsCreated();
        }

        [Then(@"the new customer is not created")]
        public void ThenTheNewCustomerIsNotCreated()
        {
            WhenTheUserClicksOnSubmit();
            newCustomer.CheckNewUserIsNotCreated();
        }

    }
}
