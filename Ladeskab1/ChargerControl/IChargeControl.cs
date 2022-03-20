using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public interface IChargeControl
    {
        bool Connected { get; set; }

        void StartCharge();
        void StopCharge();

        void SimulateUSBConnected(bool a);

    }
}
