using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Tests
{
    [TestClass()]
    public class ButtonAlgorithmTests
    {
        [TestMethod()]
        public void ActivateOpenTest()
        {
            OpenActivation tempalg = new OpenActivation();
            Assert.AreEqual(1, tempalg.Activate());
        }

        [TestMethod()]
        public void ActivateCloseTest()
        {
            CloseActivation tempalg = new CloseActivation();
            Assert.AreEqual(0, tempalg.Activate());
        }

        [TestMethod()]
        public void ActivateTimedTest()
        {
            TimedActivation tempalg = new TimedActivation();
            Assert.AreEqual(1, tempalg.Activate());
        }

    }
}