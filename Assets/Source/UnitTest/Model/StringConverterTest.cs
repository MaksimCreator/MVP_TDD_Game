using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class StringConverterTest
    {
        [Test]
        public void IsTheStringBeingConvertedCorrectly()
        {
            string firstString, secondString, thirdString, fourthString;
        
            int firstStringInt = 10000;
            int secondStringInt = 1000000;
            int thirdStringInt = 100;
            int fourthStringInt = 101200;

            string endFirstString = "10.0Ê";
            string endSecondString = "1.0Ì";
            string endThirdString = "100";
            string endFourthString = "101.2Ê";


            firstString = StringConverter.GetConvertString(firstStringInt);
            secondString = StringConverter.GetConvertString(secondStringInt);
            thirdString = StringConverter.GetConvertString(thirdStringInt);
            fourthString = StringConverter.GetConvertString(fourthStringInt);


            Assert.AreEqual(firstString, endFirstString);
            Assert.AreEqual(secondString, endSecondString);
            Assert.AreEqual(thirdString, endThirdString);
            Assert.AreEqual(fourthString, endFourthString);
        }
    }
}