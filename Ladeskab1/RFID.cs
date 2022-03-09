using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    class RFID : IReader
    {
        public string readString { get; private set; }
        private bool continueBool = false;

        public int Read(string code)
        {
            while (continueBool == true)
            {
                if (Console.KeyAvailable)
                {
                    Char k = Console.ReadKey().KeyChar;
                    switch (k)
                    {
                        case 'A': 
                            return code.GetHashCode();
                            break;
                        case 'S':
                            continueBool = false;
                            break;
                    }
                }
            }
            return 0;
        }
    }
}
