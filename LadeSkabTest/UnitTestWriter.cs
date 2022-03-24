using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using NUnit;
using NSubstitute;
using NUnit.Framework;

namespace LadeSkabTest
{
    class UnitTestWriter
    {
        private IStreamWriter _uut;
        private string logFile = "logfile.txt";

        [SetUp]
        public void SetUp()
        {
            _uut = new Writer();
        }

        [TestCase("test")]
        public void TestWriteLineToFile(string gemmes)
        {
            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }
            

            _uut.WriteLineToFile(gemmes);

            string resultet;
            using (StreamReader reader = new StreamReader(File.OpenRead(logFile)))
            {
                resultet = reader.ReadLine();

            }
            Assert.AreEqual(gemmes,resultet);

        }

       
      


    }
}
