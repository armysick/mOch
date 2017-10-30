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
                yellowPages.Add(agentDescription, agentDescription);
            else
                throw new DirectoryFacilitatorException("AgentID already exists");
        }

        /// <summary>
        /// Deregisters a specified agent from yellow pages.
        /// </summary>
        /// <returns>void</returns>
        /// <param name="agentID">Agent unique identifier</param>
        public void Deregister(AID agentID)
        {
            if (yellowPages.ContainsValue(agentID))
                yellowPages.Remove(agentID.getName());
            else
                throw new DirectoryFacilitatorException("AgentID does not exist");

        }

        /// <summary>
        /// Modify an agent's name with the specified AID to the new name
        /// </summary>
        /// <returns>void</returns>
        /// <param name="newName">New agent's name</param>
        /// <param name="AIDtoChange">Agent's AID</param>
        public void Modify(string newName, AID AIDtoChange)
        {
            if (yellowPages.ContainsKey(AIDtoChange.getName()))
            {
                
                yellowPages.Remove(AIDtoChange.getName());
                AIDtoChange.setName(newName);

                yellowPages.Add(newName, AIDtoChange);
            }
            else
                throw new DirectoryFacilitatorException("AgentID does not exist");
                
        }

        /// <summary>
        /// Search for an agent with a specific name
        /// </summary>
        /// <returns>Agent's AID</returns>
        /// <param name="name">Agent's name</param>
        public AID Search(string name)
        {
            if (yellowPages.ContainsKey(name))
                return yellowPages[name];
            else
                throw new DirectoryFacilitatorException("Agent with name "
                                                       + name + " does not exist");
        }

    }
}
