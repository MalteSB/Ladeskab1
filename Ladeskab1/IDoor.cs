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
        void LockDoor(string newState);
        void UnlockDoor();

        void OnDoorOpen();
        void OnDoorClose(DoorEventArgs e);
    }

    public class DoorEventArgs : EventArgs
    {
        public string state { get; set; }
    }
}
