using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public class RFID : IReader
    {
        public event EventHandler<ReaderEventArgs> ReadStateEvent;
        private bool continueBool = false;

        public void Read(int code)
        {
            OnRfidRead(new ReaderEventArgs() { rfidCode = code });
        }

        public void OnRfidRead(ReaderEventArgs e)
        {
            ReadStateEvent?.Invoke(this,e);
        }
    }
}
