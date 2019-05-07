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
        public void Test11()
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", true);
            var ff = new RemoteWebDriver(new Uri("http://10.17.11.107:4444/wd/hub"), capabilities);

            ff.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(10000);
            ff.Quit();

            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }



        [Test]
        public void Test12()
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", true);
            var ff = new RemoteWebDriver(new Uri("http://10.17.11.107:4444/wd/hub"), capabilities);

            ff.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(10000);
            ff.Quit();
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }
    }



    [Parallelizable]
    [TestFixture]
    public class UnitTest2
    {
        [Test]
        public void Test21()
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", true);
            var ff = new RemoteWebDriver(new Uri("http://10.17.11.107:4444/wd/hub"), capabilities);

            ff.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(10000);
            ff.Quit();
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void Test22()
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", true);
            var ff = new RemoteWebDriver(new Uri("http://10.17.11.107:4444/wd/hub"), capabilities);

            ff.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(10000);
            ff.Quit();
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }
    }

    [Parallelizable]
    [TestFixture]
    public class UnitTest3
    {
        [Test]
        public void Test31()
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", true);
            var ff = new RemoteWebDriver(new Uri("http://10.17.11.107:4444/wd/hub"), capabilities);

            ff.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(10000);
            ff.Quit();
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 2);
        }

        [Test]
        public void Test32()
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", true);
            var ff = new RemoteWebDriver(new Uri("http://10.17.11.107:4444/wd/hub"), capabilities);

            ff.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(10000);
            ff.Quit();
            Console.WriteLine("Step 1");
            Console.WriteLine("Step 2");
            Assert.AreEqual(1, 1);
        }
    }
}


