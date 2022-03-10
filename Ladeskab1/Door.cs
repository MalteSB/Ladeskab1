using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    class Door : IDoor
    {
        public event EventHandler<DoorEventArgs> DoorStateEvent;
        private string oldState;
        public void LockDoor(string newState)
        {
            OnDoorClose(new DoorEventArgs(){state = newState});
            oldState = newState;
        }

        public void UnlockDoor()
        {

        }

        public void OnDoorOpen()
        {
            throw new NotImplementedException();
        }

        public void OnDoorClose(DoorEventArgs e)
        {
            DoorStateEvent?.Invoke(this,e);
        }
    }
}
