﻿using System.Collections.Generic;
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
        /// Search for DFAgentDescription(s) that match the template passed as argument.
        /// </summary>
        /// <returns>The search.</returns>
        /// <param name="agentTemplate">DFAgentDescription template</param>
        /// <param name="constraints">Search constraints.</param>
        public DFAgentDescription[] Search(DFAgentDescription agentTemplate,
                                          SearchConstraints constraints)
        {
            // TODO: Make use of constraints
            List<DFAgentDescription> allMatchedAgent = new List<DFAgentDescription>();

            foreach(DFAgentDescription existingAgent in this.yellowPages.Values)
            {

                // Check if agent has the same ID
                if (agentTemplate.GetAgentAID() == existingAgent.GetAgentAID())
                {
                    allMatchedAgent.Add(existingAgent);
                    continue;
                }

                // Check if servive is available on one of the agents
                foreach(ServiceDescription srv in agentTemplate.getServices())
                {
                    foreach(ServiceDescription srvYellowPage in existingAgent.getServices())
                    {
                        if (srv == srvYellowPage)
                        {
                            allMatchedAgent.Add(existingAgent);
                            continue;
                        }

                    }
                }
            }

            return allMatchedAgent.ToArray();
        }

    }
}