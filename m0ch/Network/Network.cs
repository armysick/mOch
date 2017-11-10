using System;
using System.Collections.Concurrent;
using m0ch.Utils;
using System.Threading;
using m0ch.Agents;

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
        private readonly System.Collections.Concurrent.ConcurrentQueue<byte[]> _untreatedInbox;

        /// <summary>
        /// Thread responsible adding the received bytes in untreatedInbox.
        /// </summary>
        private Thread _serverThread;

        /// <summary>
        /// Responsible for storing messages that were casted from received bytes.
        /// </summary>
        private readonly System.Collections.Concurrent.ConcurrentQueue<Message> _treatedInbox;

        /// <summary>
        /// Responsible for casting all the bytes present in the untreatedInbox and store them in the treatedInbox.
        /// </summary>
        private Thread _castingThread;

        /// <summary>
        /// Variable that stores all the messages that failed to be sent
        /// </summary>
        private readonly System.Collections.Concurrent.ConcurrentQueue<MessageContainer> _sendInbox;

        /// <summary>
        /// Responsible for managing all the messages to be sent.
        /// </summary>
        private Thread _responseThread;

        /// <summary>
        /// Object that handles the listening part of the platform
        /// </summary>
        private readonly Server _listeningServer;

        /// <summary>
        /// Constructor responsible for initializing received messages's list and server's member.
        /// Already calls .start() function in order to start server's thread.
        /// </summary>
        /// <param name="listeningport">Port in configuration file</param>
        public Networking(int listeningport)
        {
            _untreatedInbox = new ConcurrentQueue<byte[]>();
            _treatedInbox = new ConcurrentQueue<Message>();
            _sendInbox = new ConcurrentQueue<MessageContainer>();

            _listeningServer = new Server(listeningport, ref _untreatedInbox);
            Start();
        }

        /// <summary>
        /// Initializes the server's thread
        /// </summary>
        private void Start()
        {
            _serverThread = new Thread(_listeningServer.RunServer);
            _serverThread.Start();


            _castingThread = new Thread(CastingMessages);
            _castingThread.Start();


            _responseThread = new Thread(ResponseMessages);
            _responseThread.Start();
        }

        /// <summary>
        /// Function responsible for making the server stop listening
        /// </summary>
        public void StopServer()
        {
            _listeningServer.StopServer();

            _serverThread.Join();
            _castingThread.Join();
            _responseThread.Join();
        }


        /// <summary>
        /// This function runs in a thread and is responsible for retrieve each message from untreatedInbox and 
        /// converting it a message object and store it in treatedInbox.
        /// </summary>
        private void CastingMessages()
        {
            while (true)
            {
                if (_untreatedInbox.Count == 0)
                    continue;

                try
                {
                    Message receivedMessage;
                    byte[] receivedBytes;


                    while (!_untreatedInbox.TryDequeue(out receivedBytes))
                    { };

                    // Added a useless string instead of the message for now
                    // TODO: Serialization of messages to better decoding

                    _treatedInbox.Enqueue(new Message(Perfomative.Failure));
                    MainCluster.GotNewMessage.Invoke(null, null);
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
        private void ResponseMessages()
        {
            while (true)
            {
                if (_sendInbox.Count == 0)
                    continue;

                MessageContainer messageContainer;
                while (!_sendInbox.TryDequeue(out messageContainer))
                {

                    //TODO: To send
                }
            }
        }
    }
}