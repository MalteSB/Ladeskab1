using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    interface IReader
    {
        void Read(int code);
        void OnRfidRead(ReaderEventArgs e);
    }

    public class ReaderEventArgs : EventArgs
    {
        public int rfidCode { get; set; }
    }
}
