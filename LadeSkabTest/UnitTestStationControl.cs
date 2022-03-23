using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using NUnit.Framework;
using NSubstitute;
using UsbSimulator;

namespace LadeSkabTest
{
    public class UnitTestStationControl
    {
        private IDisplay _display;
        private IDoor _door;
        private IChargeControl _chargeControl;
        private IReader _reader;
        private ILogger _logger;
        private StationControl _uut;


        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _chargeControl = Substitute.For<IChargeControl>();
            _reader = Substitute.For<IReader>();
            _logger = Substitute.For<ILogger>();

            _uut = new StationControl(_door, _reader, _chargeControl, _display,_logger);
        }

        [Test]
        public void TestHandleDoorEvent()
        {
            _door.LockDoor();

        }

        [TestCase(1,1)]
        [TestCase(2,300)]
        [TestCase(5,3050)]
        public void TestRfidDetected(int iterations,int code)
        {
            for (int i = 0; i < iterations; i++)
            {
                _reader.Read(code);
            }

            _display.Received(iterations);
        }

        [TestCase(1, 1)]
        [TestCase(2, 300)]
        [TestCase(5, 3050)]
        public void TestRfidDetectedChargerConnected(int iterations, int code)
        {
            _chargeControl.SimulateUSBConnected(true);
            for (int i = 0; i < iterations; i++)
            {
                _reader.Read(code);
            }

            _display.Received(iterations);
            _door.Received(iterations);
            _chargeControl.Received(iterations);
        }

        [TestCase(1, 1)]
        [TestCase(2, 300)]
        [TestCase(5, 3050)]
        public void TestRfidDetectedChargerNotConnected(int iterations, int code)
        {
            _chargeControl.SimulateUSBConnected(false);
            for (int i = 0; i < iterations; i++)
            {
                _reader.Read(code);
            }

            _display.Received(iterations);
        }











    }
}
