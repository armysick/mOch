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
            AgentPlatformDescription platformDescription = new AgentPlatformDescription("ams",
                false, false, apDescription);
            
            _ams = new AMS(platformDescription);
            
        }
        
        /// <summary>
        /// Register an agent on AMS
        /// </summary>
        /// <param name="agentId">The unique Agent's AID</param>
        /// <param name="ownership">Agent's ownership; Set to empty string if no parameter is passed.</param>
        /// <param name="agentState">Agent's current state. Set to NONE if no parameter is passed.</param>
        /// <returns>True if registered, False otherwise</returns>
        public bool RegisterOnAMS(AID agentId, string ownership = "", AgentState agentState = AgentState.None)
        {
            AMSAgentDescription agentDescription = new AMSAgentDescription(agentId, ownership, agentState);
            
            return this._ams.Register(agentDescription);
        }

        public bool registerOnDF(AID agentId, ServiceDescription[] srviceDsc = null, string[] prtocol = null,
            string[] ontlogy = null, string[] lnguage = null)
        {

            DFAgentDescription agentDescription = new DFAgentDescription(agentId, srviceDsc, prtocol, ontlogy, lnguage);

            return this._df.Register(agentDescription);
        }
        
    }
}
