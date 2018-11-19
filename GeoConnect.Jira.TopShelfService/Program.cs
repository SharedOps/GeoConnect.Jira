using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace GeoConnect.Jira.TopShelfService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<TopShelfService>(s =>
                {
                    s.ConstructUsing(name => new TopShelfService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("Jira Windows Service");
                x.SetDisplayName("Jira Services");
                x.SetServiceName("JiraServices");
            });
        }
    }
}
