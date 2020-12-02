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
    public class ObserverTests
    {
        [TestMethod()]
        public void UpdateTest()
        {
            Button tempButton = new Button(1, 1);
            Valve tempValve = new Valve(new Point(2, 2), new Point(3, 8));
            tempButton.SetAlgorithm(new OpenActivation());
            tempButton.Attach(tempValve);
            var temp = tempValve.GetState();
            tempButton.Notify();
            var temp2 = tempValve.GetState();

            Assert.AreNotEqual(temp, temp2);
        }

        [TestMethod()]
        public void SetSubjectTest()
        {
            Button tempButton = new Button(1, 1);
            Observer tempValve = new Valve(new Point(2, 2), new Point(3, 8));

            tempValve.SetSubject(tempButton);

            Assert.IsTrue(true);
        }
    }
}