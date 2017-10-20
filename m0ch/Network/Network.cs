using System.IO;
using System.Collections.Generic;
using m0ch.Utils;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace m0ch.Network
{
    public class Networking
    {

        private List<Message> receivedMessages;
        private Server listeningServer;


        public Networking()
        {
            receivedMessages = new List<Message>();

            listeningServer = new Server(2000, ref receivedMessages);
            start();

        }

        public void start()
        {
            Thread serverThread = new Thread(listeningServer.startServer);
            serverThread.Start();

            /* test server
            System.Threading.Thread.Sleep(2000);

            TcpClient test = new TcpClient();
            test.Connect("127.0.0.1", 2000);


            byte[] bb = new ASCIIEncoding().GetBytes("Ola");

            Stream stm = test.GetStream();
            stm.Write(bb, 0,bb.Length);
            test.Close();
            */
        }

        public void stopServer()
        {
            listeningServer.stopServer();

        }
    }
}