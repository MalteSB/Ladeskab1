using Ladeskab1;
using System;
using UsbSimulator;

namespace App
{
   class Program
    {
        static void Main(string[] args)
        {

            IDoor door = new Door();
            IReader rfidReader = new RFID();
            IDisplay display = new Display();
            IUsbCharger _usbSim = new UsbChargerSimulator();
            IChargeControl _chargeControl = new ChargeControl(_usbSim, display);
            StationControl _statControl = new StationControl(door, rfidReader, _chargeControl);

            System.Console.WriteLine("Indtast E/e for at slukke programmet ");
            System.Console.WriteLine("Indtast O/o for at åbne døren");
            System.Console.WriteLine("Indtast C/c for at lukke døren");
            System.Console.WriteLine("Indtast S/s for at tilslut telefon");
            System.Console.WriteLine("Indtast R/r Scan RFID ");
            bool finish = false;
            do
            {
                string input;


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
                        Console.WriteLine("Døren er åben nu");
                        Console.WriteLine("Tilslut telefon og luk døren");
                        door.OnDoorOpen(new DoorEventArgs());
                        break;

                    case 'c':
                    case 'C':
                        Console.WriteLine("Døren er lukket nu");
                        Console.WriteLine("Scan din RFID");
                        door.OnDoorClose(new DoorEventArgs());
                        break;
                    case 's':
                    case 'S':
                        Console.WriteLine("Telefonen er tilslutet");
                        _usbSim.SimulateConnected(true);
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
