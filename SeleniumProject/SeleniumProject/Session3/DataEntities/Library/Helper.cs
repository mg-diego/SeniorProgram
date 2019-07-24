using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace SeleniumProject.DataEntities.Library
{
    public class Helper
    {
        /// <summary>
        /// Deserializes the json file data and returns an object
        /// </summary>
        /// <param name="fileName">file to be deserialized</param>
        protected T GetJsonDeserialize<T>(string fileName)
        {
            var path = string.Format(CultureInfo.InvariantCulture, @"{0}\Session3\DataEntities\json\{1}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
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
