using GeoConnectJiraServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Topshelf;
using  Microsoft.Owin.Hosting;
using  Microsoft.Owin.Host.HttpListener;


namespace GeoConnectWinService
{
    public class TopshelfService
    {
        private IDisposable WebServer = null;

        public void Start()
        {
            WebServer = WebApp.Start<Startup>("http://localhost:5678");
        }

        public void Stop()
        {
            this.WebServer?.Dispose();
        }
    }
}
