using System;
using System.Linq;
using NUnit.Framework;
using Storage;

namespace Test
{
    [TestFixture]
    public class StorageTest
    {
        private readonly IServiceDeskStorage _storage;

        public StorageTest()
        {
            const string normalConnString = "Server=localhost;Port=3306;Database=2x2CRM;Uid=root;Pwd=123;SslMode=None;";
            const string ciConnString = "Server=localhost;Port=3306;Database=circle_test;SslMode=None;";
            _storage = new DescStorage(
                Environment.GetEnvironmentVariable("CI") == "true" ? ciConnString : normalConnString
            );
        }

        [Test]
        public void it_should_be_possible_to_get_all_issues()
        {
            var issues = _storage.Issues.ToList();
            Assert.AreEqual(issues.Count, 2);
            Assert.AreEqual(issues.First().Owner.Id, 8);
        }
    }
}