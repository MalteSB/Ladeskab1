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
            ITimeProvider _time = new TimeProvider();
            IStreamWriter _writer = new Writer();
            ILogger _logger = new FileLogger(_writer,_time);
            IChargeControl _chargeControl = new ChargeControl(_usbSim, display);
            StationControl _statControl = new StationControl(door, rfidReader, _chargeControl,display,_logger);


            System.Console.WriteLine("Indtast E/e for at slukke programmet ");
            System.Console.WriteLine("Indtast O/o for at åbne døren");
            System.Console.WriteLine("Indtast C/c for at lukke døren");
            System.Console.WriteLine("Indtast S/s for at tilslutte telefon");
            System.Console.WriteLine("Indtast F/f for at frakoble telefon");
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
                        door.DoorOpen();
                        break;

                    case 'c':
                    case 'C':
                        Console.WriteLine("Døren er lukket nu");
                        Console.WriteLine("Scan din RFID");
                        door.DoorClosed();
                        break;
                    case 's':
                    case 'S':
                        Console.WriteLine("Telefonen er tilslutet");
                        _chargeControl.SimulateUSBConnected(true);
                        break;

                    case 'f':
                    case 'F':
                        Console.WriteLine("Telefonen er frakoblet");
                        _chargeControl.SimulateUSBConnected(false);
                        break;

                    case 'r':
                    case 'R':
                        int id = 0;
                        while (id == 0)
                        {
                            System.Console.WriteLine("Indtast RFID id: ");
                            string idString = System.Console.ReadLine();
                            try
                            {
                                id = Convert.ToInt32(idString);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Ugyldigt RFID-format");
                            }
                        }

                        rfidReader.Read(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }

   
}
