using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using NUnit.Framework;

namespace LadeSkabTest
{
    
    public class UnitTestDoor
    {

        private Door _uut;
        private DoorEventArgs _receivedDoorEventArgs;


        [SetUp]
        public void Setup()
        {
            _receivedDoorEventArgs = null;
            _uut = new Door();
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void DoorEventRaisedOpen(int iterations)
        {
            int doorStateChanged = 0;
            _uut.DoorStateEvent += (o, args) => doorStateChanged++;

            int i = 0;
            while (i < iterations)
            {
                _uut.UnlockDoor();
                i++;
            }

            Assert.That(doorStateChanged, Is.EqualTo(iterations));
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

        [TestCase(1, 1)]
        [TestCase(2, 0)]
        public void TestObserverDoor(int scenario, int state)
        {
            if (scenario == 1)
            {
                _uut.LockDoor();
            }
            else if (scenario == 2)
            {
                _uut.UnlockDoor();
            }

            Assert.That(_receivedDoorEventArgs.code, Is.EqualTo(state));
        }













    }
}
