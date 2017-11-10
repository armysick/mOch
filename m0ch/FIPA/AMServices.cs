using System;
using m0ch.Utils;

namespace m0ch.FIPA
{
    /// <summary>
    /// Class containing all Agent Management Services
    /// </summary>
    public class AMServices
    {
        /// <summary>
        /// Object representing the agent management system
        /// </summary>
        private AMS _ams;

        /// <summary>
        /// Object representing the directory facilitator
        /// </summary>
        private DF _df;

        
        /// <summary>
        /// Initialize all the major services provided by the platform
        /// </summary>
        public AMServices()
        {
            StartAMS();
            _df = new DF();
        }

        /// <summary>
        /// Function used to create a AMS object
        /// </summary>
        private void StartAMS()
        {
            
            APtransportDescription apDescription = new APtransportDescription();
            
            //TODO: Add a config file
            AgentPlatformDescription platformDescription = new AgentPlatformDescription("regularname",
                false, false, apDescription);
            
            _ams = new AMS(platformDescription);
            
        }
    }
}
