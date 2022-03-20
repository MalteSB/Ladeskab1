using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Ladeskab1
{
    class ChargeControl : IChargeControl
    {
        public bool Connected { get; set; }
        private IUsbCharger _simulator;
        private IDisplay _display;
        private double _current;

        public ChargeControl(IUsbCharger simulator,IDisplay display)
        {
            Connected = true;
            _simulator = simulator;
            _display = display;
            simulator.CurrentValueEvent += HandleCurrentEvent;
        }

        public void HandleCurrentEvent(object sender, CurrentEventArgs e)
        {
            _current = e.Current;
            ChargerDetectedEvent(_current);
        }

        public void ChargerDetectedEvent(double _current)
        {
            if (_current == 0)
            {
                _display.NoPhoneConnected();
                _simulator.SimulateConnected(false);
            }
            else if (0 < _current && _current<=5)
            {
                _display.ShowFullyCharged();
                _simulator.SimulateConnected(true);
            }
            else if (5 < _current && _current <= 500)
            {
                _display.ShowChargeOngoing();
                _simulator.SimulateConnected(true);
            }
            else
            {
                _display.ShowChargeError();
                _simulator.SimulateConnected(true);
            }
        }

        public void StartCharge()
        {
            _simulator.StartCharge();
        }

        public void StopCharge()
        {
            _simulator.StopCharge();
        }
    }
}
