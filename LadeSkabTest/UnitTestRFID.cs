using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using NUnit.Framework;

namespace LadeSkabTest
{
    public class UnitTestRFID
    {
        private RFID _uut;
        private ReaderEventArgs _receivedReaderEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedReaderEventArgs = null;
            _uut = new RFID();


            _uut.ReadStateEvent +=
                (o, args) =>
                {
                    _receivedReaderEventArgs = args;
                };

        }


        [TestCase(23)]
        [TestCase(10)]
        [TestCase(5)]
        public void TestObserverReader(int code)
        {
            _uut.Read(code);

            Assert.That(_receivedReaderEventArgs.rfidCode, Is.EqualTo(code));
        }



        
    }
}
