using System;
namespace m0ch.FIPA
{
    // All possible states for an agent that exists on platform
    public enum AgentState { NONE, INITIATED, ACTIVE, SUSPENDED, WAITING, TRANSIT }

    public abstract class Description
    {
        protected object name;

    }

    /// <summary>
    /// Class representing a unique identifier for agents present in platform
    /// </summary>
    public class AID : Description
    {
        private string address;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.AID"/> class.
        /// </summary>
        /// <param name="name">Agent's name</param>
        /// <param name="address">Agent's address</param>
        public AID(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        /// <summary>
        /// Returns the name of the agent
        /// </summary>
        /// <returns>The name.</returns>
        public string getName()
        {
            return (string)this.name;
        }

        /// <summary>s
        /// Returns the agent's address
        /// </summary>
        /// <returns>The address.</returns>
        public string getAddress()
        {
            return this.address;
        }

        /// <summary>
        /// Sets the name
        /// </summary>
        /// <param name="name">Agent's name</param>
        public void setName(string name)
        {
            this.name = name;
        }

    }

    /// <summary>
    /// AP transport description
    /// TODO: Yet to be done.
    /// </summary>
    public class APtransportDescription : Description
    {}

    /// <summary>
    /// Represents the agent description to either AMS and DF
    /// </summary>
    public class AMSAgentDescription : Description
    {
        private string ownership;
        private AgentState agentState;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.AgentDescription"/> class
        /// </summary>
        /// <param name="agentAID">Agent's aid</param>
        /// <param name="ownership">Agent's Ownership</param>
        /// <param name="agentState">Agent' state</param>
        public AMSAgentDescription(AID agentAID = null, string ownership = null,
                                AgentState agentState = AgentState.NONE)
        {
            this.name = agentAID;
            this.ownership = ownership;
            this.agentState = agentState;
        }

        /// <summary>
        /// Gets the agent aid
        /// </summary>
        /// <returns>The agent aid</returns>
        public AID getAgentAID()
        {
            return (AID)this.name;
        }

        /// <summary>
        /// Gets the ownership
        /// </summary>
        /// <returns>The ownership</returns>
        public string getOwnership()
        {
            return this.ownership;
        }

        /// <summary>
        /// Gets the state of the agent
        /// </summary>
        /// <returns>The agent state</returns>
        public AgentState getAgentState()
        {
            return this.agentState;
        }
    }


    /// <summary>
    /// Class representig the agent platform description
    /// </summary>
    public class AgentPlatformDescription : Description
    {
        private Boolean? dynamicR;
        private Boolean? mobility;
        private APtransportDescription transportProfile;

        public AgentPlatformDescription(string name, Boolean? dynamicP = null,
                                        Boolean? mobility = null, 
                                        APtransportDescription APtrdescr = null)
        {
            this.name = name;
            this.dynamicR = dynamicP;
            this.mobility = mobility;
            this.transportProfile = APtrdescr;
        }

        /// <summary>
        /// Gets the dynamic parameter
        /// </summary>
        /// <returns>Dynamic parameter</returns>
        public Boolean? getDynamic()
        {
            return this.dynamicR;
        }

        /// <summary>
        /// Gets the mobility parameter
        /// </summary>
        /// <returns>Mobility parameter</returns>
        public Boolean? getMobility()
        {
            return this.mobility;
        }


        /// <summary>
        /// Gets the AP transport description parameter.
        /// </summary>
        /// <returns>transport-profile</returns>
        public APtransportDescription getAPtransportDescription()
        {
            return this.transportProfile;
        }
    }



}
