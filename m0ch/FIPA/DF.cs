using System;
using System.Collections.Generic;
using m0ch.Utils;

namespace m0ch.FIPA
{
    public class DF
    {
        // Variable where all known agents are registerd by DF
        private Dictionary<AID, DFAgentDescription> yellowPages;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.DF"/> class.
        /// </summary>
        public DF()
        {
            yellowPages = new Dictionary<AID, DFAgentDescription>();
        }

        /// <summary>
        /// Register the specified agent on yellow pages.
        /// </summary>
        /// <returns></returns>
        /// <param name="agentDescription">Agent description object.</param>
        public void Register(DFAgentDescription agentDescription)
        {
            if (!yellowPages.ContainsValue(agentDescription))
                yellowPages.Add(agentDescription.GetAgentAID(), agentDescription);
            else
                throw new DirectoryFacilitatorException("AgentID already exists");
        }

        /// <summary>
        /// Deregisters a specified agent from yellow pages.
        /// </summary>
        /// <returns></returns>
        /// <param name="agentDescription">Agent DFAgentDescription.</param>
        public void Deregister(DFAgentDescription agentDescription)
        {
            if (yellowPages.ContainsValue(agentDescription))
                yellowPages.Remove(agentDescription.GetAgentAID());
            else
                throw new DirectoryFacilitatorException("AgentID does not exist");

        }

        /// <summary>
        /// Modify an agent's description.
        /// </summary>
        /// <returns></returns>
        /// <param name="oldDescription">Old DFAgentDescription</param>
        /// <param name="newDescription">New DFAgentDescription.</param>
        public void Modify(DFAgentDescription oldDescription,
                           DFAgentDescription newDescription)
        {
            if (yellowPages.ContainsKey(oldDescription.GetAgentAID()))
            {
                
                yellowPages.Remove(oldDescription.GetAgentAID());
                yellowPages.Add(newDescription.GetAgentAID(), newDescription);
            }
            else
                throw new DirectoryFacilitatorException("AgentID does not exist");
                
        }

        /// <summary>
        /// Search for an agent with a specific name
        /// </summary>
        /// <returns>Agent's AID</returns>
        /// <param name="name">Agent's name</param>
        public DFAgentDescription[] Search(DFAgentDescription agentTemplate,
                                          SearchConstrains constrains)
        {

            DFAgentDescription[] allMatchedAgent = new DFAgentDescription[2];


        }

    }
}
