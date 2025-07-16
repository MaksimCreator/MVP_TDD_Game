using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class LoaderTest : BaseTest
    {
        [Test]
        public void LoadAllTypesGame_Load()
        {
            ArmyLoader armyLoader = GetSevice<ArmyLoader>();
            GameDataLoader gameDataLoader = GetSevice<GameDataLoader>();
            MoneyLoader moneyLoader = GetSevice<MoneyLoader>();
            MoneyTapLoader moneyTapLoader = GetSevice<MoneyTapLoader>();
            MoneyTimeLoader moneyTimeLoader = GetSevice<MoneyTimeLoader>();


            ArmyStorage armyStorage = armyLoader.Load();
            GameData gameData = gameDataLoader.Load();
            MoneyStorage moneyStorage = moneyLoader.Load();
            MoneyTapStorage moneyTapStorage = moneyTapLoader.Load();
            MoneyTimeStorage moneyTimeStorage = moneyTimeLoader.Load();


            Assert.IsNotNull(armyStorage);
            Assert.IsNotNull(gameData);
            Assert.IsNotNull(moneyStorage);
            Assert.IsNotNull(moneyTapStorage);
            Assert.IsNotNull(moneyTimeStorage);
        }
    }
}