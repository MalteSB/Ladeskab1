using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab1;
using System.IO;
using NSubstitute;

namespace LadeSkabTest
{
    public class UnitTestFileLogger
    {

        private IStreamWriter fakeFilewriter;
        private ITimeProvider fakeTimeProvider;
        private FileLogger _uut;

        [SetUp]
        public void Setup()
        {
            fakeFilewriter = Substitute.For<IStreamWriter>();
            fakeTimeProvider = Substitute.For<ITimeProvider>();
            _uut = new FileLogger(fakeFilewriter,fakeTimeProvider);
        }

        [Test]
        {


        }






    }
}
