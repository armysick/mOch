using System;
using m0ch.Utils;
using NLog;

namespace m0ch
{
    class MainClass
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public static void Main(string[] args)
        {
            logger.Trace("Initializing Agent Management System.");
            logger.Trace("Beginning to read configuration files.");
            
            // Read, parse, store the config file
            string configFilesURL = Misc.GetConfigFilesUrl();

            AgentConfig ag = new AgentConfig(configFilesURL);
            ag.InitParse();

            AgentPlatformConfig agp = new AgentPlatformConfig(configFilesURL);
            agp.InitParse();
            
            logger.Trace("Starting main cluster.");
            Agents.MainCluster mainCluster= new Agents.MainCluster(agp);
            
            Console.ReadLine();
        }
    }
}
