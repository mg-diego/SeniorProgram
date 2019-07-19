using System;

namespace AutomationProject.Session1.SeleniumScripts.Helpers
{
    public class SeleniumHelpers
    {

        public int GenerateRandomNumberBetween(int init, int end)
        {
            return new Random().Next(init, end);
        }
    }
}
