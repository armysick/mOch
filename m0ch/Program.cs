using System;
using m0ch.Utils;
using NLog;

namespace m0ch
{
    class MainClass
    {

        /// <summary>
        /// Variable responsible for logging.
        /// </summary>
        protected static readonly Logger LoggerObj = LogManager.GetCurrentClassLogger();
        
        public static void Main(string[] args)
        {
            LoggerObj.Trace("Initializing Agent Management System.");
            LoggerObj.Trace("Beginning to read configuration files.");
            
            // Read, parse, store the config file
            string configFilesURL = Misc.GetConfigFilesUrl();

            AgentConfig ag = new AgentConfig(configFilesURL);
            ag.InitParse();

            AgentPlatformConfig agp = new AgentPlatformConfig(configFilesURL);
            agp.InitParse();
            
            LoggerObj.Trace("Starting main cluster.");
            Agents.MainCluster mainCluster= new Agents.MainCluster(agp);
            
            Console.ReadLine();
        }
    }
}
