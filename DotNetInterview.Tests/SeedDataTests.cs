using DotNetInterview.API;
using DotNetInterview.API.Controllers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DotNetInterview.Tests
{
    public class SeedDataTests
    {
        private DataContext _dataContext;

        [SetUp]
        public void Setup()
        {
            var connection = new SqliteConnection("Data Source=DotNetInterview;Mode=Memory;Cache=Shared");
            connection.Open();
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(connection)
                .Options;
            _dataContext = new DataContext(options);
        }

        [Test]
        public void Example_to_ensure_dbcontext_has_seed_data()
        {
            var subject = new ExampleController(_dataContext);
            var result = subject.Get();
            Assert.That(result.Count(), Is.EqualTo(3));
        }
    }
}
