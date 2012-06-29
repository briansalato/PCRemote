using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Remote.Web.Logic;

namespace Remote.Web.Test.Logic
{
    [TestClass]
    public class WindowsLogicTest
    {
        [TestMethod]
        public void ExecuteCommand_Returns_False_When_Command_Fails()
        {
            //arrange

            //act
            var logic = new WindowsLogic();
            var actual = logic.ExecuteCommand("asdf");

            //assert
            Assert.IsFalse(actual);
        }
    }
}
