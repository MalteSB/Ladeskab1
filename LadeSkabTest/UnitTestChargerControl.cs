using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using NSubstitute;
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


    }

}
