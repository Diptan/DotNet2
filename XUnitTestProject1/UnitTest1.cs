using System;
using System.Threading;
using NUnit.Framework;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace XUnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        private int _count = 0;
        [Test]
        public void Test1()
        {
        }

        [Repeat(3)]
        [Test]
        public void Test2()
        {
            Assert.AreEqual(1, _count);
        }
    }
}
