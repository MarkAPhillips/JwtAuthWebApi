using Microsoft.Owin.Hosting;
using WebApi;
using System;
using System.Configuration;
using System.ServiceProcess;

namespace WebApiSelfHost
{
    public partial class Service1 : ServiceBase
    {
        private static void Main(string[] args)
        {
            Service1 service = new Service1();
            
            if (Environment.UserInteractive)
            {
                service.OnStart(args);
                Console.WriteLine("Press any key to stop program");
                Console.Read();
                service.OnStop();
            }
            else
            {
                ServiceBase.Run(service);
            }
        }

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Starting service...");

            int port = 90;
            StartOptions options = new StartOptions();
            options.Urls.Add(String.Format("http://{0}:{1}", Environment.MachineName, port));
            options.Urls.Add(String.Format("http://{0}:{1}", "127.0.0.1", port));
            options.Urls.Add(String.Format("http://{0}:{1}", "localhost", port));

            WebApp.Start<Startup>(options);
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down
            //necessary to stop your service.
            Console.WriteLine("Stopping service...");
        }
    }
}