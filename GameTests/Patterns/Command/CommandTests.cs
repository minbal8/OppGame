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
    public class CommandTests
    {

        [TestMethod()]
        public void ExecuteTest()
        {
            AbstractLevelFactory easy = new EasyLevelFactory();
            LoadEasyLogicLevel easyLogicLevel = new LoadEasyLogicLevel(easy);
            var temp = easyLogicLevel.Execute();
            Assert.IsTrue(temp is LogicLevel);
        }
    }
}