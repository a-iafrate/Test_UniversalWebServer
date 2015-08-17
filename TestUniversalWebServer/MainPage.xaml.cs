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
            // declare connection port
            const int port = 8001;
            // create new server instance
            HttpServer server = new HttpServer(port);
            // remove login function
            server.removeLogin = true;
           
            // Made some operation on server connected
            server.Connected += Server_Connected;
            // Create a custom page interface for virtual page
            server.customPageInterface = new CustomPage();
            // define a default page
            HttpServerPage defPage = new HttpServerPage("index.html", null);
            // Add to pages map
            server.pagesMap.Add(defPage);
            // Add other dynamic page to list, page with only html page not need to add
            server.pagesMap.Add(new HttpServerPage("login.html", new login()));
            server.pagesMap.Add(new HttpServerPage("settings.html", new settings()));
            //set the default page
            server.defaultpage = defPage;

            // init server
            await server.init();


        }

        private void Server_Connected(object sender)
        {

        }
    }
}
