using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public class Display : IDisplay
    {
        public void PhoneConnectionError()
        {
            Console.WriteLine("Telefon er ikke ordentlig tilsluttet");
        }

        public void ShowLockerLocked()
        {
            Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        public void ShowNotConnected()
        {
            Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }

        public void ShowWrongRFID()
        {
            Console.WriteLine("Forkert RFID tag");
        }

        public void ShowTakePhone()
        {
            Console.WriteLine("Tag din telefon ud af skabet og luk døren");
        }

        public void ShowFullyCharged()
        {
            Console.WriteLine("Telefonen er fuldt opladt");
        }

        public void ShowChargeOngoing()
        {
            Console.WriteLine("Opladning i gang");
        }

        public void ShowChargeError()
        {
            Console.WriteLine("Opladning fejl ==>> Opladning stoppes");
         
        }
    }
}
