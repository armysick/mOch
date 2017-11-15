using System;
using m0ch.Network;
using m0ch.Utils;

namespace m0ch
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Read, parse, store the config file
            string configFilesURL = Misc.GetConfigFilesUrl();

            AgentConfig ag = new AgentConfig(configFilesURL);
            ag.InitParse();

            AgentPlatformConfig agp = new AgentPlatformConfig(configFilesURL);
            agp.InitParse();

            Agents.MainCluster mainCluster= new Agents.MainCluster(agp);

            Console.ReadLine();
        }
    }
}
