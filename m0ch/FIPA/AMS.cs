using System;
using System.Collections.Generic;
using System.Linq;
namespace m0ch.FIPA
{

    /// <summary>
    /// Class responsible for managing known addresses in the multi-agent system.
    /// Agent Management System
    /// </summary>
    public class AMS
    {
        private Dictionary<AID, AMSAgentDescription> _activeAgents;
        private AgentPlatformDescription _apDescription;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.AMS"/> class.
        /// </summary>
        public AMS(AgentPlatformDescription apDescription)
        {
            _activeAgents = new Dictionary<AID, AMSAgentDescription>();
            this._apDescription = apDescription;
        }


        /// <summary>
        /// Register an Agent as active on the platform
        /// For now, it will accept and register. In the future, In case of an 
        /// already registered agent having the same name, it will return an error.
        /// </summary>
        /// <returns>True if added, False otherwise</returns>
        /// <param name="agent">AMS Agent description</param>
        public bool Register(AMSAgentDescription agent)
        {

            if (_activeAgents.ContainsKey(agent.GetAgentAID()))
                return false;

            _activeAgents.Add(agent.GetAgentAID(), agent);
            return true;
        }

        /// <summary>
        /// Deregister an active agent on the platform.
        /// For now, it will not return an error in case of the specified agent
        /// is already innactive.
        /// </summary>
        /// <returns></returns>
        /// <param name="agent">Agent AID</param>
        public void Deregister(AMSAgentDescription agent)
        {
            if (_activeAgents.ContainsKey(agent.GetAgentAID()))
                _activeAgents.Remove(agent.GetAgentAID());
        }

        /// <summary>
        /// Modify the specified agent description with a newly passed
        /// </summary>
        /// <returns></returns>
        /// <param name="agent">Agent's AID</param>
        /// <param name="newDscrAgent">New agent description</param>
        public void Modify(AID agent, AMSAgentDescription newDscrAgent)
        {
            if (_activeAgents.ContainsKey(agent))
                _activeAgents[agent] = newDscrAgent;
        }

        /// <summary>
        /// Search for a specific agent in AMS.
        /// </summary>
        /// <param name="agentTmpl">An agent description template</param>
        /// <param name="cstrnts">Search constraints</param>
        /// <returns>Array of results or null</returns>
        public AMSAgentDescription[] Search(AMSAgentDescription agentTmpl, SearchConstraints cstrnts)
        {

            List<AMSAgentDescription> similarAgents = new List<AMSAgentDescription>();

            // TODO: Make use of search constraints

            foreach(AMSAgentDescription existingAgent in _activeAgents.Values)
            {
                if (existingAgent.GetAgentAID() == agentTmpl.GetAgentAID())
                {
                    similarAgents.Add(existingAgent);
                }
            }

            // TODO: Make use of services and other parameters

            return similarAgents.ToArray();
        }

        /// <summary>
        /// Returns the Agent Platform Description
        /// </summary>
        /// <returns>AgentPlatformDescription object</returns>
        public AgentPlatformDescription GetDescription()
        {
            return this._apDescription;
        }


    }
}
