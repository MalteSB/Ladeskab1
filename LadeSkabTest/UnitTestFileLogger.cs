﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using System.IO;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using NSubstitute;
using NUnit;
using NSubstitute;

namespace LadeSkabTest
{
    public class UnitTestFileLogger
    {

        private IStreamWriter fakeFilewriter;
        private ITimeProvider fakeTimeProvider;
        private FileLogger _uut;
        private Writer writer;

        [SetUp]
        public void Setup()
        {
            writer = new Writer();
            fakeFilewriter = Substitute.For<IStreamWriter>();
            fakeTimeProvider = Substitute.For<ITimeProvider>();
            _uut = new FileLogger(fakeFilewriter,fakeTimeProvider);
        }

        [TestCase(1, 2)]
        [TestCase(2, 2)]
        public void ctor_Log_Created(int i, int id)
        {
            _uut.log(i,id);
            Assert.That(File.Exists(writer.Path),Is.True);
        }


        [TestCase(1, 55)]
        [TestCase(1, -10)]
        [TestCase(1, 1000)]
        public void Test_Låst_CheckFile(int i,int id)
        {
            fakeTimeProvider.getTime().Returns("22-3-2022");
            _uut.log(i,id);
            fakeFilewriter.Received(1).WriteLineToFile("22-3-2022 Skab låst med RFID:"+id);

        }

        //H
        [TestCase(2, 50)]
        [TestCase(2, -10)]
        [TestCase(2, 125)]
        public void Test_LåstOp_CheckFile(int i, int id)
        {
            fakeTimeProvider.getTime().Returns("22-3-2022");
            _uut.log(i, id);
            fakeFilewriter.Received(1).WriteLineToFile("22-3-2022 Skab låst op med RFID:" + id);

        }

    }
}
