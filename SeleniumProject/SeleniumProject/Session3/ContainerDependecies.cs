using AutomationProject.Contracts;
using AutomationProject.Contracts.Pages;
using AutomationProject.SeleniumScripts.Pages;
using SeleniumProject.Session3.SeleniumScripts.Pages;
using SeleniumProject.Session3.SeleniumScripts.Pages.Android;
using SeleniumScripts;
using Unity;
using Unity.Lifetime;

namespace AutomationProject.Containers
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
            container.AddExtension(new Diagnostic());

            container.RegisterType<ISetupDriver, SetupDriver>(new HierarchicalLifetimeManager());
            container.RegisterType<ILoginPage, LoginPage>(new HierarchicalLifetimeManager());
            container.RegisterType<INewCustomer, NewCustomerPage>(new HierarchicalLifetimeManager());


            container.RegisterType<IBasicPage, BasicPage>(new HierarchicalLifetimeManager());
            container.RegisterType<IMenuPage, MenuPage>(new HierarchicalLifetimeManager());
            container.RegisterType<IEquationSolverPage, EquationSolverPage>(new HierarchicalLifetimeManager());

            Container = container;

            return container;
        }
    }
}



