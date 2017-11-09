using System;
using System.Collections.Concurrent;
using System.IO;
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
        /// <summary>
        /// Stores all the bytes that this agents received by the server thread
        /// </summary>
        private System.Collections.Concurrent.ConcurrentQueue<byte[]> untreatedInbox;
        
        /// <summary>
        /// Thread responsible adding the received bytes in untreatedInbox.
        /// </summary>
        private Thread serverThread;
        
        /// <summary>
        /// Responsible for storing messages that were casted from received bytes.
        /// </summary>
        private System.Collections.Concurrent.ConcurrentQueue<Message> treatedInbox;
        
        /// <summary>
        /// Responsible for casting all the bytes present in the untreatedInbox and store them in the treatedInbox.
        /// </summary>
        private Thread castingThread;
        
        /// <summary>
        /// Variable that stores all the messages that failed to be sent
        /// </summary>
        private System.Collections.Concurrent.ConcurrentQueue<MessageContainer> sendInbox;

        /// <summary>
        /// Responsible for managing all the messages to be sent.
        /// </summary>
        private Thread responseThread;

        /// <summary>
        /// Object that handles the listening part of the platform
        /// </summary>
        private Server listeningServer;

        /// <summary>
        /// Constructor responsible for initializing received messages's list and server's member.
        /// Already calls .start() function in order to start server's thread.
        /// </summary>
        /// <param name="Listeningport">Port in configuration file</param>
        public Networking(int Listeningport)
        {
            untreatedInbox = new ConcurrentQueue<byte[]>();
            treatedInbox = new ConcurrentQueue<Message>();
            sendInbox = new ConcurrentQueue<MessageContainer>();

            listeningServer = new Server(Listeningport, ref untreatedInbox);
            Start();
        }

        /// <summary>
        /// Initializes the server's thread
        /// </summary>
        private void Start()
        {
            serverThread = new Thread(listeningServer.RunServer);
            serverThread.Start();


            castingThread = new Thread(CastingMessages);
            castingThread.Start();


            responseThread = new Thread(responseMessages);
            responseThread.Start();
        }

        /// <summary>
        /// Function responsible for making the server stop listening
        /// </summary>
        public void StopServer()
        {
            listeningServer.stopServer();

            serverThread.Join();
            castingThread.Join();
            responseThread.Join();
        }


        /// <summary>
        /// This function runs in a thread and is responsible for retrieve each message from untreatedInbox and 
        /// converting it a message object and store it in treatedInbox.
        /// </summary>
        private void CastingMessages()
        {
            while (true)
            {
                if (untreatedInbox.Count == 0)
                    continue;

                try
                {
                    Message receivedMessage;
                    byte[] receivedBytes;


                    while (!untreatedInbox.TryDequeue(out receivedBytes))
                    {};

                    // Added a useless string instead of the message for now
                    // TODO: Serialization of messages to better decoding

                    treatedInbox.Enqueue(new Message(Perfomative.FAILURE));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        
        /// <summary>
        /// Function that runs in a thread and tries to send all the messages present in sendInbox.
        /// </summary>
        private void responseMessages()
        {
            while (true)
            {
                if (sendInbox.Count == 0)
                    continue;

                MessageContainer messageContainer;
                while (!sendInbox.TryDequeue(out messageContainer))
                {
                    
                    //TODO: To send
                    
                }
            }
        }
    }
}