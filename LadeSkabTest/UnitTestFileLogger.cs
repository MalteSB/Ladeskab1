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
        private Writer writer;

        [SetUp]
        public void Setup()
        {
            writer = new Writer();
            fakeFilewriter = Substitute.For<IStreamWriter>();
            fakeTimeProvider = Substitute.For<ITimeProvider>();
            _uut = new FileLogger(fakeFilewriter,fakeTimeProvider);
        }

        [TestCase(1, 2)]
        [TestCase(2, 2)]
        public void ctor_Log_Created(int i, int id)
        {
            _uut.log(i,id);
            Assert.That(File.Exists(writer.Path), Is.True);
        }


        [TestCase(1, 55)]
        public void Locked_Logger_Test(int i,int id)
        {
            _uut.log(i,id);
            string[] log = File.ReadAllLines(writer.Path);
            int index = log.Length-1;
            string time = "0";
            Assert.That(log[index], Is.EqualTo( time+ " Skab låst med RFID: " + id));
            foreach (string VARIABLE in log)
            {
                
            }
        }





    }
}
