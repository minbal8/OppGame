using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;

namespace GameClient.Tests
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void GameSingletonTest()
        {
            int oldID = 1;
            GameStateSingleton.getInstance().ClientID = oldID;
            int newID = GameStateSingleton.getInstance().ClientID;
            Assert.AreEqual(oldID, newID);
        }

    }
}
