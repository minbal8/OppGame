﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient.Tests
{
    [TestClass()]
    public class DecoratorTests 
    {
        [TestMethod()]
        public void SkinTest()
        {
            PictureBox p = new PictureBox();
            Wearable hat = new Hat(p);
            Assert.AreEqual("{X=0,Y=7}", hat.image.Location.ToString());
        }
    }
}