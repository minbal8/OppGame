using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Control;
using System.Drawing;

namespace GameClient.Tests
{
    [TestClass()]
    public class MapObjectAdapterTests
    {

        [TestMethod()]
        public void DrawLevelTest()
        {
            Level adapter = new Level();
            ControlCollection controls = new ControlCollection(new System.Windows.Forms.Control(""));
            adapter.AddPart(new Wall(new Point(1, 1), new Point(2, 10)));
            adapter.DrawLevel(controls);
            Assert.AreEqual(1,controls.Count);
        }
    }
}