using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class GameDataTest
    {
        [Test]
        public void IndexSwithTest_SetIndexArmy_SetIndexTap_SetIndexTime()
        {
            int value = 5;
            GameData gameData = new GameData();


            gameData.SetIndexArmy(value);
            gameData.SetIndexMoneyTime(value);
            gameData.SetIndexMoneyTap(value);


            Assert.AreEqual(gameData.IndexMoneyTap, value);
            Assert.AreEqual(gameData.IndexArmy, value);
            Assert.AreEqual(gameData.IndexMoneyTime, value);
        }
    }
}