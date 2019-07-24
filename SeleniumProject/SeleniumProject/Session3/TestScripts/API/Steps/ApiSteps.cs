using FluentAssertions;
using RestSharp;
using System;
using System.Configuration;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using SeleniumProject.Database;
using System.Collections.Generic;

namespace AutomationProject.TestScripts.Steps
{
    [Binding]
    public class ApiSteps
    {
        public static RestRequest request;
        public static IRestResponse response;

        [When(@"the following employees api resource is requested")]
        public void WhenTheFollowingEmployeesApiResourceIsRequested(Table table)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["WebApiAddress"]+$"/employees");
            request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            response = client.Execute(request);
        }

        [When(@"the following employee api resource is requested")]
        public void WhenTheFollowingEmployeeApiResourceIsRequested(Table table)
        {
            var id = GetUserByName(table.Rows[0]["Name"].ToLowerInvariant());

            var client = new RestClient(ConfigurationManager.AppSettings["WebApiAddress"] + $"/employee/"+id);
            request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            response = client.Execute(request);
        }


        [Given(@"the following create employee api resource is requested")]
        [When(@"the following create employee api resource is requested")]
        public void GivenTheFollowingCreateEmployeeApiResourceIsRequested(Table table)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["WebApiAddress"] + $"/create");
            request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            var list = new List<string>
            {
                "{",
                $"\"name\":\"{table.Rows[0]["Name"]}\",",
                $"\"salary\":\"{table.Rows[0]["Salary"]}\",",
                $"\"age\":\"{table.Rows[0]["Age"]}\"",
                "}"
            };
            var body = string.Join("", list);
            request.AddParameter("undefined", body, ParameterType.RequestBody);

            response = client.Execute(request);
        }

        [Given(@"the following update employee api resource is requested")]
        [When(@"the following update employee api resource is requested")]
        public void GivenTheFollowingUpdateEmployeeApiResourceIsRequested(Table table)
        {
            var id = GetUserByName(table.Rows[0]["Name"].ToLowerInvariant());

            var client = new RestClient(ConfigurationManager.AppSettings["WebApiAddress"] + $"/update/"+id);
            request = new RestRequest(Method.PUT);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            var list = new List<string>
            {
                "{",
                $"\"name\":\"{table.Rows[0]["NewName"]}\",",
                $"\"salary\":\"{table.Rows[0]["Salary"]}\",",
                $"\"age\":\"{table.Rows[0]["Age"]}\"",
                "}"
            };
            var body = string.Join("", list);
            request.AddParameter("undefined", body, ParameterType.RequestBody);

            response = client.Execute(request);
        }

        [When(@"the following delete employee api resource is requested")]
        public void WhenTheFollowingDeleteEmployeeApiResourceIsRequested(Table table)
        {
            var id = GetUserByName(table.Rows[0]["Name"].ToLowerInvariant());

            var client = new RestClient(ConfigurationManager.AppSettings["WebApiAddress"] + $"/delete/" + id);
            request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            response = client.Execute(request);
        }



        [Then(@"a response with http code '(.*)' is received")]
        public void ThenAResponseWithHttpCodeIsReceived(string expectedHttpStatus)
        {
            ((int)response.StatusCode).Should().Be(Int32.Parse(expectedHttpStatus));
        }

        [Then(@"the response body contains '(.*)'")]
        public void ThenTheResponseBodyContains(string expectedBody)
        {
            ThenTheResponseBodyShouldContainExactlyMatches(expectedBody, "1");
        }

        [Then(@"the response body contains '(.*)' exactly '(.*)' times")]
        public void ThenTheResponseBodyShouldContainExactlyMatches(string parameter, string numberOfMatches)
        {
            var countMatches = Regex.Matches(response.Content, parameter).Count;
            countMatches.Should().Be(Int32.Parse(numberOfMatches), "\n -Response: "+ response.Content + "\n -ExpectedParameter: "+ parameter);
        }


        private string GetUserByName(string name)
        {
            var seeder = new DatabaseSeeder();
            var id = "";

            switch (name.ToLowerInvariant())
            {
                case "wronguser":
                    id = "111111111111";
                    break;
                case "empty":
                    id = "";
                    break;

                default:
                    id = seeder.GetUserIdFromDatabase();
                    break;
            }

            return id;
        }

    }
}




