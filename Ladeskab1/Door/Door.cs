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
            OnDoorAction(new DoorEventArgs(){code = 1});
        }

        public void UnlockDoor()
        {
            OnDoorAction(new DoorEventArgs() {code = 0});
        }

        public void DoorOpen()
        {
            OnDoorAction(new DoorEventArgs(){code = 2});
        }

        public void DoorClosed()
        {
            OnDoorAction(new DoorEventArgs(){code = 3});
        }

        public void OnDoorAction(DoorEventArgs e)
        {
            DoorStateEvent?.Invoke(this,e);
        }
    }
}
