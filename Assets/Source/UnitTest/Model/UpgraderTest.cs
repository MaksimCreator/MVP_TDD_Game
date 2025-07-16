using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class UpgraderTest : BaseTest
    {
        [Test]
        public void UpgradeTest_Buy_CanBuy_IsMaxIndex()
        {
            int priceFirstUpgradeInfo = 100;
            int priceSecondUpgradeInfo = 200;
            int getPriceFirstUpgrade, getPriceSecondUpgrade;

            int incrementFirstUpgrade = 15;
            int incrementSecondUpgrade = 27;
            int getIcrementFirstUpgrade, getIcrementSecondUpgrade;

            bool canRemoveFirst, canRemoveSecond, canEndFirst, canEndSecond, canEndThird;

            MoneyStorage moneyStorage = GetSevice<MoneyLoader>().Load();
            MoneyTapUpgrade upgrader = GetSevice<MoneyTapUpgrade>();


            getPriceFirstUpgrade = upgrader.Price;
            getIcrementFirstUpgrade = upgrader.Increment;
            canEndFirst = upgrader.IsMaxIndex;

            moneyStorage.AddMoney(priceFirstUpgradeInfo);
            canRemoveFirst = upgrader.CanBuy;
            moneyStorage.Update(Config.TimeUpdateStorage);
            canRemoveSecond = upgrader.CanBuy;

            upgrader.Buy();
            moneyStorage.Update(Config.TimeUpdateStorage);
            moneyStorage.AddMoney(priceSecondUpgradeInfo);
            moneyStorage.Update(Config.TimeUpdateStorage);

            canEndSecond = upgrader.IsMaxIndex;
            getPriceSecondUpgrade = upgrader.Price;
            getIcrementSecondUpgrade = upgrader.Increment;

            upgrader.Buy();
            canEndThird = upgrader.IsMaxIndex;


            Assert.AreEqual(getIcrementFirstUpgrade, incrementFirstUpgrade);
            Assert.AreEqual(getIcrementSecondUpgrade, incrementSecondUpgrade);
            Assert.AreEqual(getPriceFirstUpgrade, priceFirstUpgradeInfo);
            Assert.AreEqual(getPriceSecondUpgrade, priceSecondUpgradeInfo);
            Assert.IsFalse(canRemoveFirst);
            Assert.IsTrue(canRemoveSecond);
            Assert.IsFalse(canEndFirst);
            Assert.IsFalse(canEndSecond);
            Assert.IsTrue(canEndThird);
        }
    }
}