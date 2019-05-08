using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using RestSharp;

namespace XUnitTestProject1
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void Start()
        {
            var capabilities = new DesiredCapabilities("chrome", "73.0", new Platform(PlatformType.Any));
            capabilities.SetCapability("enableVNC", true);
            capabilities.SetCapability("enableVideo", true);
            Driver = new RemoteWebDriver(new Uri("http://10.17.11.107:4444/wd/hub"), capabilities);
        }

        [TearDown]
        public void End()
        {
            var videoName = Driver.SessionId + ".mp4";
            var selenoidClient = new SelenoidVideoHelper("http://10.17.11.107:4444/video/");

            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TakeScreenShot();
                Driver.Quit();
                selenoidClient.DownloadVideo(videoName);

                TestContext.AddTestAttachment(videoName);
            }
            Driver?.Quit();
            selenoidClient.DeleteFromServer(videoName);
        }

        public RemoteWebDriver Driver { get; set; }

        private void TakeScreenShot()
        {
            var pathToScreenShot = $"{TestContext.CurrentContext.Test.MethodName}_" + DateTime.Now.ToString("_MM\\_dd\\_yyyy_h\\-mm_tt") + ".png";
            Driver.GetScreenshot().SaveAsFile(pathToScreenShot, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(pathToScreenShot);
        }
    }
}
