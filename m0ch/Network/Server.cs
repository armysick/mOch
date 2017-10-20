using System;
using System.Net.Sockets;
using System.Net;

namespace m0ch.Network
{
    public class Server
    {

        private TcpListener sv_port;
        private bool stopListening;

        public Server(int port)
        {
            sv_port = new TcpListener(IPAddress.Any, port);
            stopListening = false;
        }


        public void startServer()
        {
            Console.WriteLine("Server has opened!");
            sv_port.Start();

            while (!stopListening)
            {

                TcpClient incomingMessage = sv_port.AcceptTcpClient();

                NetworkStream sn = incomingMessage.GetStream();

                Console.WriteLine(sn.ToString());

                sn.Close();
            }

        }

        public void stopServer()
        {
            stopListening = true;
            sv_port.Stop();
        }
    }
}
