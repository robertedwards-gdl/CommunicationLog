﻿namespace DentalServices.CommunicationLog
{
    using System;
    using Nancy.Hosting.Self;

    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:3579");

            using (var host = new NancyHost(uri))
            {
                host.Start();


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
