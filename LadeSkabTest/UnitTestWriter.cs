﻿using System;
using System.Collections.Generic;
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

        [SetUp]
        public void SetUp()
        {
            _uut = new Writer();
        }

        [TestCase(1, 24)]
        public void TestWriteLineToFile(int i, int e)
        {
            
        }
    }
}