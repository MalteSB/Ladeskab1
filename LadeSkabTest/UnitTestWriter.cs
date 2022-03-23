using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using NUnit;
using NSubstitute;
using NUnit.Framework;

namespace LadeSkabTest
{
    class UnitTestWriter
    {
        private IStreamWriter _uut;
        private ILogger _logger;

        [SetUp]
        public void SetUp()
        {
            _uut = new Writer("logfile.txt");
            _logger = Substitute.For<ILogger>();
        }

        [TestCase(1, 24)]
        public void TestWriteLineToFile(int i, int e)
        {
            
        }

        [TestCase(1,2)]
        public void Ctor_log_Created(int i, int id)
        {
            _logger.log(i, id);
            Assert.That(File.Exists(_uut.Path),Is.True);
        }







    }
}
