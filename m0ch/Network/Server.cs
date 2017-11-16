using System;
using System.Collections.Concurrent;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using m0ch.Agents;
using m0ch.Utils;
using NLog;

namespace m0ch.Network
{
    /// <summary>
    /// Class responsible for the server's management
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Variable responsible for logging.
        /// </summary>
        private static readonly Logger LoggerObj = LogManager.GetCurrentClassLogger();
        
        // Server Listener
        private readonly TcpListener _svPort;
        
        // Variable responsible for making the thread stop
        private bool _stopListening;
        
        // Variable shared with Network in order to share the bytes received by server 
        private readonly ConcurrentQueue<byte[]> _inbox;

        /// <summary>
        /// Constructor that defines every member of class Server
        /// </summary>
        /// <param name="untreatedInbox">Inbox where server should add the received bytes</param>
        public Server(int port, ref ConcurrentQueue<byte[]> untreatedInbox)
        {
            _svPort = new TcpListener(IPAddress.Any, port);
            _stopListening = false;
            this._inbox = untreatedInbox;
        }

        /// <summary>
        /// Function responsible for listning an already defined port
        /// </summary>
        public void RunServer()
        {
            LoggerObj.Trace("Server is listening.");
            _svPort.Start();

            while (!_stopListening)
            {

                TcpClient incomingMessage = _svPort.AcceptTcpClient();
                NetworkStream sn = incomingMessage.GetStream();
                
                LoggerObj.Debug("Server received new message.");
                
                if (sn.CanRead){
                    byte[] data = new byte[incomingMessage.ReceiveBufferSize];

                    sn.Read(data, 0, incomingMessage.ReceiveBufferSize);

                    //castMessage(data);
                    this._inbox.Enqueue(data);
                    LoggerObj.Debug("Server stored received data.");
                }

                sn.Close();
            }

        }

        /// <summary>
        /// Function used to stop listening. Used to stop server thread
        /// </summary>
        public void StopServer()
        {
            _stopListening = true;
            _svPort.Stop();
            LoggerObj.Trace("Server is no longer listening.");
        }


        /// <summary>
        /// Responsible for converting the received message into a readable
        /// string in order to be treated correctly.
        /// </summary>
        /// <param name="data">Data received by server</param>
        public void CastMessage(byte[] data){

            // Not considering other algorithms other than GZIP for now
            string toDecompress = Compression.DecompressData(data, Misc.CompressionAlgorithm.Gzip);

            Console.WriteLine(toDecompress);
        }

    }
}
