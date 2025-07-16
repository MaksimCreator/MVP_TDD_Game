using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class ClickHandlerTest : BaseTest
    {
        private ClickHandler _clickHandler;
        private MoneyStorage _moneyStorage;
        private MoneyTapStorage _moneyTapStorage;

        [SetUp]
        public void Inachealized()
        {
            _clickHandler = GetSevice<ClickHandler>();
            _moneyStorage = GetSevice<MoneyLoader>().Load();
            _moneyTapStorage = GetSevice<MoneyTapLoader>().Load();
        }

        [Test]
        public void ClickHandlerTest_Clck()
        {
            int value;
            int endValue = _moneyStorage.GetValue() + _moneyTapStorage.GetValue();


            _clickHandler.Enable();
            _clickHandler.Click();
            _moneyStorage.Update(Config.TimeUpdateStorage);
            value = _moneyStorage.GetValue();


            Assert.AreEqual(value, endValue);
        }

        [Test]
        public void ActiveTest_Disable()
        {
            int value;
            int endValue = _moneyStorage.GetValue();


            _clickHandler.Disable();
            _clickHandler.Click();
            _moneyStorage.Update(Config.TimeUpdateStorage);
            value = _moneyStorage.GetValue();


            Assert.AreEqual(value, endValue);
        }

        [Test]
        public void ActiveTest_Enable()
        {
            int value;
            int endValue = _moneyStorage.GetValue() + _moneyTapStorage.GetValue();


            _clickHandler.Disable();
            _clickHandler.Enable();
            _clickHandler.Click();
            _moneyStorage.Update(Config.TimeUpdateStorage);
            value = _moneyStorage.GetValue();


            Assert.AreEqual(value, endValue);
        }
    }
}