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
    public class HatTests
    {
        [TestMethod()]
        public void DrawTest()
        {
            PictureBox p = new PictureBox();
            var hat = new Hat(p);
            hat.ItemColor = new Blue();
            hat.Draw();
            Assert.AreEqual(1, p.Controls.Count);
        }

        [TestMethod()]
        public void HatItemTest()
        {
            PictureBox p = new PictureBox();
            var hat = new Hat(p);
            string returnedCollor = hat.HatItem();
            string expectedValue = "Hat";
            Assert.AreEqual(expectedValue, returnedCollor);
        }

        [TestMethod()]
        public void addHatTest()
        {
            PictureBox p = new PictureBox();
            var hat = new Hat(p);
            hat.addHat(p);
            Assert.AreEqual(1, p.Controls.Count);
        }

        [TestMethod()]
        public void GetPlayerPositionTest()
        {
            PictureBox p = new PictureBox();
            var hat = new Hat(p);
            string position = hat.GetPlayerPosition();

            Assert.AreEqual("{X=0,Y=0}", position);
        }

    }
}