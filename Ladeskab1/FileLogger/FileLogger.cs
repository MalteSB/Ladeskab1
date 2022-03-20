using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab1
{
    class FileLogger : ILogger
    {
        private string fileName = @"";
        private StreamWriter writer;
        private FileStream stream;

        public FileLogger()
        {
            writer = new StreamWriter(fileName);
        }

        public void log()
        {
            // Create a FileStream with mode CreateNew  
            if (File.Exists(fileName)==false)
            {
                stream = new FileStream(fileName, FileMode.CreateNew);
            }
            else
            {
                stream = new FileStream(fileName, FileMode.Append);
            }
            // Create a StreamWriter from FileStream  
            try
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine("Hello StreamWriter");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
