using System;
using Microsoft.Owin.Hosting;
using GeoConnectJiraServices;

namespace TopShelfService
{
    public class TopshelfService
    {
        private IDisposable WebServer = null;

        public void Start()
        {
            WebServer = WebApp.Start<Startup>("http://localhost:56778");
        }

        public void Stop()
        {
            this.WebServer?.Dispose();
        }

    }
}
