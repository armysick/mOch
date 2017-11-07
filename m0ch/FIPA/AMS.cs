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
        private Dictionary<AID, AMSAgentDescription> activeAgents;
        private AgentPlatformDescription apDescription;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.AMS"/> class.
        /// </summary>
        public AMS(AgentPlatformDescription apDescription)
        {
            activeAgents = new Dictionary<AID, AMSAgentDescription>();
            this.apDescription = apDescription;
        }


        /// <summary>
        /// Register an Agent as active on the platform
        /// For now, it will accept and register. In the future, In case of an 
        /// already registered agent having the same name, it will return an error.
        /// </summary>
        /// <returns></returns>
        /// <param name="agent">AMS Agent description</param>
        public void Register(AMSAgentDescription agent)
        {
            if (!activeAgents.ContainsKey(agent.GetAgentAID()))
                activeAgents.Add(agent.GetAgentAID(), agent);
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
            if (activeAgents.ContainsKey(agent.GetAgentAID()))
                activeAgents.Remove(agent.GetAgentAID());
        }

        /// <summary>
        /// Modify the specified agent description with a newly passed
        /// </summary>
        /// <returns></returns>
        /// <param name="agent">Agent's AID</param>
        /// <param name="newDscrAgent">New agent description</param>
        public void Modify(AID agent, AMSAgentDescription newDscrAgent)
        {
            if (activeAgents.ContainsKey(agent))
                activeAgents[agent] = newDscrAgent;
        }

        /// <summary>
        /// Search for a specific agent in AMS.
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="agent">AMSAgentDescription if found or null otherwise</param>
        public AMSAgentDescription[] Search(AMSAgentDescription agentTmpl, SearchConstraints cstrnts)
        {

            List<AMSAgentDescription> similarAgents = new List<AMSAgentDescription>();

            // TODO: Make use of search constraints

            foreach(AMSAgentDescription existingAgent in activeAgents.Values)
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
        public AgentPlatformDescription getDescription()
        {
            return this.apDescription;
        }


    }
}
