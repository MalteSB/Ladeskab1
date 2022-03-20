using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public class Door : IDoor
    {
        public event EventHandler<DoorEventArgs> DoorStateEvent;

        public enum states 
        {
            Locked,
            UnLocked
        }

        public void LockDoor()
        {
            OnDoorClose(new DoorEventArgs(){code = 1});
        }

        public void UnlockDoor()
        {
            OnDoorOpen(new DoorEventArgs() {code = 0});
        }

        public void OnDoorOpen(DoorEventArgs e)
        {
            DoorStateEvent?.Invoke(this,e);
        }

        public void OnDoorClose(DoorEventArgs e)
        {
            DoorStateEvent?.Invoke(this,e);
        }
    }
}
