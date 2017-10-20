using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using m0ch.Utils;

namespace m0ch.Network
{
    public class Server
    {

        private TcpListener sv_port;
        private bool stopListening;
        private List<Message> inbox;

        public Server(int port, ref List<Message> inbox)
        {
            sv_port = new TcpListener(IPAddress.Any, port);
            stopListening = false;
            this.inbox = inbox;
        }

        public void startServer()
        {
            Console.WriteLine("Server has opened!");
            sv_port.Start();

            while (!stopListening)
            {

                TcpClient incomingMessage = sv_port.AcceptTcpClient();

                NetworkStream sn = incomingMessage.GetStream();
                string dataSent = "";

                if (sn.CanRead){
                    byte[] data = new byte[incomingMessage.ReceiveBufferSize];

                    sn.Read(data, 0, incomingMessage.ReceiveBufferSize);

                    dataSent = Encoding.UTF8.GetString(data);
                }

                Console.WriteLine("Message from {1}: {0}" , dataSent,
                                  incomingMessage.Client.RemoteEndPoint);

                sn.Close();
            }

        }

        public void stopServer()
        {
            stopListening = true;
            sv_port.Stop();
        }

        public void castMessage(){
            
        }

    }
}
