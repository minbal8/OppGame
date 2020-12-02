using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class WearableTests
    {
        [TestMethod()]
        public void SkinTest()
        {
            PictureBox p = new PictureBox();

            Wearable hat = new Hat(p);
            hat.ItemColor = new Red();

            Wearable scarf = new Scarf_tmp(p);
            scarf.ItemColor = new Blue();

            DefaultSkin ds = new DefaultSkin();

            hat.setSkin(ds);
            scarf.setSkin(hat);
            scarf.Skin();

            Assert.AreEqual(2, p.Controls.Count);
        }
    }
}