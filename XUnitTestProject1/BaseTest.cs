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
            var videoUrl2 = "selenoid" + Driver.SessionId + ".mp4";
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Driver.GetScreenshot().SaveAsFile($"{TestContext.CurrentContext.Test.MethodName}_Error" + ".png", ScreenshotImageFormat.Png);
                var pathToScreenShot = Path.GetFullPath($"{TestContext.CurrentContext.Test.MethodName}_Error" + ".png");
                TestContext.AddTestAttachment(pathToScreenShot);

                
            }

            Driver.Quit();
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                var client = new RestClient("http://10.17.11.107:4444/video/");

                var request = new RestRequest(videoUrl, Method.DELETE);
                Thread.Sleep(5000);

                var req = new RestRequest(videoUrl, Method.GET);

                var gg = client.DownloadData(req);

                using (Stream file = File.OpenWrite($"{TestContext.CurrentContext.Test.MethodName}_"+ videoUrl))
                {
                    file.Write(gg, 0, gg.Length);
                }

                client.Execute(request);

                var pathToVideo = Path.GetFullPath($"{TestContext.CurrentContext.Test.MethodName}_" + videoUrl);
                TestContext.AddTestAttachment(pathToVideo);

            }
        }

        public RemoteWebDriver Driver { get; set; }


       
        private void TakeScreenShot()
        {
          
        }
    }
}
