using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace XUnitTestProject1
{
    [Parallelizable]
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            var capabilities = new DesiredCapabilities("firefox", "66.0", new Platform(PlatformType.Any));
            var ff = new RemoteWebDriver(new Uri("http://10.17.8.70:4444/wd/hub"), capabilities);

            ff.Navigate().GoToUrl("https://www.google.com");
            ff.Close();
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Test2()
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            var ff = new RemoteWebDriver(new Uri("http://10.17.8.70:4444/wd/hub"), capabilities);

            ff.Navigate().GoToUrl("https://www.google.com");
            ff.Close();
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }

        [Parallelizable]
        [TestFixture]
        public class UnitTest2
        {
            [Test]
            public void Test1()
            {
                var capabilities = new DesiredCapabilities("firefox", "66.0", new Platform(PlatformType.Any));
                var ff = new RemoteWebDriver(new Uri("http://10.17.8.70:4444/wd/hub"), capabilities);

                ff.Navigate().GoToUrl("https://www.google.com");
                ff.Close();
                Console.WriteLine("Step 1");
                Console.WriteLine("Step 2");
                Assert.AreEqual(1, 1);
            }

            [Test]
            public void Test2()
            {
                var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
                var ff = new RemoteWebDriver(new Uri("http://10.17.8.70:4444/wd/hub"), capabilities);

                ff.Navigate().GoToUrl("https://www.google.com");
                ff.Close();
                Console.WriteLine("Step 1");
                Console.WriteLine("Step 2");
                Assert.AreEqual(1, 1);
            }
        }
    }
}
