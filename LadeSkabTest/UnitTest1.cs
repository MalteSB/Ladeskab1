using Ladeskab1;
using NUnit.Framework;
using UsbSimulator;

namespace LadeSkabTest
{
    public class Tests
    {
        private Door _uut;
        private RFID reader;
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


        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void TestObserverUSBCharger(double current)
        {
            
            

            Assert.That(_receivedUSBChargerEventArgs.Current, Is.EqualTo(current));
        }





    }
}