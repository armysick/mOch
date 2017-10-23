using System;
using System.Collections.Generic;
using m0ch.Utils;

namespace m0ch.FIPA
{


    /*
     * 
     * TODO: Add other attributes for registration.
     *       Allow modification
     *       Allow search for different attributes
     *       http://www.fipa.org/specs/fipa00023/SC00023K.html#_Toc75951013
     * 
     * 
     * 
     * */
    public class DF
    {
        // Represents the unique directory facilitator's AID
        private AID dfAID;

        // Variable where all known agents are registerd by DF
        private Dictionary<string, AID> yellowPages;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.DF"/> class
        /// </summary>
        /// <param name="hap_name">Hap name</param>
        /// <param name="address">Address</param>
        public DF(string hap_name, string address)
        {
            dfAID = new AID("df" + hap_name, address);
            yellowPages = new Dictionary<string, AID>();
        }


        /// <summary>
        /// Register the specified agentID on yellow pages
        /// </summary>
        /// <returns>void</returns>
        /// <param name="agentID">Agent identifier</param>
        public void register(AID agentID)
        {
            if (!yellowPages.ContainsValue(agentID))
                yellowPages.Add(agentID.getName(), agentID);
            else
                throw new DirectoryFacilitatorException("AgentID already exists");
        }

        /// <summary>
        /// Deregisters a specified agent from yellow pages.
        /// </summary>
        /// <returns>void</returns>
        /// <param name="agentID">Agent unique identifier</param>
        public void deregister(AID agentID)
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
        public void modify(string newName, AID AIDtoChange)
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
        public AID search(string name)
        {
            if (yellowPages.ContainsKey(name))
                return yellowPages[name];
            else
                throw new DirectoryFacilitatorException("Agent with name "
                                                       + name + " does not exist");
        }

    }
}
