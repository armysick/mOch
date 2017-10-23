using System;
namespace m0ch.FIPA
{
    /// <summary>
    /// Class containing all Agent Management Services
    /// </summary>
    public class AMServices
    {

        // Object representing the agent management system
        private AMS ams;

        // Object representing the directory facilitator
        private DF df;


        public AMServices()
        {
            
        }
    }

    /// <summary>
    /// Class representing a unique identifier for agents present in platform
    /// </summary>
    public class AID
    {

        private string name;
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
            return this.name;
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
}
