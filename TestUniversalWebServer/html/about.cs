using EasyHttpServer.Server;
using EasyHttpServer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace RemoteDeviceManager.html
{
    public class about : PageInterface
    {
        public override async Task<string> render(HttpServerRequest req)
        {

            //html = html.Replace("<%text_contact_us%>", Util.loader.GetString("ContactUs"));
            //html = html.Replace("<%version%>", PhoneUtility.getAppVersion());
            return req.html;
        }

      
        public async override Task<string> renderHeader(HttpServerRequest req)
        {
          
            return req.html;
        }

        

       
    }
}

