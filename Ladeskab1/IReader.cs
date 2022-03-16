using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public interface IReader
    {
        public event EventHandler<ReaderEventArgs> ReadStateEvent;
        void Read(int code);
        void OnRfidRead(ReaderEventArgs e);
    }

    public class ReaderEventArgs : EventArgs
    {
        public int rfidCode { get; set; }
    }
}
