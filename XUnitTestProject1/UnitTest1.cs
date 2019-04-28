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
        [Test]
        public void Test1()
        {
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Test3()
        {
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }
    }
}
