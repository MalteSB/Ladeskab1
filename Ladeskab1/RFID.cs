using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    class RFID : IReader
    {
        public event EventHandler<ReaderEventArgs> ReadStateEvent;
        private string oldString;
        private bool continueBool = false;

        public void Read(int code)
        {
            while (continueBool == true)
            {
                if (Console.KeyAvailable)
                {
                    Char k = Console.ReadKey().KeyChar;
                    switch (k)
                    {
                        case 'A': 
                            OnRfidRead(new ReaderEventArgs(){rfidCode = code});
                            
                            break;
                        case 'S':
                            continueBool = false;
                            break;
                    }
                }
            }
        }

        public void OnRfidRead(ReaderEventArgs e)
        {
            ReadStateEvent?.Invoke(this,e);
        }
    }
}
