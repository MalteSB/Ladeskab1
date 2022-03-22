using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using System.IO;

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

        [TestCase(1,2)]
        [TestCase(2,2)]
        public void ctor_Log_Created(int i,int id)
        {
            _uut.log(i,id);
            Assert.That(File.Exists(_uut.Path), Is.True);
        }

        [TestCase(1, 55)]
        public void Locked_Logger_Test(int i,int id)
        {
            _uut.log(i,id);
            string[] log = File.ReadAllLines(_uut.Path);
            Assert.That(log.Contains(": Skab låst med RFID:"));
        }





    }
}
