using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
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
            var videoUrl = Driver.SessionId + ".mp4";
            var client = new RestClient("http://10.17.11.107:4444/video/");
            //var videoUrl2 = "selenoid" + Driver.SessionId + ".mp4";
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                TakeScreenShot();
                Driver.Quit();

                DownloadVideoAndAttach(client, videoUrl);
                DeleteFromSelenoid(client, videoUrl);
            }

            Driver?.Quit();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                DeleteFromSelenoid(client, videoUrl);
            }
        }

        public RemoteWebDriver Driver { get; set; }


        private void DeleteFromSelenoid(RestClient client, string videoName)
        {
            Thread.Sleep(2000);
            var deleteFromSelenoidRequest = new RestRequest(videoName, Method.DELETE);
            client.Execute(deleteFromSelenoidRequest);

        }

        public void DownloadVideoAndAttach(RestClient client, string videoName)
        {
            Thread.Sleep(2000);

            var downloadVideo = new RestRequest(videoName, Method.GET);
            var videoBytes = client.DownloadData(downloadVideo);

            using (Stream file = File.OpenWrite($"{TestContext.CurrentContext.Test.MethodName}_" + videoName))
            {
                file.Write(videoBytes, 0, videoBytes.Length);
            }

            var pathToVideo = Path.GetFullPath($"{TestContext.CurrentContext.Test.MethodName}_" + videoName);

            TestContext.AddTestAttachment(pathToVideo);
        }

        private void TakeScreenShot()
        {
            var pathToScreenShot = $"{TestContext.CurrentContext.Test.MethodName}_" + DateTime.Now.ToString("_MM\\_dd\\_yyyy_h\\-mm_tt") + ".png";
            Driver.GetScreenshot().SaveAsFile(pathToScreenShot, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(pathToScreenShot);
        }
    }
}
