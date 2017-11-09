using System;
using m0ch.Utils;
using NUnit.Framework;

namespace m0chTests
{
    [TestFixture()]
    public class Compression
    {
        [Test()]
        public void Test_GZIP_Compression()
        {

            GZIP test = new GZIP("Test");

            byte[] compressedData = test.CompressData();
            
            Assert.AreNotEqual(compressedData, null);
        }
        
        [Test()]
        public void Test_GZIP_Compression_Decompression()
        {

            GZIP test = new GZIP("Test");

            byte[] compressedData = test.CompressData();
            
            Assert.AreEqual("Test", test.DecompressData(compressedData));
        }
    }
}
