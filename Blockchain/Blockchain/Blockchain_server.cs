using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;


namespace Blockchain
{
    class Blockchain_server
    {
        static void Main(string[] args)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1/");
            server.Prefixes.Add("http://localhost/");

            server.Start();

            Console.WriteLine("Listening...");

            while(true)
            {

                HttpListenerContext context = server.GetContext();
                //context: provides access to httplistener's response

                HttpListenerResponse response = context.Response;
                //the response tells the server where to send the datas


            }


        }



    }
}
