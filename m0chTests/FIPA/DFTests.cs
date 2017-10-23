using Microsoft.VisualStudio.TestTools.UnitTesting;
using m0ch.FIPA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m0ch.FIPA.Tests
{
    [TestClass()]
    public class DFTests
    {
        [TestMethod()]
        public void DFTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RegisterTest()
        {
            // Creating Directory Facilitator
            DF directoryF = new DF("for");

            // Creating an agent
            AID tryNewAgent = new AID("test", "purposes");

            // register agent on yellow pages
            directoryF.register(tryNewAgent);

            // Search for the agent
            AID searchedAgent = directoryF.search("test");

            Assert.Equals(tryNewAgent, searchedAgent);
        }

        [TestMethod()]
        public void deregisterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void modifyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void searchTest()
        {
            Assert.Fail();
        }
    }
}