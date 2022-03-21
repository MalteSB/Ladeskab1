using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private IDisplay _display;
        private IReader _reader;
        private int _currentString;
        private int _currentRFIDcode;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
        public StationControl(IDoor door, IReader reader,IChargeControl chargeControl,IDisplay display)
        {
            _display = display;
            _charger = chargeControl;
            _door = door;
            _reader = reader;
            _door.DoorStateEvent += HandleDoorStateEvent;
            _reader.ReadStateEvent += HandleRFIDStateEvent;
            
        }

        private void HandleDoorStateEvent(object sender, DoorEventArgs e)
        {
            _currentString = e.code;
            DoorEventDetected(e.code);
        }

        private void HandleRFIDStateEvent(object sender, ReaderEventArgs e)
        {
            _currentRFIDcode = e.rfidCode;
            RfidDetected(e.rfidCode);
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {

                case LadeskabState.Available:
                    // Check for ladeforbindelse

                    if (_charger.Connected)
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }

                        _display.ShowLockerLocked();
                    }
                    else
                    {
                        _display.ShowNotConnected();
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        _display.ShowTakePhone();

                    }
                    else
                    {
                        _display.ShowWrongRFID();
                    }

                    break;
            }
        }

        private void DoorEventDetected(int state)
        {
            if (state == 1)
            {
                _state = LadeskabState.Locked;
            }
            else if (state == 0)
            {
                _state = LadeskabState.Available;
            }
            else if (state == 2)
            {
                _state = LadeskabState.DoorOpen;
            }
            else if (state == 3)
            {
                _state = LadeskabState.Available;
            }
        }

        // Her mangler de andre trigger handlere
    }
}
