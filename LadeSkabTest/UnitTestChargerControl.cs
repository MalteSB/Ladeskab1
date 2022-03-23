using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using UsbSimulator;

namespace LadeSkabTest
{
    class UnitTestChargerControl
    {
        public event EventHandler<CurrentEventArgs> CurrentValueEvent;
        private IDisplay _display;
        private IUsbCharger _chargerSim;
        private IChargeControl _uut;


        [SetUp]
        public void Setup()
        {
            _chargerSim = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_chargerSim, _display);
            _chargerSim.CurrentValueEvent += this.CurrentValueEvent;
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void StartCharge_Test(int Antalkald)
        {
            for (int i = 0; i < Antalkald; i++)
            {
                _uut.StartCharge();
            }

            _chargerSim.Received(Antalkald).StartCharge();
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void StopCharge_Test(int Antalkald)
        {
            for (int i = 0; i < Antalkald; i++)
            {
                _uut.StopCharge();
            }

            _chargerSim.Received(Antalkald).StopCharge();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestSimulateConnected(bool tf)
        {
            _uut.SimulateUSBConnected(tf);
            _chargerSim.Received(1).SimulateConnected(tf);
        }

        [Test]
        public void TestCurrentRecieved()
        {
            _chargerSim.StartCharge();
            _display.Received();
            _chargerSim.Received();
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(499)]
        [TestCase(501)]
        public void TestHandleCurrentEvent(double thisCurrent)
        {
            _chargerSim.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs {Current = thisCurrent});


            Assert.That(_uut._current,Is.EqualTo(thisCurrent));
        }











    }



}
