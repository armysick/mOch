using System;
using System.Reflection;
namespace m0ch.FIPA
{
    // All possible states for an agent that exists on platform
    public enum AgentState { NONE, INITIATED, ACTIVE, SUSPENDED, WAITING, TRANSIT }

    public abstract class Description
    {
        protected object Name;

    }

    /// <summary>
    /// Class representing a unique identifier for agents present in platform
    /// </summary>
    public class AID : Description
    {
        private string _address;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.AID"/> class.
        /// </summary>
        /// <param name="name">Agent's name</param>
        /// <param name="address">Agent's address</param>
        public AID(string name, string address)
        {
            this.Name = name;
            this._address = address;
        }

        /// <summary>
        /// Returns the name of the agent
        /// </summary>
        /// <returns>The name.</returns>
        public string GetName()
        {
            return (string)this.Name;
        }

        /// <summary>s
        /// Returns the agent's address
        /// </summary>
        /// <returns>The address.</returns>
        public string GetAddress()
        {
            return this._address;
        }

        /// <summary>
        /// Sets the name
        /// </summary>
        /// <param name="name">Agent's name</param>
        public void SetName(string name)
        {
            this.Name = name;
        }

    }

    /// <summary>
    /// AP transport description
    /// TODO: Yet to be done.
    /// </summary>
    public class APtransportDescription : Description
    { }

    /// <summary>
    /// Represents the agent description to either AMS and DF
    /// </summary>
    public class AMSAgentDescription : Description
    {
        private string _ownership;
        private AgentState _agentState;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.AgentDescription"/> class
        /// </summary>
        /// <param name="agentAID">Agent's aid</param>
        /// <param name="ownership">Agent's Ownership</param>
        /// <param name="agentState">Agent' state</param>
        public AMSAgentDescription(AID agentAID = null, string ownership = null,
                                AgentState agentState = AgentState.NONE)
        {
            this.Name = agentAID;
            this._ownership = ownership;
            this._agentState = agentState;
        }

        /// <summary>
        /// Gets the agent aid
        /// </summary>
        /// <returns>The agent aid</returns>
        public AID GetAgentAID()
        {
            return (AID)this.Name;
        }

        /// <summary>
        /// Gets the ownership
        /// </summary>
        /// <returns>The ownership</returns>
        public string GetOwnership()
        {
            return this._ownership;
        }

        /// <summary>
        /// Gets the state of the agent
        /// </summary>
        /// <returns>The agent state</returns>
        public AgentState GetAgentState()
        {
            return this._agentState;
        }
    }

    /// <summary>
    /// This type of object represents the description that can be registered 
    /// with the DF yellow-page service.
    /// </summary>
    public class DFAgentDescription : Description
    {

        private ServiceDescription[] _services;
        private String[] _protocol;
        private String[] _ontology;
        private String[] _language;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.DFAgentDescription"/> class.
        /// </summary>
        /// <param name="agentAID">Agent's aid.</param>
        /// <param name="services">A ServiceDescription Service.</param>
        /// <param name="protocol">An array of strings representing Protocol.</param>
        /// <param name="ontology">An array of strings representing Ontology.</param>
        /// <param name="language">An array of strings representing Language.</param>
        public DFAgentDescription(AID agentAID = null, 
                                  ServiceDescription[] services = null,
                                  String[] protocol = null,
                                  String[] ontology = null, 
                                  String[] language = null)
        {
            this.Name = agentAID;
            this._services = services;
            this._protocol = protocol;
            this._ontology = ontology;
            this._language = language;
        }


        /// <summary>
        /// Method used to retrieve the private member services.
        /// </summary>
        /// <returns>The services.</returns>
        public ServiceDescription[] GetServices()
        {
            return this._services;
        }

        /// <summary>
        /// Method to retrieve the existent Protocols.
        /// </summary>
        /// <returns>The protocols.</returns>
        public String[] GetProtocols()
        {
            return this._protocol;
        }

        /// <summary>
        /// Method to retrieve the existent Ontologies.
        /// </summary>
        /// <returns>The ontology.</returns>
        public String[] GetOntology()
        {
            return this._ontology;
        }

        /// <summary>
        /// Method to retrieve the known Languages.
        /// </summary>
        /// <returns>The language.</returns>
        public String[] GetLanguage()
        {
            return this._language;
        }

        /// <summary>
        /// Method that retrieves Agent's AID.
        /// </summary>
        /// <returns>Agent's AID</returns>
        public AID GetAgentAID()
        {
            return (AID)this.Name;
        }

    }

    /// <summary>
    /// This type of object represents the description of each service 
    /// registered with the DF.
    /// </summary>
    public class ServiceDescription : Description
    {
        private String _type;
        private String[] _protocol;
        private String[] _ontology;
        private String[] _language;
        private String _ownership;
        private Property[] _properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.ServiceDescription"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="protocol">An array of strings representing Protocol.</param>
        /// <param name="ontology">An array of strings representing Ontology.</param>
        /// <param name="language">An array of strings representing Language.</param>
        /// <param name="ownership">A String representing Ownership.</param>
        /// <param name="properties">An array of Property representing Properties.</param>
        public ServiceDescription(String name = null, String[] protocol = null,
                                  String[] ontology = null,
                                  String[] language = null,
                                  String ownership = null, 
                                  Property[] properties = null)
        {
            this.Name = name;
            this._protocol = protocol;
            this._ontology = ontology;
            this._language = language;
            this._ownership = ownership;
            this._properties = properties;
        }

        /// <summary>
        /// Method to retrieve the existent Protocols.
        /// </summary>
        /// <returns>The protocols.</returns>
        public String[] GetProtocols()
        {
            return this._protocol;
        }

        /// <summary>
        /// Method to retrieve the existent Ontologies.
        /// </summary>
        /// <returns>The ontology.</returns>
        public String[] GetOntology()
        {
            return this._ontology;
        }

        /// <summary>
        /// Method to retrieve the known Languages.
        /// </summary>
        /// <returns>The language.</returns>
        public String[] GetLanguage()
        {
            return this._language;
        }

        /// <summary>
        /// Method to retrieve the agent's ownership.
        /// </summary>
        /// <returns>The ownership.</returns>
        public String GetOwnership()
        {
            return this._ownership;
        }

        /// <summary>
        /// Method to retrieve the agent's properties.
        /// </summary>
        /// <returns>The properties.</returns>
        public Property[] GetProperties()
        {
            return this._properties;
        }
    }

    /// <summary>
    /// Class representig the agent platform description
    /// </summary>
    public class AgentPlatformDescription : Description
    {
        private Boolean? _dynamicR;
        private Boolean? _mobility;
        private APtransportDescription _transportProfile;

        public AgentPlatformDescription(string name, Boolean? dynamicP = null,
                                        Boolean? mobility = null,
                                        APtransportDescription APtrdescr = null)
        {
            this.Name = name;
            this._dynamicR = dynamicP;
            this._mobility = mobility;
            this._transportProfile = APtrdescr;
        }

        /// <summary>
        /// Gets the dynamic parameter
        /// </summary>
        /// <returns>Dynamic parameter</returns>
        public Boolean? GetDynamic()
        {
            return this._dynamicR;
        }

        /// <summary>
        /// Gets the mobility parameter
        /// </summary>
        /// <returns>Mobility parameter</returns>
        public Boolean? GetMobility()
        {
            return this._mobility;
        }


        /// <summary>
        /// Gets the AP transport description parameter.
        /// </summary>
        /// <returns>transport-profile</returns>
        public APtransportDescription GetAPtransportDescription()
        {
            return this._transportProfile;
        }
    }



}
