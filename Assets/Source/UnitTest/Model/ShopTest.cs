using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class ShopTest : BaseTest
    {
        [Test]
        public void ShopTest_UpgraderArmy_UpgraderMoneyTap_UpgraderMoneyTime()
        {
            Shop shop = GetSevice<Shop>();
            MoneyStorage moneyStorage = GetSevice<MoneyLoader>().Load();

            int priceArmyFirst, priceArmySecond,priceMoneyTapFirst,
                priceMoneyTapSecond,priceMoneyTimeFirst,priceMoneyTimeSecond,
                incrementArmyFirst, incrementArmySecond, incrementMoneyTapFirst,
                incrementMoneyTapSecond, incrementMoneyTimeFirst, incrementMoneyTimeSecond;

            bool canBuyArmyFirst, canBuyArmySecond, canBuyMoneyTimeFirst,
                canBuyMoneyTimeSecond,canBuyMoneyTapFirst,canBuyMoneyTapSecond,
                canBuyArmyThird, canBuyMoneyTapThird, canBuyMoneyTimeThird;
        

            canBuyArmyFirst = shop.CanBuyArmy;
            canBuyMoneyTapFirst = shop.CanBuyMoneyTap;
            canBuyMoneyTimeFirst = shop.CanBuyMoneyTime;

            priceArmyFirst = shop.PriceArmy;
            priceMoneyTapFirst = shop.PriceMoneyTap;
            priceMoneyTimeFirst = shop.PriceMoneyTime;

            incrementArmyFirst = shop.IncrementArmy;
            incrementMoneyTapFirst = shop.IncrementMoneyTap;
            incrementMoneyTimeFirst = shop.IncrementMoneyTime;

            moneyStorage.AddMoney(__priceFirstUpgradeInfo * 3);
            moneyStorage.Update(Config.TimeUpdateStorage);

            canBuyArmySecond = shop.CanBuyArmy;
            canBuyMoneyTapSecond = shop.CanBuyMoneyTap;
            canBuyMoneyTimeSecond = shop.CanBuyMoneyTime;

            shop.UpgraderArmy();
            shop.UpgraderMoneyTap();
            shop.UpgraderMoneyTime();

            priceArmySecond = shop.PriceArmy;
            priceMoneyTapSecond = shop.PriceMoneyTap;
            priceMoneyTimeSecond = shop.PriceMoneyTime;

            incrementArmySecond = shop.IncrementArmy;
            incrementMoneyTapSecond = shop.IncrementMoneyTap;
            incrementMoneyTimeSecond = shop.IncrementMoneyTime;

            moneyStorage.Update(Config.TimeUpdateStorage);
            moneyStorage.AddMoney(__priceSecondUpgradeInfo * 3);
            moneyStorage.Update(Config.TimeUpdateStorage);

            shop.UpgraderArmy();
            shop.UpgraderMoneyTap();
            shop.UpgraderMoneyTime();

            canBuyArmyThird = shop.CanBuyArmy;
            canBuyMoneyTapThird = shop.CanBuyMoneyTap;
            canBuyMoneyTimeThird = shop.CanBuyMoneyTime;


            Assert.AreEqual(priceArmyFirst, __priceFirstUpgradeInfo);
            Assert.AreEqual(priceMoneyTapFirst, __priceFirstUpgradeInfo);
            Assert.AreEqual(priceMoneyTimeFirst, __priceFirstUpgradeInfo);
            Assert.AreEqual(priceArmySecond, __priceSecondUpgradeInfo);
            Assert.AreEqual(priceMoneyTapSecond, __priceSecondUpgradeInfo);
            Assert.AreEqual(priceMoneyTimeSecond, __priceSecondUpgradeInfo);

            Assert.AreEqual(incrementArmyFirst, __incrementFirstUpgrade);
            Assert.AreEqual(incrementMoneyTapFirst, __incrementFirstUpgrade);
            Assert.AreEqual(incrementMoneyTimeFirst, __incrementFirstUpgrade);
            Assert.AreEqual(incrementArmySecond, __incrementSecondUpgrade);
            Assert.AreEqual(incrementMoneyTapSecond, __incrementSecondUpgrade);
            Assert.AreEqual(incrementMoneyTimeSecond, __incrementSecondUpgrade);

            Assert.IsFalse(canBuyArmyFirst);
            Assert.IsFalse(canBuyMoneyTapFirst);
            Assert.IsFalse(canBuyMoneyTimeFirst);
            Assert.IsTrue(canBuyArmySecond);
            Assert.IsTrue(canBuyMoneyTapSecond);
            Assert.IsTrue(canBuyMoneyTimeSecond);
            Assert.IsFalse(canBuyArmyThird);
            Assert.IsFalse(canBuyMoneyTapThird);
            Assert.IsFalse(canBuyMoneyTimeThird);
        }
    }
}