using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    interface IDisplay
    {
        event EventHandler<DoorEventArgs> DisplayEvent;

        void ShowMessage();
    }

    public class DisplayEventArgs : EventArgs
    {
        public string message { get; set; }
    }
}
