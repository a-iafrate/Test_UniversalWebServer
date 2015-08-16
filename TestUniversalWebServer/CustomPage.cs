using EasyHttpServer.Server;
using EasyHttpServer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace TestUniversalWebServer
{
    public class CustomPage : CustomPageInterface
    {
        public override async Task<bool> rewrite(System.IO.Stream resp, HttpServerRequest req)
        {
            String tempPath = req.path;
            if (req.path.IndexOf("?") != -1)
                tempPath = tempPath.Substring(0, req.path.IndexOf("?"));
            switch (tempPath)
            {
                case "/hello.png":
                    byte[] imageByte = await DownloadImageFromWebsiteAsync("https://assets.windowsphone.com/db658987-b7ca-43aa-885c-fd4426fb6962/Downloads-VS_InvariantCulture_Default.png");

                        String contentType = Util.getContentType("/hello.png");
                    string header = String.Format("HTTP/1.1 200 OK\r\n" +
                                    "Content-Length: {0}\r\n" + contentType +
                                    "Cache-Control: no-cache, no-store, must-revalidate\r\nPragma: no-cache\r\nExpires: 0\r\n" +
                                    "Connection: close\r\n\r\n",
                                    imageByte.Length);

                    byte[] headerArray = Encoding.UTF8.GetBytes(header);
                    await resp.WriteAsync(headerArray, 0, headerArray.Length);
                    await resp.WriteAsync(imageByte, 0, imageByte.Length);

                    return true;
                    break;

            }
            return false;
        }

        private async Task<byte[]> DownloadImageFromWebsiteAsync(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                using (WebResponse response = await request.GetResponseAsync())
                using (var result = new MemoryStream())
                {
                    await response.GetResponseStream().CopyToAsync(result);
                    return result.ToArray();
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }
    }
}
