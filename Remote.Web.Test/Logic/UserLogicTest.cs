using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Remote.Web.Models;
using Remote.Web.Data;
using Remote.Web.DTO;
using Moq;
using Remote.Web.Data.Interfaces;

namespace Remote.Web.Test.Logic
{
    [TestClass]
    public class UserLogicTest
    {
        #region -GetUser
        [TestMethod]
        public void GetUser_Returns_User_When_Found()
        {
            //arrange
            var userId = 10;
            var user = new RemoteUser() { Id = userId };
            var mockRepo = new Mock<IRemoteEntities>();
            mockRepo.SetupGet(m => m.Users)
                    .Returns(new FakeDbSet<RemoteUser>(user));

            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new UserLogic();
            var actual = logic.GetUser(userId);

            //assert
            Assert.AreEqual(user, actual, "The user returned was not the right user");
        }

        [TestMethod]
        public void GetUser_Returns_Null_When_Not_Found()
        {
            //arrange
            var userId = 10;
            var user = new RemoteUser() { Id = -1 };
            var mockRepo = new Mock<IRemoteEntities>();
            mockRepo.SetupGet(m => m.Users)
                    .Returns(new FakeDbSet<RemoteUser>(user));

            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new UserLogic();
            var actual = logic.GetUser(userId);

            //assert
            Assert.IsNull(actual, "Null should have been returned for a user that wasn't found");
        }
        #endregion
    }
}
