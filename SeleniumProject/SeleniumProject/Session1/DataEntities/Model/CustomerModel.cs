using Newtonsoft.Json;

namespace AutomationProject.Session1.DataEntities.Model
{
    public class CustomerModel
    {
        /// <summary>
        /// CustomerName
        /// </summary>
        [JsonProperty("Customer Name")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [JsonProperty("Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("Address")]
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("City")]
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [JsonProperty("State")]
        public string State { get; set; }

        /// <summary>
        /// Pin
        /// </summary>
        [JsonProperty("Pin")]
        public string Pin { get; set; }

        /// <summary>
        /// PhoneNo
        /// </summary>
        [JsonProperty("Phone No.")]
        public string PhoneNo { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty("Email")]
        public string Email { get; set; }
    }
}
