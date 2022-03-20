using System;

namespace UsbSimulator
{
    public class CurrentEventArgs : EventArgs
    {
        // Value in mA (milliAmpere)
        public double Current { set; get; }
    }

    public class ConnectedEventArgs : EventArgs
    {
        public bool Connected { get; set; }
    }

    public interface IUsbCharger
    {
        // Event triggered on new current value
        event EventHandler<CurrentEventArgs> CurrentValueEvent;
        event EventHandler<ConnectedEventArgs> ConnectedEvent;

        // Direct access to the current current value
        double CurrentValue { get; }

        // Require connection status of the phone
        bool Connected { get; }

        // Start charging
        void StartCharge();
        // Stop charging
        void StopCharge();
        void SimulateConnected(bool a);
    }
}