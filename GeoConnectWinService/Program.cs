using Topshelf;


namespace GeoConnectWinService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<TopshelfService>(s =>
                {
                    s.ConstructUsing(name => new TopshelfService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("Retro Notes Windows Service");
                x.SetDisplayName("Retro Notes Services");
                x.SetServiceName("RetroNotesServices");
            });
        }
    }
}
