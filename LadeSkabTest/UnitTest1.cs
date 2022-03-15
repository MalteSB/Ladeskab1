using Ladeskab1;
using NUnit.Framework;

namespace LadeSkabTest
{
    public class Tests
    {
        private Door _uut;
        private DoorEventArgs _receivedDoorEventArgs;

        [SetUp]
        public void Setup()
        {
            _receivedDoorEventArgs = null;

            _uut = new Door();
            _uut.LockDoor();

            // Set up an event listener to check the event occurrence and event data
            _uut.DoorStateEvent+=
                (o, args) =>
                {
                    _receivedDoorEventArgs = args;
                };
        }

        [Test]
        public void TestObserverDoor()
        {
            _uut.LockDoor();

            Assert.That(_receivedDoorEventArgs.code,Is.EqualTo("Locked"));
        }

        [Test]
        public void TestObserverDisplay()
        {

        }

        [Test]
        public void TestObserverReader()
        {

        }
    }
}