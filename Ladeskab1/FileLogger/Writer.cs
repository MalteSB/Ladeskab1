using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public class Writer : IStreamWriter
    {
        private string logFile ="logfile.txt";
        
       


        public Writer()
        {
            
        }

        public void WriteLineToFile(string line)
        {
            using (var writer = File.AppendText(logFile))
            {
                writer.WriteLine(line);
            }
        }


    }
}
