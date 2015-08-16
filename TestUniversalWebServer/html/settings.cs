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
using Windows.Storage.FileProperties;

namespace RemoteDeviceManager.html
{
    public class settings : PageInterface
    {
        public delegate void ChangeCameraEventHandler(object sender,String deviceId);
        public event ChangeCameraEventHandler changeCamera;

        public override async Task<string> render(HttpServerRequest req)
        {
            PostParameter file= req.postParameters.Where(x => x.name == "upload").FirstOrDefault();
            if (file != null)
            {
               BasicProperties prop= await file.contentFile.GetBasicPropertiesAsync();
                req.html=req.html.Replace("<%FILEINFO%>", "File info:<br/>Name: "+Path.GetFileName(file.value)+"<br/>Size: "+(prop.Size/1000)+"KB");
            }else
                req.html=req.html.Replace("<%FILEINFO%>", "");
            return req.html;
        }

     
        

    
       
    }
}

