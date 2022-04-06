using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpendingTracker.Model.DomainObjects;
using SpendingTracker.Server.Controllers;
using SpendingTracker.Server.DTO;
using SpendingTracker.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpendingTracker.Test
{
    [TestClass]
    public class UserControllerTest : BaseControllerTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            // Arrange
            var controller = new UserController(_context);
            var entities = InitEntities().ToList();
            Seed(_context, entities);
            var testedUsers = entities.OfType<SystemUser>();
            var testedUser = testedUsers.FirstOrDefault(x => x.ObjectID == _testedGuid);

            // Act
            var result = controller.Get().ToList();

            // Assert
            Assert.AreEqual(testedUsers.Count(), result.Count);
            Assert.IsTrue(Enumerable.SequenceEqual(testedUsers.OrderBy(x => x.ObjectID).Select(x => x.ObjectID), result.OrderBy(x => x.ObjectID).Select(x => x.ObjectID)));
        }

        [TestMethod]
        public void GetUserByID()
        {
            // Arrange
            var controller = new UserController(_context);
            var entities = InitEntities().ToList();
            var testedUsers = entities.OfType<SystemUser>();
            Seed(_context, entities);
            var testedUser = testedUsers.FirstOrDefault(x => x.ObjectID == _testedGuid);

            // Act
            var result = controller.Get(_testedGuid);
            var actionResult = result.Result;
            var user = (actionResult.Result as OkObjectResult).Value as SystemUserFullInfo;

            // Assert
            Assert.AreEqual(testedUser.Login, user.Login);
            Assert.AreEqual(testedUser.ObjectID, user.ObjectID);
        }

        protected override IEnumerable<BaseModel> InitEntities()
        {
            var result = Enumerable.Range(0, 10).Select(x => new SystemUser(Guid.NewGuid())
            {
                Login = "user " + x,
                Password = "123qwe",
            });
            result = result.Append(new SystemUser(_testedGuid)
            {
                Login = "alleshka",
                Password = "123qwe"
            });
            return result;
        }
    }
}
