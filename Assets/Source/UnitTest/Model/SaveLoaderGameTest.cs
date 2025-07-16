using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{
    [TestFixture]
    public class SaveLoaderGameTest : BaseTest
    {
        [Test]
        public void SaveLoadTest()
        {
            int valueMoneyTapStorage = 10;

            ISaveLoaderGame saveLoaderGame = GetSevice<ISaveLoaderGame>();
            Dictionary<string,object> dataSave = new();
            Dictionary<string,object> dataLoad = new();

            MoneyTapStorage moneyTapStorageSave = GetSevice<MoneyTapLoader>().Load();
            moneyTapStorageSave.AddIncrementTap(valueMoneyTapStorage - 1);
            moneyTapStorageSave.Update(Config.TimeUpdateStorage);

            dataSave.Add(typeof(MoneyTimeStorage).ToString(), GetSevice<MoneyTimeLoader>().Load());
            dataSave.Add(typeof(GameData).ToString(), GetSevice<GameDataLoader>().Load());
            dataSave.Add(typeof(MoneyStorage).ToString(), GetSevice<MoneyLoader>().Load());
            dataSave.Add(typeof(ArmyStorage).ToString(), GetSevice<ArmyLoader>().Load());
            dataSave.Add(typeof(MoneyTapStorage).ToString(), moneyTapStorageSave);


            saveLoaderGame.Save(dataSave);
            saveLoaderGame.Load(out dataLoad,SaveList.TypesSave);
            MoneyTapStorage moneyTapStorageLoad = dataLoad[typeof(MoneyTapStorage).ToString()] as MoneyTapStorage;
            int dataSaveValue = (dataSave[typeof(MoneyTapStorage).ToString()] as MoneyTapStorage).GetValue();
            int dataLoadValue = moneyTapStorageLoad.GetValue();


            Assert.AreEqual(dataSaveValue, dataLoadValue);
            Assert.AreEqual(dataLoad.Count, dataSave.Count);
        }
    }
}