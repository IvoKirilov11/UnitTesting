using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egnhelper.Tests
{
    [TestFixture]
    public class EgnInformationExtractorTests
    {
        [Test]
        public void ExtraxtInformationShouldCorrectly()
        {
            var informationExtractor = new EgnExtraxtInformation();
            EgnInformation information = informationExtractor.Extract("6101057509");
            Assert.That(information.ToString(),Is.EqualTo("ЕГН на мъж,pоден на 5 януари 1961 г."));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(1961, 1, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
        }
        [Test]
        public void ExtraxtInformationShouldCorrectlyForWoman()
        {
            var informationExtractor = new EgnExtraxtInformation();
            EgnInformation information = informationExtractor.Extract("8032056031");
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на жена,pодена на 5 декември 1880 г."));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(1880, 12, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Female));
        }

        [Test]
        public void ExtraxtInformationShouldCorrectlyForFutre()
        {
            var informationExtractor = new EgnExtraxtInformation();
            EgnInformation information = informationExtractor.Extract("7552010005");
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на мъж,pоден на 1 декември 2075 г."));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(2075, 12, 1)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
        }
        [Test]
        public void ExtractShouldThrowArgumentNullExeptionWhenGivenNull()
        {
            var egnInformationExtractor = new EgnExtraxtInformation();
            Assert.Throws<ArgumentNullException>(() => egnInformationExtractor.Extract(null));
        }

        [Test]
        public void ExtractShouldThrowArgumentExeptionWhenGivenInvalidEgn()
        {
            var egnInformationExtractor = new EgnExtraxtInformation();
            Assert.Throws<ArgumentException>(() => egnInformationExtractor.Extract("0000000000"));
        }
    }

   
}
