using Newtonsoft.Json;
using AutomationProject.Session1.DataEntities.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace AutomationProject.Session1.DataEntities.Library
{
    public class CustomerLibrary
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

        /// <summary>
        /// Deserializes the json file data and returns an object
        /// </summary>
        /// <param name="fileName">file to be deserialized</param>
        protected T GetJsonDeserialize<T>(string fileName)
        {
            var path = string.Format(CultureInfo.InvariantCulture, @"{0}\Session1\DataEntities\json\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"the file in the following path is not found: {path} ");
            }

            T obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return obj;
        }

        /// <summary>
        /// Random Number Generator that provides a random number from 0 to the specified value
        /// </summary>
        /// <param name="count">upper limit number</param>
        public int GenerateRandomIndex(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            var rng = new RNGCryptoServiceProvider();
            var bytes = new byte[8];
            rng.GetBytes(bytes);
            ulong i = BitConverter.ToUInt64(bytes, 0) % (uint)count;
            int iValue = (int)i;

            return iValue;
        }
    }
}
