using EasyHttpServer.Server;
using RemoteDesktopManager.html;
using RemoteDeviceManager.html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento per la pagina vuota è documentato all'indirizzo http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace TestUniversalWebServer
{
    /// <summary>
    /// Pagina vuota che può essere utilizzata autonomamente oppure esplorata all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            const int port = 8001;
            HttpServer server = new HttpServer(port);



            await server.init();
           

                //server.removeLogin = true;


            

            server.Connected += Server_Connected;
            server.customPageInterface = new CustomPage();
            HttpServerPage defPage = new HttpServerPage("about.html", new RemoteDeviceManager.html.about());
            server.pagesMap.Add(defPage);
            server.pagesMap.Add(new HttpServerPage("login.html", new login()));
            
            server.pagesMap.Add(new HttpServerPage("settings.html", new settings()));
            server.defaultpage = defPage;
            
        }

        private void Server_Connected(object sender)
        {

        }
    }
}
