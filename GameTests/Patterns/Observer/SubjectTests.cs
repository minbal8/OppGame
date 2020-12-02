using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Tests
{
    [TestClass()]
    public class SubjectTests
    {
        [TestMethod()]
        public void AttachTest()
        {
            Button button = new Button(5, 5);
            Valve valve = new Valve(new Point(5, 5), new Point(3, 2));
            button.Attach(valve);
            Assert.IsNotNull(button);

        }

        [TestMethod()]
        public void DettachTest()
        {
            Button button = new Button(5, 5);
            Valve valve = new Valve(new Point(5, 5), new Point(3, 2));
            button.Attach(valve);
            button.Dettach(valve);
            Assert.IsNotNull(button);
        }

        [TestMethod()]
        public void GetStateTest()
        {
            Button button = new Button(5, 5);
            int ObserverState = button.GetState();
            Assert.AreEqual(0, ObserverState);
        }

        [TestMethod()]
        public void NotifyTest()
        {
            Button button = new Button(5, 5);
            Valve valve = new Valve(new Point(5, 5), new Point(3, 2));
            button.Attach(valve);

            var before = valve.GetState();
            button.Notify();
            var after = valve.GetState();

            Assert.AreNotEqual(before, after);
        }
    }
}