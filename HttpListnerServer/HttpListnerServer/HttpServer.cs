using System.IO;
using System.Net;

namespace HttpListnerServer
{
    public class HttpServer
    {
        private string _port;
        private string _directory = "C:/Users/acharpe/source/repos/HttpListnerServer/HttpListnerServer";
     
        public HttpServer(string port)
        {
            _port = port;
        }

        public void startServer()
        {
            HttpListener listener = new HttpListener();
            try
            {
                System.Console.WriteLine("Waiting for connection.....");
                listener.Prefixes.Add("http://localhost:" + _port + "/");
                listener.Start();

                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                System.Console.WriteLine("Accessed data from "+request.Url);

                string[] url = request.Url.ToString().Split(_port);
    
                string file = File.ReadAllText(_directory + url[1]);

                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(file);
          
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();
                listener.Stop();
            }
            catch
            {

            }
        }


    }
}