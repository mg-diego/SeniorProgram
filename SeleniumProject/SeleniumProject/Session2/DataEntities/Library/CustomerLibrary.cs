using AutomationProject.DataEntities.Model;
using SeleniumProject.DataEntities.Library;
using System.Collections.Generic;
using System.Linq;

namespace AutomationProject.DataEntities.Library
{
    public class CustomerLibrary : Helper
    {

        /// <summary>
        /// Returns the user details as specified by the user's role
        /// </summary>
        public string[] GetCustomerDetails(string username)
        {
            var customerDetails = GetJsonDeserialize<List<CustomerModel>>("Customer.json").Where(item => item.CustomerName == username);

            var userName = customerDetails.Select(item => item.CustomerName);
            var gender = customerDetails.Select(item => item.Gender);
            var address = customerDetails.Select(item => item.Address);
            var city = customerDetails.Select(item => item.City);
            var state = customerDetails.Select(item => item.State);
            var pin = customerDetails.Select(item => item.Pin);
            var phoneNo = customerDetails.Select(item => item.PhoneNo);
            var email = customerDetails.Select(item => item.Email);

            var node = new string[8];
            node[0] = userName.ToList()[GenerateRandomIndex(userName.Count())];
            node[1] = gender.ToList()[GenerateRandomIndex(gender.Count())];
            node[2] = address.ToList()[GenerateRandomIndex(address.Count())];
            node[3] = city.ToList()[GenerateRandomIndex(city.Count())];
            node[4] = state.ToList()[GenerateRandomIndex(state.Count())];
            node[5] = pin.ToList()[GenerateRandomIndex(pin.Count())];
            node[6] = phoneNo.ToList()[GenerateRandomIndex(phoneNo.Count())];
            node[7] = email.ToList()[GenerateRandomIndex(email.Count())];

            return node;
        }
    }
}
