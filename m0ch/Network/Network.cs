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
            
            
        // Object representing server
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
            start();

        }

        /// <summary>
        /// Initializes the server's thread
        /// </summary>
        public void start()
        {
            Thread serverThread = new Thread(listeningServer.RunServer);
            serverThread.Start();
            
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