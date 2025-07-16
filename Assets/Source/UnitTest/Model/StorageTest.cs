using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class StorageTest
    {
        [Test]
        public void StorageTest_Add()
        {
            int moneyFirstCycleAdd, moneySecondCycleAdd, moneyTapFirstCycleAdd,
                moneyTapSecondCycleAdd, armyFirstCycleAdd, armySecondCycleAdd, moneyTimeFirstCycleAdd, moneyTimeSecondCycleAdd;

            MoneyStorage moneyStorage = new MoneyStorage();
            ArmyStorage armyStorage = new ArmyStorage();
            MoneyTapStorage tapStorage = new MoneyTapStorage(0);
            MoneyTimeStorage timeStorage = new MoneyTimeStorage();

            float cycleTime = Config.TimeUpdateStorage / 2;
            int addValue = 11;
            int resultFirstCycleAdd = addValue / 2;
            int resultSecondCycleAdd = addValue;

            armyStorage.AddArmy(addValue);
            moneyStorage.AddMoney(addValue);
            tapStorage.AddIncrementTap(addValue);
            timeStorage.AddIncrementTime(addValue);

            moneyStorage.Update(cycleTime);
            armyStorage.Update(cycleTime);
            timeStorage.Update(cycleTime);
            tapStorage.Update(cycleTime);

            moneyFirstCycleAdd = moneyStorage.GetValue();
            armyFirstCycleAdd = armyStorage.GetValue();
            moneyTapFirstCycleAdd = tapStorage.GetValue();
            moneyTimeFirstCycleAdd = timeStorage.GetValue();

            moneyStorage.Update(cycleTime * 2);
            armyStorage.Update(cycleTime * 2);
            timeStorage.Update(cycleTime * 2);
            tapStorage.Update(cycleTime * 2);

            moneySecondCycleAdd = moneyStorage.GetValue();
            armySecondCycleAdd = armyStorage.GetValue();
            moneyTapSecondCycleAdd = tapStorage.GetValue();
            moneyTimeSecondCycleAdd = timeStorage.GetValue();

            Assert.AreEqual(moneyFirstCycleAdd, resultFirstCycleAdd);
            Assert.AreEqual(moneySecondCycleAdd, resultSecondCycleAdd);
            Assert.AreEqual(armyFirstCycleAdd, resultFirstCycleAdd);
            Assert.AreEqual(armySecondCycleAdd, resultSecondCycleAdd);
            Assert.AreEqual(moneyTapFirstCycleAdd, resultFirstCycleAdd);
            Assert.AreEqual(moneyTapSecondCycleAdd, resultSecondCycleAdd);
            Assert.AreEqual(moneyTimeFirstCycleAdd, resultFirstCycleAdd);
            Assert.AreEqual(moneyTimeSecondCycleAdd, resultSecondCycleAdd);
        }

        [Test]
        public void StorageTestMoney_Remove()
        {
            int moneyFirstCycleRemove, moneySecondCycleRemove;
            MoneyStorage storage = new MoneyStorage();

            float cycleTime = Config.TimeUpdateStorage / 2;
            int addValue = 11;
            int resultFirstCycleRemove = addValue - addValue / 2 - 1;
            int resultSecondCycleRemove = 0;


            storage.AddMoney(addValue);
            storage.Update(Config.TimeUpdateStorage);
            storage.RemoveMoney(addValue);

            storage.Update(cycleTime);
            moneyFirstCycleRemove = storage.GetValue();

            storage.Update(cycleTime);
            moneySecondCycleRemove = storage.GetValue();


            Assert.AreEqual(moneyFirstCycleRemove, resultFirstCycleRemove);
            Assert.AreEqual(moneySecondCycleRemove, resultSecondCycleRemove);
        }

        [Test]
        public void StorageTestMoney_CanRemove()
        {
            int addValue = 11;
            bool canRemoveFirst, canRemoveSecond, canRemoveThird;
            MoneyStorage storage = new MoneyStorage();


            storage.AddMoney(addValue);
            canRemoveFirst = storage.CanRemove(addValue * 2);
            canRemoveSecond = storage.CanRemove(addValue);
            storage.Update(Config.TimeUpdateStorage);
            canRemoveThird = storage.CanRemove(addValue);


            Assert.IsFalse(canRemoveFirst);
            Assert.IsFalse(canRemoveSecond);
            Assert.IsTrue(canRemoveThird);
        }
    }
}