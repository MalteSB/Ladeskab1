using Ladeskab1;
using NUnit.Framework;

namespace LadeSkabTest
{
    public class Tests
    {
        private Door _uut;
        private RFID reader;
        private DoorEventArgs _receivedDoorEventArgs;
        private ReaderEventArgs _receivedReaderEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedDoorEventArgs = null;
            _receivedReaderEventArgs = null;

            _uut = new Door();

            reader = new RFID();


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

        [Test]
        public void TestObserverDoor()
        {
            _uut.LockDoor();

            Assert.That(_receivedDoorEventArgs.code,Is.EqualTo("Locked"));
        }

        [Test]
        public void TestObserverReader()
        {
            reader.Read(23);
            
            Assert.That(_receivedReaderEventArgs.rfidCode,Is.EqualTo(23));
        }

        [Test]
        public void TestObserverDisplay()
        {
            //ikke implementeret
        }
    }
}