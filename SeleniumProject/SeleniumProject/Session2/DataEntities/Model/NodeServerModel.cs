using Newtonsoft.Json;
using System;

namespace AutomationProject.DataEntities.Model
{
    public class NodeServerModel
    {
        /// <summary>
        /// Node server ID
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// MongoDbApi address
        /// </summary>
        [JsonProperty("databaseAddress")]
        public string DatabaseAddress { get; set; }

        /// <summary>
        /// MongoDB Identity address
        /// </summary>
        [JsonProperty("webapiaddress")]
        public string WebApiAddress { get; set; }

        /// <summary>
        /// Node server address
        /// </summary>
        [JsonProperty("environment")]
        public string Environment { get; set; }
    }
}
