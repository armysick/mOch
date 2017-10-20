using System;
using System.Collections.Generic;
using m0ch.Utils;
using System.Threading;

namespace m0ch.Network
{
    public class Networking
    {

        private List<Message> receivedMessages;
        private Server listeningServer;


        public Networking()
        {
            receivedMessages = new List<Message>();

            listeningServer = new Server(2000);
            start();

        }

        public void start()
        {

            Thread serverThread = new Thread(listeningServer.startServer);
            serverThread.Start();


        }

        public void stopServer(){

            listeningServer.stopServer();

        }
    }
}