
namespace m0ch.Agents
{
    
    /// <summary>
    /// Class that represent every agent except for the cluster
    /// </summary>
    abstract class AbstractAgent
    {
        
        /// <summary>
        /// Variable that holds everything that happens in the network
        /// </summary>
        protected Network.Networking NetworkAcess;


        /// <summary>
        /// Method that returns Network variable
        /// </summary>
        /// <returns></returns>
        protected Network.Networking GetNetworking()
        {
            return this.NetworkAcess;
        }

    }
}
