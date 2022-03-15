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
        private string thisRFID;

        public enum states 
        {
            Locked,
            UnLocked
        }

        public void LockDoor()
        {
            OnDoorClose(new DoorEventArgs(){code = "Locked"});
            thisRFID = "Locked";
        }

        public void UnlockDoor()
        {
            OnDoorOpen(new DoorEventArgs() { code = "Unlocked" });
            thisRFID = "Unlocked";
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
