using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    public class FileLogger : ILogger
    {
        private string logFile = "logfile.txt";
        private StreamWriter writer;
        private FileStream stream;

        public FileLogger()
        {
        }

        public void log(int i, int id)
        {
            if (i == 1)
            {
                using (var writer = File.AppendText(logFile))
                {
                    writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                }
            }
            else if (i == 2)
            {
                using (var writer = File.AppendText(logFile))
                {
                    writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                }
            }
        }
    }
}
