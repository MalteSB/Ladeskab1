using System;
using System.IO;
using System.Runtime.CompilerServices;
using Ladeskab1;
using NSubstitute;
using NUnit.Framework;

namespace LadeSkabTest
{
    public class Tests
    {
        private Door _uut;
        private RFID reader;
        private Display display;
        private DoorEventArgs _receivedDoorEventArgs;
        private ReaderEventArgs _receivedReaderEventArgs;

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

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DoorEventRaisedOpen(int iterations)
        {
            int doorStateChanged = 0;
            _uut.DoorStateEvent += (o, args) => doorStateChanged++;

            int i = 0;
            while (i<iterations)
            {
                _uut.UnlockDoor();
                i++;
            }

            Assert.That(doorStateChanged,Is.EqualTo(iterations));
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DoorEventRaisedLock(int iterations)
        {
            int doorStateChanged = 0;
            _uut.DoorStateEvent += (o, args) => doorStateChanged++;

            int i = 0;
            while (i < iterations)
            {
                _uut.LockDoor();
                i++;
            }

            Assert.That(doorStateChanged, Is.EqualTo(iterations));
        }

        [TestCase(1,1)]
        [TestCase(2,0)]
        public void TestObserverDoor(int scenario,int state)
        {
            if (scenario == 1)
            {
                _uut.LockDoor();
            }
            else if (scenario == 2)
            {
                _uut.UnlockDoor();
            }

            Assert.That(_receivedDoorEventArgs.code,Is.EqualTo(state));
        }

        [TestCase(23)]
        [TestCase(10)]
        [TestCase(5)]
        public void TestObserverReader(int code)
        {
            reader.Read(code);
            
            Assert.That(_receivedReaderEventArgs.rfidCode,Is.EqualTo(code));
        }

        [Test]
        public void TestSetLockerDisplay()
        {
            try
            {
                display.SetLockerState();
            }
            catch (Exception e)
            {
                Assert.That(e,Is.TypeOf(typeof(NotImplementedException)));
            }
        }

        [Test]
        public void TestNoPhoneDisplay()
        {
            try
            {
                display.NoPhoneConnected();
            }
            catch (Exception e)
            {
                Assert.That(e, Is.TypeOf(typeof(NotImplementedException)));
            }
        }

        [Test]
        public void TestShowFullyCharged()
        {
            StringWriter _stringwriter = new StringWriter();
            Console.SetOut(_stringwriter);
            display.ShowFullyCharged();

            Assert.That(_stringwriter.ToString(),Is.EqualTo("Telefonen er fuldt opladt"+Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
        }

        [Test]
        public void TestShowChargeOngoing()
        {
            StringWriter _stringwriter = new StringWriter();
            Console.SetOut(_stringwriter);
            display.ShowChargeOngoing();

            Assert.That(_stringwriter.ToString(), Is.EqualTo("Opladning i gang" + Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
        }

        [Test]
        public void TestShowChargeError()
        {
            StringWriter _stringwriter = new StringWriter();
            Console.SetOut(_stringwriter);
            display.ShowChargeError();

            Assert.That(_stringwriter.ToString(), Is.EqualTo("Opladning fejl" + Console.Out.NewLine+"Opladning stoppes"+ Console.Out.NewLine)); //NewLine da der i metoden er brugt WriteLine.
        }

        [TestCase(1, 1, 1)]
        public void TestShowMessage(int door,int conn,int id)
        {

        }
    }
}