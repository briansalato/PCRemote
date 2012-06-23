using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Remote.Web.Data.Interfaces;
using Moq;
using Remote.Web.Data;
using Remote.Web.Logic;
using Remote.Web.DTO;

namespace Remote.Web.Test.Logic
{
    [TestClass]
    public class RemoteLogicTest
    {
        #region -GetByProgramId
        [TestMethod]
        public void GetByProgramId_Returns_Object_If_Found()
        {
            //arrange
            var programId = 10;
            var mockRepo = new Mock<IRemoteEntities>();
            var program = new Program() { Id = programId };
            var remote = new DTO.Remote()
            {
                Id = 7,
                Programs = new List<Program>()
                {
                    program
                }
            };
            var dbSet = new FakeDbSet<DTO.Remote>(remote);
            mockRepo.SetupGet(m => m.Remotes)
                    .Returns(dbSet);

            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new RemoteLogic();
            var actual = logic.GetByProgramId(programId);

            //assert
            Assert.AreEqual(remote, actual);
        }

        [TestMethod]
        public void GetByProgramId_Returns_Null_If_Not_Found()
        {
            //arrange
            var programId = 10;
            var mockRepo = new Mock<IRemoteEntities>();
            var program = new Program() { Id = -1 };
            var remote = new DTO.Remote()
            {
                Id = 7,
                Programs = new List<Program>()
                {
                    program
                }
            };
            var dbSet = new FakeDbSet<DTO.Remote>(remote);
            mockRepo.SetupGet(m => m.Remotes)
                    .Returns(dbSet);


            DataFactory.Set(mockRepo.Object);

            //act
            var logic = new RemoteLogic();
            var actual = logic.GetByProgramId(programId);

            //assert
            Assert.IsNull(actual);
        }
        #endregion
    }
}
