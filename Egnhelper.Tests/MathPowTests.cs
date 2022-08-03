using NUnit.Framework;

namespace Egnhelper.Tests
{
    [TestFixture]
    public class MathPowTests
    {
        [Test]
        public void MathPowShouldWorkCorrectlyForPowerOf2()
        {
            var result = Math.Pow(100, 2);
            Assert.AreEqual(10000,result);
        }
    }
}