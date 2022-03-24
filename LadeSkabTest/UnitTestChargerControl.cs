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
        
        private IDisplay _display;
        private IUsbCharger _chargerSim;
        private IChargeControl _uut;


        [SetUp]
        public void Setup()
        {
            _chargerSim = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_chargerSim, _display);
            
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

        [TestCase(-1,true,4)]
        [TestCase(0,false,1)]
        [TestCase(1,true,2)]
        [TestCase(4, true, 2)]
        [TestCase(5,true,2)]
        [TestCase(6,true,3)]
        [TestCase(499, true, 3)]
        [TestCase(500,true,3)]
        [TestCase(501,true,4)]
        public void TestHandleCurrentEvent(double thisCurrent,bool stim,int scenario)
        {
            _chargerSim.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs {Current = thisCurrent});

            if (scenario == 2)
            {
                _display.Received(1).ShowFullyCharged();
                _chargerSim.Received(1).SimulateConnected(stim);
            }
            else if (scenario == 1)
            {
                _display.Received(1).PhoneConnectionError();
                _chargerSim.Received(1).SimulateConnected(stim);
            }
            else if (scenario == 3)
            {
                _display.Received(1).ShowChargeOngoing();
                _chargerSim.Received(1).SimulateConnected(stim);
            }
            else
            {
                _display.Received(1).ShowChargeError();
                _chargerSim.Received(1).SimulateConnected(true);
            }

        }



        [TestCase(true)]
        [TestCase(false)]
        public void TestHandleConnectionEvent(bool thisConnected)
        {
            _chargerSim.ConnectedEvent += Raise.EventWith(new ConnectedEventArgs() { Connected = thisConnected });

            Assert.That(_uut.Connected, Is.EqualTo(thisConnected));
        }







    }

}
