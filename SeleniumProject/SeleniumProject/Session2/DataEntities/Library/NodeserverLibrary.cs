using AutomationProject.DataEntities.Model;
using SeleniumProject.DataEntities.Library;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AutomationProject.DataEntities.Library
{
    public class NodeServerLibrary : Helper
    {

        /// <summary>
        /// Returns the user details as specified by the user's role
        /// </summary>
        public string GetServerUrl(string environment = null)
        {
            if (string.IsNullOrEmpty(environment))
            {
                environment = "localhost";
            }
            var nodeList = GetJsonDeserialize<List<NodeServerModel>>("nodeserver.json").Where(item => item.Environment == environment);

            var node = nodeList.ToList()[GenerateRandomIndex(nodeList.Count())];

            ConfigurationManager.AppSettings["WebApiAddress"] = node.WebApiAddress;

            return node.Server;
        }
    }
}
