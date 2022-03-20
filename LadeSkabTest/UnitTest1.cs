using System;
using System.IO;
using System.Runtime.CompilerServices;
using Ladeskab1;
using NSubstitute;
using NUnit.Framework;
using UsbSimulator;

namespace LadeSkabTest
{
    public class Tests
    {
        private Door _uut;
        private RFID reader;
        private Display display;
        private DoorEventArgs _receivedDoorEventArgs;
        private ReaderEventArgs _receivedReaderEventArgs;
        private CurrentEventArgs _receivedUSBChargerEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedDoorEventArgs = null;
            _receivedReaderEventArgs = null;

            _uut = new Door();

            reader = new RFID();

            display = new Display();


            // Set up an event listener to check the event occurrence and event data
            _uut.DoorStateEvent+=
                (o, args) =>
                {
                    _receivedDoorEventArgs = args;
                };

            reader.ReadStateEvent +=
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
            reader.Read(code);
            
            Assert.That(_receivedReaderEventArgs.rfidCode,Is.EqualTo(code));
        }

        

      
       





    }
}