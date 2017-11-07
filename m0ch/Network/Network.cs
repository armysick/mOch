﻿using System.IO;
using System.Collections.Generic;
using m0ch.Utils;
using System.Threading;
using System.Net.Sockets;

namespace m0ch.Network
{
    /// <summary>
    /// Responsible for handling all the network traffic present in this agent
    /// </summary>
    public class Networking
    {
        // Responsible for storing received messages from server
        private List<Message> receivedMessages;
        // Object representing server
        private Server listeningServer;

        /// <summary>
        /// Constructor responsible for initializing received messages's list and server's member.
        /// Already calls .start() function in order to start server's thread.
        /// </summary>
        /// <param name="Listeningport">Port in configuration file</param>
        public Networking(int Listeningport)
        {
            receivedMessages = new List<Message>();

            listeningServer = new Server(Listeningport, ref receivedMessages);
            start();

        }

        /// <summary>
        /// Initializes the server's thread
        /// </summary>
        public void start()
        {
            Thread serverThread = new Thread(listeningServer.runServer);
            serverThread.Start();

            //test server
            System.Threading.Thread.Sleep(2000);

            TcpClient test = new TcpClient();
            test.Connect("127.0.0.1", 2000);

            Message m1 = new Message(Perfomative.REQUEST);
            m1.addEnvelope(new FIPA.AID("",""), new FIPA.AID("",""));


            GZIP gzip = new GZIP(m1.ToString());

            Stream stm = test.GetStream();
            stm.Write(gzip.CompressData(), 0, gzip.CompressData().Length);
            test.Close();

        }

        /// <summary>
        /// Function responsible for making the server stop listening
        /// </summary>
        public void stopServer()
        {
            listeningServer.stopServer();

        }
    }
}