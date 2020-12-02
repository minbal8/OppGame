﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Tests
{
    [TestClass()]
    public class RedTests
    {
        [TestMethod()]
        public void ColorTest()
        {
            var red = new Red();
            string returnedCollor = red.Color();
            string expectedValue = "Red";

            Assert.AreEqual(expectedValue, returnedCollor);
        }
    }
}