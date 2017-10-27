using System;
namespace m0ch.FIPA
{
    /// <summary>
    /// Class containing all Agent Management Services
    /// </summary>
    public class AMServices
    {
        // Object representing the agent management system
        private AMS ams;

        // Object representing the directory facilitator
        private DF df;

        public AMServices()
        {
            df = new DF("127.0.0.1");
        }
    }
}
