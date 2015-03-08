namespace DentalServices.CommunicationLog
{
    using System;
    using Nancy.Hosting.Self;
    using log4net;

    class Program
    {
        static readonly ILog Logger = LogManager.GetLogger("Communication Service Host");
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:3579");

            using (var host = new NancyHost(uri))
            {
                host.Start();

                Logger.Info("Communication Service Started");

                Console.WriteLine("Your application is running on " + uri);

                var line = Console.ReadLine();
                while (line != "quit")
                {
                    line = Console.ReadLine();
                }
            }
        }
    }
}
