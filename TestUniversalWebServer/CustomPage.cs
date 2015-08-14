using EasyHttpServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWebServer.Server;

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
                case "/camera_stream.mjpg":
                    int i = 0;
                    return true;
                    break;

            }
            return false;
        }
    }
}
