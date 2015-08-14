﻿using EasyHttpServer.Server;
using EasyHttpServer.Utils;
using RemoteDesktopManager.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UniversalWebServer.Server;
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
            PostParameter selcamera =req.postParameters.Where(x=>x.name.Equals("sel_camera")).FirstOrDefault();
            String selDeviceId = PhoneUtility.getStringSettings("SEL_CAM_ID", null);
            if (selcamera != null)
            {
                if (changeCamera != null)
                    changeCamera(this, selcamera.value);
            }
            String options = "";
            DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            foreach (var device in devices)
            {
                options += "<option value='"+device.Id+"' ";
                if(selcamera!=null && selcamera.value.Equals(device.Id))
                {
                    options += "selected ";
                }
                if(selcamera==null && selDeviceId.Equals(device.Id))
                {
                    options += "selected ";
                }
                options += ">" + device.Name + "</option>";
            }

            req.html = req.html.Replace("<%OPTIONS%>", options);
            return req.html;
        }

     
        public async override Task<string> renderHeader(HttpServerRequest req)
        {
            req.html = PageUtils.translateHeader(req.html);
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
