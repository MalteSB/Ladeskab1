using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using System.IO;
using NSubstitute;

namespace LadeSkabTest
{
    public class UnitTestFileLogger
    {

        private IStreamWriter fakeFilewriter;
        private ITimeProvider fakeTimeProvider;
        private FileLogger _uut;

        [SetUp]
        public void Setup()
        {
            fakeFilewriter = Substitute.For<IStreamWriter>();
            fakeTimeProvider = Substitute.For<ITimeProvider>();
            _uut = new FileLogger(fakeFilewriter,fakeTimeProvider);
        }

        [Test]
        {

        [TestCase(1, 55)]
        public void Locked_Logger_Test(int i,int id)
        {
            _uut.log(i,id);
            string[] log = File.ReadAllLines(_uut.Path);
            Assert.That(log.Contains(": Skab låst med RFID:"));
        }





    }
}
