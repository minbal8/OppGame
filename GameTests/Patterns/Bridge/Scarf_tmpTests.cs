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
    public class Scarf_tmpTests
    {

        [TestMethod()]
        public void DrawTest()
        {
            PictureBox p = new PictureBox();
            var scarf = new Scarf_tmp(p);
            scarf.ItemColor = new Blue();
            scarf.Draw();
            Assert.AreEqual(1, p.Controls.Count);
        }

        [TestMethod()]
        public void ScarfItemTest()
        {
            PictureBox p = new PictureBox();
            var scarf = new Scarf_tmp(p);
            string returnedCollor = scarf.ScarfItem();
            string expectedValue = "Scarf";
            Assert.AreEqual(expectedValue, returnedCollor);
        }

        [TestMethod()]
        public void addScarfTest()
        {
            PictureBox p = new PictureBox();
            var scarf = new Scarf_tmp(p);
            scarf.addScarf(p);
            Assert.AreEqual(1, p.Controls.Count);
        }
    }
}