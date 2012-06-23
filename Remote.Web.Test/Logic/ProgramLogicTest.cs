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
using Remote.Web.Exceptions;
using Remote.Web.Logic;

namespace Remote.Web.Test.Logic
{
    [TestClass]
    public class ProgramLogicTest
    {
        #region -Get
        [TestMethod]
        public void Get_Returns_Object_If_Found()
        {
            //arrange
            var id = 10;
            var mockRepo = new Mock<IRemoteEntities>();
            var program = new Program() { Id = id };
            var dbSet = new FakeDbSet<Program>(program);
            mockRepo.SetupGet(m => m.Programs)
                    .Returns(dbSet);

            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new ProgramLogic();
            var actual = logic.Get(id);

            //assert
            Assert.AreEqual(program, actual);
        }

        [TestMethod]
        public void Get_Returns_Null_If_Not_Found()
        {
            //arrange
            var id = 10;
            var mockRepo = new Mock<IRemoteEntities>();
            var program = new Program() { Id = -1 };
            var dbSet = new FakeDbSet<Program>(program);
            mockRepo.SetupGet(m => m.Programs)
                    .Returns(dbSet);

            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new ProgramLogic();
            var actual = logic.Get(id);

            //assert
            Assert.IsNull(actual);
        }
        #endregion

        #region -GetAll
        [TestMethod]
        public void GetAll_Returns_All_When_Exist()
        {
            //arrange
            var programs = new List<Program>()
            {
                new Program() { Id = 2 },
                new Program() { Id = 3 },
                new Program() { Id = 5 }
            };
            var mockRepo = new Mock<IRemoteEntities>();
            mockRepo.SetupGet(m => m.Programs)
                    .Returns(new FakeDbSet<Program>(programs));

            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new ProgramLogic();
            var actual = logic.GetAll();

            //assert
            AssertHelper.ListEqual(programs, actual);
        }

        [TestMethod]
        public void GetAll_Returns_Empty_List_When_None()
        {
            //arrange
            var programs = new List<Program>();
            var mockRepo = new Mock<IRemoteEntities>();
            mockRepo.SetupGet(m => m.Programs)
                    .Returns(new FakeDbSet<Program>(programs));

            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new ProgramLogic();
            var actual = logic.GetAll();

            //assert
            AssertHelper.ListEqual(programs, actual);
        }
        #endregion

        #region -Create
        [TestMethod]
        public void Create_Throws_Exception_If_Program_Has_Id_Not_Equal_To_0()
        {
            //arrange
            var program = new Program() { Id = 1 };
            var exceptionWasThrown = false;

            //act
            var logic = new ProgramLogic();
            try
            {
                var result = logic.Create(program);
            }
            catch (ValidationException)
            {
                exceptionWasThrown = true;
            }

            //assert
            Assert.IsTrue(exceptionWasThrown, "Create should have thrown an exception");
        }

        [TestMethod]
        public void Create_Returns_Object_With_Id_On_Success()
        {
            //arrange
            var program = new Program();
            var mockRepo = new Mock<IRemoteEntities>();
            var dbSet = new FakeDbSet<Program>();
            mockRepo.SetupGet(m => m.Programs)
                    .Returns(dbSet);

            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new ProgramLogic();
            var result = logic.Create(program);

            //assert
            Assert.AreEqual(1, dbSet.Count(), "No items were saved to the db");
            Assert.AreEqual(dbSet.First(), result, "The item returned was not the same as the one in the database");
            mockRepo.Verify(m => m.SaveChanges(), Times.Once(), "The changes were not saved to the database");
        }
        #endregion
    }
}
