using System;
using UsbSimulator;

namespace Ladeskab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            IDoor door = new Door();
            IReader rfidReader = new RFID();
            ChargeControl _chargeControl = new ChargeControl();
            UsbChargerSimulator _usbSim = new UsbChargerSimulator();
            StationControl _statControl = new StationControl(door, rfidReader, _chargeControl);

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'e':
                    case 'E':
                        finish = true;
                        break;

                    case 'o':
                    case 'O':
                        door.OnDoorOpen(new DoorEventArgs());
                        break;

                    case 'c':
                    case 'C':
                        door.OnDoorClose(new DoorEventArgs());
                        break;

                    case 'r':
                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();
                        int id = Convert.ToInt32(idString);
                        rfidReader.Read(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
