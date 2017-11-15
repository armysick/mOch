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
            logger.Debug("Initializing Agent Management System.");
            // Read, parse, store the config file
            string configFilesURL = Misc.GetConfigFilesUrl();

            AgentConfig ag = new AgentConfig(configFilesURL);
            ag.InitParse();

            AgentPlatformConfig agp = new AgentPlatformConfig(configFilesURL);
            agp.InitParse();

            Agents.MainCluster mainCluster= new Agents.MainCluster(agp);
            
            logger.Error("wqeq");
            Console.ReadLine();
        }
    }
}
