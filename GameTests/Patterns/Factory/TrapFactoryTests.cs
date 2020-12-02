using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameClient.Tests
{
    [TestClass()]
    public class TrapFactoryTests
    {
        [TestMethod()]
        [DataRow(1, typeof(FallTrap))]
        [DataRow(2, typeof(SawTrap))]
        [DataRow(3, typeof(Spikes))]
        public void CreateTrapTest(int trapType, Type type)
        {
            Factory factory = new TrapFactory();
            var temp = factory.CreateTrap(trapType, new Point(0, 0), new Point(1, 1));
            Assert.AreEqual(temp.GetType(), type);
        }
    }
}