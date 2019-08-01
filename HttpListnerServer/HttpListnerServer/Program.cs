using System;
using System.IO;
using System.Net;

namespace HttpListnerServer
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpServer server = new HttpServer("8080");
            server.startServer();
        }
    }
}
