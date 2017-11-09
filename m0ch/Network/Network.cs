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
        /// Responsible for storing messages that were casted from received bytes
        /// </summary>
        private System.Collections.Concurrent.ConcurrentQueue<Message> treatedInbox;


        /// <summary>
        /// Variable that stores all the messages that failed to be sent
        /// </summary>
        private System.Collections.Concurrent.ConcurrentQueue<MessageContainer> resendInbox; 
        
        
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
            resendInbox = new ConcurrentQueue<MessageContainer>();

            listeningServer = new Server(Listeningport, ref untreatedInbox);
            Start();

        }

        /// <summary>
        /// Initializes the server's thread
        /// </summary>
        private void Start()
        {
            Thread serverThread = new Thread(listeningServer.RunServer);
            serverThread.Start();
            
            
            Thread castingThread = new Thread(CastingMessages);
            castingThread.Start();
            
        }

        /// <summary>
        /// Function responsible for making the server stop listening
        /// </summary>
        public void StopServer()
        {
            listeningServer.stopServer();

        }


        /// <summary>
        /// This function runs in a thread and is responsible for retrieve each message from untreatedInbox and 
        /// converting it a message object and store it in treatedInbox.
        /// </summary>
        private void CastingMessages()
        {

            while (true)
            {

                if (untreatedInbox.Count > 0)
                {
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
            
            
        }
    }
}