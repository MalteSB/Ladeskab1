using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public interface IDisplay
    {
        void ShowChargeOngoing();
        void PhoneConnectionError();
        void ShowChargeError();
        void ShowFullyCharged();
        void ShowLockerLocked();
        void ShowNotConnected();
        void ShowWrongRFID();
        void ShowTakePhone();

    }
}
