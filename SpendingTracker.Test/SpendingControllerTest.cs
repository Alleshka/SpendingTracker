using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpendingTracker.Model.DomainObjects;
using SpendingTracker.Server.Controllers;
using SpendingTracker.Server.DTO;
using SpendingTracker.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingTracker.Test
{
    [TestClass]
    public class SpendingControllerTest : BaseControllerTest
    {
        [TestMethod]
        public void GetSpendingsByIDTest()
        {
            // Arrange
            var controller = new SpendingController(_context);
            var entities = InitEntities().ToList();
            Seed(_context, entities);

            var testedUsers = entities.OfType<SystemUser>();
            var testedGroups = entities.OfType<SpendingGroup>();
            var testedSpendings = entities.OfType<Spending>();

            var testedUser = testedUsers.FirstOrDefault(x => x.ObjectID == _testedGuid);

            // Act
            var spendingGroups = controller.GetSpendings(_testedGuid).ToList();
            var spendings = spendingGroups.SelectMany(x => x.Spendings);

            // Assert
            Assert.AreEqual(testedGroups.Where(x => x.User.ObjectID == _testedGuid).Count(), spendingGroups.Count);
            Assert.AreEqual(testedGroups.Where(x => x.User.ObjectID == _testedGuid).SelectMany(x => x.Spendings).Count(), spendings.Count());
        }

        [TestMethod]
        public void AddSpendingGroupTestWithoutSpendings()
        {
            // Arrange
            var controller = new SpendingController(_context);
            var entities = InitEntities().ToList();
            Seed(_context, entities);

            var testedUsers = entities.OfType<SystemUser>();
            var testedGroups = entities.OfType<SpendingGroup>();
            var testedSpendings = entities.OfType<Spending>();

            var testedUser = testedUsers.FirstOrDefault(x => x.ObjectID == _testedGuid);

            // Act
            var guid = Guid.NewGuid();
            var spendingGroup = new SpendingGroupCreate()
            {
                Name = "newTestedCategory",
                UserID = _testedGuid
            };

            var result = controller.AddSpendingGroup(spendingGroup).Result;

            // Assert
            Assert.AreEqual(testedGroups.Where(x => x.User.ObjectID == _testedGuid).Count() + 1, _context.SpendingGroups.Where(x => x.UserID == _testedGuid).Count());

        }

        protected override IEnumerable<BaseModel> InitEntities()
        {
            var result = new List<BaseModel>();

            var user = new SystemUser(_testedGuid)
            {
                Login = "testedUser",
                Password = "123qwe"
            };

            var spendingGroup = new SpendingGroup(_testedGuid)
            {
                Name = "Snikers",
                User = user,
            };

            var spending1 = new Spending()
            {
                Description = "snikers",
                Sum = 100
            };
            var spending2 = new Spending()
            {
                Description = "snikers save",
                Sum = 10
            };

            var secondUser = new SystemUser()
            {
                Login = "alleshkaTest",
                Password = "123qwe"
            };

            var secondSpendingGroup = new SpendingGroup()
            {
                Name = "haha",
                User = secondUser,
            };

            var secondSpendings = new List<Spending>()
            {
                new Spending()
                {
                    Group = secondSpendingGroup,
                    Description = "hahaClassic"
                }
            };

            result.Add(user);
            result.Add(spendingGroup);
            result.Add(spending1);
            result.Add(spending2);
            result.Add(secondUser);
            result.Add(secondSpendingGroup);
            result.AddRange(secondSpendings);

            return result;
        }
    }
}
