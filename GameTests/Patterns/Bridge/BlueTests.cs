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
    public class BlueTests
    {
        [TestMethod()]
        public void ColorTest()
        {
            var blue = new Blue();
            string returnedCollor = blue.Color() ;
            string expectedValue = "Blue";

            Assert.AreEqual(expectedValue, returnedCollor);
        }
    }
}