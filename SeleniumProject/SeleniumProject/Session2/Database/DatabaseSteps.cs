using SeleniumProject.Database;
using TechTalk.SpecFlow;

namespace AutomationProject.TestScripts.Steps
{
    [Binding]
    public class DatabaseSteps
    {
        [Given(@"the following users are inserted into the database")]
        public void GivenFollowingUsersAreInsertedIntoDatabase(Table table)
        {
            var seeder = new DatabaseSeeder();

            foreach (var row in table.Rows)
            {
                var userName = row["Name"];
                var userSalary = row["Salary"];
                var userAge = row["Age"];
                seeder.InsertUserIntoDatabase();
            }
        }

        [Given(@"'(.*)' users are inserted into database")]
        public void GivenUsersAreInsertedIntoDatabase(int p0)
        {

        }

    }
}
