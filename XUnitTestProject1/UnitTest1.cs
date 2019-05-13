using System;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace XUnitTestProject1
{
    [TestFixture]
    public class UnitTest1 : BaseTest
    {
        [Test]
        public void Test11()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");

            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual("1", TestContext.Parameters["UI"]);
        }

        [Test]
        public void Test12()
        {
            Driver.Navigate().GoToUrl("https://reportportal.io/");
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual("1", TestContext.Parameters["UI"]);
        }
    }

    [TestFixture]
    public class UnitTest2 : BaseTest
    {
        [Test]
        public void Test21()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual("1", TestContext.Parameters["UI"]);
        }

        [Test]
        public void Test22()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual("1", TestContext.Parameters["UI"]);
        }
    }

    [TestFixture]
    public class UnitTest3 : BaseTest
    {
        [Test]
        public void Test31()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual("1", TestContext.Parameters["UI"]);
        }

        [Test]
        public void Test32()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual("1", TestContext.Parameters["UI"]);
        }
        [Test]
        public void Test33()
        {
            Driver.Navigate().GoToUrl("https://www.google.com");
            Driver.Navigate().GoToUrl("https://portal.azure.com/");
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual("1", TestContext.Parameters["UI"]);
        }
    }
}


