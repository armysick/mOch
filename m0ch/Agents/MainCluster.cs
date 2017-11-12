using System;
using System.Net;
using m0ch.FIPA;
using m0ch.Network;
using m0ch.Utils;

namespace m0ch.Agents
{
    
    /// <summary>
    /// Class that represents the FIPA cluster
    /// </summary>
    class MainCluster : AbstractAgent
    {
        
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
        public MainCluster(AgentPlatformConfig config)
        {
            this.NetworkAcess = new Networking(config.getServerPort());
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
