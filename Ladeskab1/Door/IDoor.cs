using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorStateEvent;
        void LockDoor();
        void UnlockDoor();
        void DoorOpen();
        void DoorClosed();

        void OnDoorAction(DoorEventArgs e);
    }

    public class DoorEventArgs : EventArgs
    {
        public int code { get; set; }
    }
}
