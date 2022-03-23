using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using NSubstitute;
using NUnit.Framework;

namespace LadeSkabTest
{
    class UnitTestTimeprovider
    {
        private ITimeProvider tpro;

        [SetUp]
        public void Setup()
        {
            tpro = new TimeProvider();
        }

        [Test]
        public void TestGetTime()
        {
            String thisTime = tpro.getTime().ToString();

            Assert.That(thisTime, Is.EqualTo(tpro.DT));
        }
    }
}
