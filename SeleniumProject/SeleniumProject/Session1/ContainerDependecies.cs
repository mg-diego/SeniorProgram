using AutomationProject.Session1.Contracts;
using AutomationProject.Session1.Contracts.Pages;
using AutomationProject.Session1.SeleniumScripts.Pages;
using SeleniumScripts;
using Unity;
using Unity.Lifetime;

namespace AutomationProject.Session1.Containers
{
    public static class ContainerDependencies
    {
        /// <summary>
        /// Instantiates the container
        /// </summary>
        public static IUnityContainer Container { get; private set; }

        /// <summary>
        /// Creates the containers used under the Contracts folder
        /// </summary>
        public static IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<ISetupDriver, SetupDriver>(new HierarchicalLifetimeManager());
            /*
            container.RegisterType<ILoginPage, LoginPage>(new HierarchicalLifetimeManager());
            container.RegisterType<INewCustomer, NewCustomerPage>(new HierarchicalLifetimeManager());
            */

            Container = container;

            return container;
        }
    }
}



