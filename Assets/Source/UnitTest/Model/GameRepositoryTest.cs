using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{
    [TestFixture]
    public class GameRepositoryTest : BaseTest
    {
        [Test]
        public void GameRepositoryTest_Save()
        {
            int dataSaveValue,dataLoadValue; 
            int valueMoneyTapStorage = 10;
            ISaveLoaderGame saveLoaderGame = GetSevice<ISaveLoaderGame>();
            MoneyTapStorage moneyTapStorageSave = new MoneyTapStorage(0);
            Dictionary<string,object> dataSave = new Dictionary<string, object>();
            Dictionary<string,object> dataLoad = new Dictionary<string, object>();

            dataSave.Add(typeof(MoneyTimeStorage).ToString(), GetSevice<MoneyTimeLoader>().Load());
            dataSave.Add(typeof(GameData).ToString(), GetSevice<GameDataLoader>().Load());
            dataSave.Add(typeof(MoneyStorage).ToString(), GetSevice<MoneyLoader>().Load());
            dataSave.Add(typeof(ArmyStorage).ToString(), GetSevice<ArmyLoader>().Load());
            dataSave.Add(typeof(MoneyTapStorage).ToString(), moneyTapStorageSave);


            moneyTapStorageSave.AddIncrementTap(valueMoneyTapStorage);
            moneyTapStorageSave.Update(Config.TimeUpdateStorage);

            saveLoaderGame.Save(dataSave);

            IGameRepository gameRepository = new GameRepository(saveLoaderGame);

            gameRepository.Save();

            saveLoaderGame.Load(out dataLoad,SaveList.TypesSave);
            MoneyTapStorage moneyTapStorageLoad = dataLoad[typeof(MoneyTapStorage).ToString()] as MoneyTapStorage;

            dataSaveValue = (dataSave[typeof(MoneyTapStorage).ToString()] as MoneyTapStorage).GetValue();
            dataLoadValue = moneyTapStorageLoad.GetValue();


            Assert.AreEqual(dataSaveValue, dataLoadValue);
            Assert.AreEqual(dataLoad.Count, dataSave.Count);
        }
    }
}