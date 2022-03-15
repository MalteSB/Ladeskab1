using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public class Display : IDisplay
    {
        public event EventHandler<DoorEventArgs> DisplayEvent;
        private bool doorOpened = false;
        private bool isConnected;
        private bool checkID;

        public void SetLockerState()
        {

        }
        
        public void ShowMessage()
        {
            if (doorOpened == true)
            {
                Console.WriteLine("Tilslut telefon");
            }
            if (doorOpened == false)
            {
                Console.WriteLine("Indlæs RFID");
            }
            if (isConnected == false)
            {
                Console.WriteLine("Tilslutningsfejl");
            }
            if (isConnected == true && doorOpened == false)
            {
                Console.WriteLine("Ladeskab optaget");
            }
            if (checkID == false)
            {
                Console.WriteLine("RFID fejl");
            }

            if (checkID == true)
            {
                Console.WriteLine("Fjern telefon");
            }


        }
    }
}
