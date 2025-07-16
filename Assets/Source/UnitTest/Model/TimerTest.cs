using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TimerTest
    {
        [Test]
        public void DoesTheTimerWorkWhenDisable()
        {
            float delta = 0.8f;
            bool canRunInTime = false;
            Timer timer = new Timer(delta, () => canRunInTime = true);


            timer.Disable();
            timer.Update(delta);


            Assert.IsFalse(canRunInTime);
        }

        [Test]
        public void IsTheTimerRunningOnTime()
        {
            float delta = 0.8f;
            bool canRunInTime = false;
            Timer timer = new Timer(delta,() => canRunInTime = true);


            timer.Enable();
            timer.Update(delta);


            Assert.IsTrue(canRunInTime);
        }

        [Test]
        public void DoesTheTimerWorkWhenEnable()
        {
            float delta = 0.8f;
            bool canRunInTime = false;
            Timer timer = new Timer(delta, () => canRunInTime = true);


            timer.Disable();
            timer.Enable();
            timer.Update(delta);


            Assert.IsTrue(canRunInTime);
        }
    }
}