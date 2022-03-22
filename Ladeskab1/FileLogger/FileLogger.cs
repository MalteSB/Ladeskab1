
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Ladeskab1
{
    public class FileLogger : ILogger
    {
        private string logFile = "logfile.txt";
        private IStreamWriter writer;
        private ITimeProvider time;
        private FileStream stream;

        public FileLogger(IStreamWriter writer,ITimeProvider time)
        {
            this.writer = writer;
            this.time = time;
        }
       

        public void log(int i, int id)
        {
            if (i == 1)
            {
                writer.WriteLineToFile(time.getTime()+" Skab låst med RFID:"+id);
            }
            else if (i == 2)
            {
                writer.WriteLineToFile(time.getTime() + " Skab låst op med RFID:"+ id);
                
            }

        }
    }
}
