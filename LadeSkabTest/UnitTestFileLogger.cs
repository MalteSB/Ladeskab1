using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using System.IO;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using NSubstitute;
using NUnit;

namespace LadeSkabTest
{
    public class UnitTestFileLogger
    {
        private FileLogger _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new FileLogger();
        }

        [Test]
        public void ctor_Log_Created()
        {
            _uut.log();
            Assert.That(File.Exists(_uut.Path), Is.True);
        }








    }
}
