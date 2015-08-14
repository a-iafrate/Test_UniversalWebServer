using EasyHttpServer.Server;
using EasyHttpServer.Utils;
using RemoteDesktopManager.Utils;
using RemoteDeviceManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWebServer.Server;
using Windows.Phone.Devices.Power;
using Windows.Storage;

namespace RemoteDesktopManager.html
{
    public class login:PageInterface
    {
        public override bool isLoginPage()
        {
            return true;
        }

    
        public async override Task<string> renderHeader(HttpServerRequest req)
        {
            return "";
        }

        public override async Task<string> renderFooter(HttpServerRequest req)
        {
            return "";
        }

        public async override Task<string> render(HttpServerRequest req)
        {
            //html = html.Replace("<%text_type_password%>", Util.loader.GetString("TypePassword"));
            if (req.getParameters.ContainsKey("p"))
            {
            
                switch (req.getParameters["p"])
                {
                    /*case "i":
                        return Convert.ToInt32(App.IsTrial) + ";" + Convert.ToInt32(this.httpServer.removeLogin);*/
                    case "l":
                        bool logged = false;
                        {
                            if (req.getParameters.ContainsKey("password"))
                            {
                                String password = "";
                                if (Windows.Storage.ApplicationData.Current.LocalSettings.Values.ContainsKey("password"))
                                    password = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["password"];
                                else
                                    password = "000";
                                if (req.getParameters["password"].Equals(password))
                                {
                                    logged = true;
                                    Util.authorizedIp.Add(httpServer.lastIpAddress);
                                }
                            }
                        }
                        return Convert.ToInt32(logged)+"";
                    default:
                        return "";
                }
            }else
                return req.html;
        }

        
    }
}
