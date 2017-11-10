using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m0ch.FIPA;
using m0ch.Network;

namespace m0ch.Agents
{
    
    /// <summary>
    /// Class that represents the FIPA cluster
    /// </summary>
    class MainCluster
    {

        /// <summary>
        /// Variable that holds everything that happens in the network
        /// </summary>
        private Network.Networking _networkAcess;
        
        /// <summary>
        /// Variable that holds and is used to interact with AMS and DF
        /// </summary>
        private FIPA.AMServices _services;


        /// <summary>
        /// Event that is fired when MainCluster has a new message
        /// </summary>
        public static EventHandler GotNewMessage;

        /// <summary>
        /// Constructor of MainCluster
        /// </summary>
        /// <param name="serverPort"></param>
        public MainCluster(int serverPort)
        {
            this._networkAcess = new Networking(serverPort);
            this._services = new AMServices();

            GotNewMessage += GotMessageEvent;
        }
        
        /// <summary>
        /// Function that is runned as soon as there are a new message
        /// </summary>
        /// <param name="Object"></param>
        /// <param name="args"></param>
        private void GotMessageEvent(object Object, EventArgs args)
        {
            Console.WriteLine("Got a new Message");
        }
        
        
        
    }
}
