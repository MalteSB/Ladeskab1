using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public interface IDisplay
    {
        event EventHandler<DoorEventArgs> DisplayEvent;

        void ShowMessage();
        void ShowChargeOngoing();
        void ShowChargeError();
        void ShowFullyCharged();
        void NoPhoneConnected();
    }

    public class DisplayEventArgs : EventArgs
    {
        public string message { get; set; }
    }
}
