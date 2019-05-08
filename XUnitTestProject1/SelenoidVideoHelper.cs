using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using RestSharp;

namespace XUnitTestProject1
{
    public class SelenoidVideoHelper
    {
        private readonly RestClient _client;

        public SelenoidVideoHelper(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public void DownloadVideo(string videoName)
        {
            var downloadVideo = new RestRequest(videoName, Method.GET);
            Wait.For(()=>_client.Execute(downloadVideo).StatusCode == HttpStatusCode.OK, 5);
            var videoBytes = _client.DownloadData(downloadVideo);

            using (Stream file = File.OpenWrite(videoName))
            {
                file.Write(videoBytes, 0, videoBytes.Length);
            }
        }

        public IList<string> GetAllVideos()
        {
            var request = new RestRequest(Method.GET);
            var responseContent = _client.Execute(request).Content;

            return XElement.Parse(responseContent)
                .Descendants("a")
                .Select(x => x.Attribute("href")?.Value)
                .ToList();
        }

        public void DeleteAllVideo()
        {
            foreach (var video in GetAllVideos())
            {
                var deleteRequest = new RestRequest(video, Method.DELETE);
                _client.Execute(deleteRequest);
            }
        }

        public void DeleteFromServer( string videoName)
        {
            var downloadVideo = new RestRequest(videoName, Method.GET);
            Wait.For(() => _client.Execute(downloadVideo).StatusCode == HttpStatusCode.OK, 5);
            var deleteFromSelenoidRequest = new RestRequest(videoName, Method.DELETE);
            _client.Execute(deleteFromSelenoidRequest);
        }
    }
}
