using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpendingTracker.Model.DomainObjects;
using SpendingTracker.Server.Repository;
using SpendingTracker.Server.Repository.SqlEFRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpendingTracker.Test
{
    [TestClass]
    public class SqlEFUserRepositoryTest : IDisposable
    {
        private SqlApplicationContext _context;

        public SqlEFUserRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<SqlApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new SqlApplicationContext(options);
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            // Arrange
            var userRepository = new SqlEFUserRepository(_context);
            Seed(_context);

            // Act
            var result = userRepository.GetAll();

            // Asserts
            Assert.AreEqual(10, result.Count());
        }

        [TestMethod]
        public void GetUserById()
        {
            // Arrange
            var userRepository = new SqlEFUserRepository(_context);
            Seed(_context);

            var testedGuid = Guid.Parse("9d8be4cb-c91a-46ca-a747-84693e0838bf");

            _context.Users.Add(new SystemUser(testedGuid)
            {
                Login = "TestedUser",
                Password = "IHaveNoPassword"
            });
            _context.SaveChanges();

            // Act
            var user = userRepository.GetObjectByID(testedGuid);

            // Asserts
            Assert.AreEqual("TestedUser", user.Login);
            Assert.AreEqual("IHaveNoPassword", user.Password);
            Assert.AreEqual(testedGuid, user.ObjectID);
        }

        private void Seed(SqlApplicationContext context)
        {
            context.Users.AddRange(Enumerable.Range(1, 10).Select(n => new SystemUser()
            {
                Login = "User " + n,
                Password = "123Pass" + n
            }));
            context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
