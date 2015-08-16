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
using Windows.Devices.Enumeration;

namespace RemoteDeviceManager.html
{
    public class settings : PageInterface
    {
        public delegate void ChangeCameraEventHandler(object sender,String deviceId);
        public event ChangeCameraEventHandler changeCamera;

        public override async Task<string> render(HttpServerRequest req)
        {
            return req.html;
        }

     
        public async override Task<string> renderHeader(HttpServerRequest req)
        {
        
            req.html = req.html.Replace("<!--HEADER_PLACEHOLDER-->", "<script language=\"javascript\">" +
"function reloadImage() {" +
     
        "var tempo = document.getElementById('seltime'); " +
        "var time = parseInt(tempo.options[tempo.selectedIndex].value); " +
        "setTimeout(\"document.getElementById('reloader').src ='camera_preview.jpg?rnd='+new Date().getMilliseconds()\", time); " +
    "}" +
"</script> ");

            return req.html;
        }

    
       
    }
}

