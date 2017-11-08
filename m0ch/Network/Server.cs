using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using m0ch.Utils;

namespace m0ch.Network
{
    /// <summary>
    /// Class responsible for the server's management
    /// </summary>
    public class Server
    {
        // Server Listener
        private TcpListener sv_port;
        // Variable responsible for making the thread stop
        private bool stopListening;
        // Variable shared with Network in order to share messages received by server 
        private List<Message> inbox;


        /// <summary>
        /// Constructor that defines every member of class Server
        /// </summary>
        /// <param name="port"></param>
        /// <param name="inbox"></param>
        public Server(int port, ref List<Message> inbox)
        {
            sv_port = new TcpListener(IPAddress.Any, port);
            stopListening = false;
            this.inbox = inbox;
        }

        /// <summary>
        /// Function responsible for listning an already defined port
        /// </summary>
        public void RunServer()
        {
            Console.WriteLine("Server has opened!");
            sv_port.Start();

            while (!stopListening)
            {

                TcpClient incomingMessage = sv_port.AcceptTcpClient();
                NetworkStream sn = incomingMessage.GetStream();

                if (sn.CanRead){
                    byte[] data = new byte[incomingMessage.ReceiveBufferSize];

                    sn.Read(data, 0, incomingMessage.ReceiveBufferSize);

                    castMessage(data);
                }

                Console.WriteLine("Message from {0}",
                                  incomingMessage.Client.RemoteEndPoint);

                sn.Close();
            }

        }

        /// <summary>
        /// Function used to stop listening. Used to stop server thread
        /// </summary>
        public void stopServer()
        {
            stopListening = true;
            sv_port.Stop();
        }


        /// <summary>
        /// Responsible for converting the received message into a readable
        /// string in order to be treated correctly.
        /// </summary>
        /// <param name="data">Data received by server</param>
        public void castMessage(byte[] data){

            // Not considering other algorithms other than GZIP for now
            string toDecompress = new GZIP("").DecompressData(data);

            Console.WriteLine(toDecompress);
        }

    }
}
