using System;
using m0ch;
using NUnit.Framework;

namespace m0chTests
{
    [TestFixture()]
    public class Compression
    {
        [Test()]
        public void Test_GZIP_Compression()
        {

            m0ch.Utils.GZIP test = new m0ch.Utils.GZIP("Test");

            byte[] compressedData = test.CompressData();
            
            Assert.AreNotEqual(compressedData, null);
        }
        
        [Test()]
        public void Test_GZIP_Compression_Decompression()
        {

            m0ch.Utils.GZIP test = new m0ch.Utils.GZIP("Test");

            byte[] compressedData = test.CompressData();
            
            Assert.AreEqual("Test", test.DecompressData(compressedData));
        }
    }
}
