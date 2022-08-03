using EgnHelper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egnhelper.Tests
{
    [TestFixture]
    public class EgnValidatorTests
    {
        [Test]
        public void ValidateMethodShouldReturnTrueForValidEgnFor20thCentury()
        {
            var validate = new EgnValidator();

            var result = validate.IsValid("6101057509");

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateMethodShouldExeptionWhenTheGivenArgumentIsNull()
        {
            var validate = new EgnValidator();

            Assert.Throws<ArgumentNullException>(() => validate.IsValid(null));

            
        }
    }
}
