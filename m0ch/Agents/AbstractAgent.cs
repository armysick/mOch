
namespace m0ch.Agents
{
    
    /// <summary>
    /// Class that represent every agent except for the cluster
    /// </summary>
    abstract class AbstractAgent
    {
        /// <summary>
        /// Variable that holds everything that happens in the network.
        /// </summary>
        protected Network.Networking NetworkAcess;

        
        /// <summary>
        /// Variable that holds the uniquess identifier of an agent.
        /// </summary>
        protected FIPA.AID AgentIdentificer;
        
        /// <summary>
        /// Method that returns Network variable
        /// </summary>
        /// <returns></returns>
        public Network.Networking GetNetworking()
        {
            return this.NetworkAcess;
        }

        /// <summary>
        /// Method that returns Agent's AID
        /// </summary>
        public FIPA.AID getAID()
        {
            return this.AgentIdentificer;
        }
    }
}
