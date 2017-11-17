using System;
using m0ch.Utils;
using NUnit.Framework;

namespace m0chTests.Utils
{
    [TestFixture]
    public class Compression
    {
        private const string SmallString = "A small phase just to try compression";

        [Test]
        public void COMPRESSION_NULL_STRING()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                m0ch.Utils.Compression.DataCompression(null, Misc.CompressionAlgorithm.Gzip);
            });
        }
        
        [Test]
        public void DECOMPRESSION_NULL_STRING()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                m0ch.Utils.Compression.DecompressData(null, Misc.CompressionAlgorithm.Gzip);
            });
        }

        [Test]
        public void GZIP_COMPRESSION_AND_DECOMPRESSION()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.Gzip);

            var decompressedData =
                m0ch.Utils.Compression.DecompressData(compressedData, Misc.CompressionAlgorithm.Gzip);

            Assert.AreEqual(decompressedData, SmallString);
        }
        
        [Test]
        public void GZIP_COMPRESSION_SIZE()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.Gzip);


            Assert.True(compressedData.ToString().Length < SmallString.Length);
        }
        
        [Test]
        public void DEFLATE_COMPRESSION_AND_DECOMPRESSION()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.Deflate);

            var decompressedData =
                m0ch.Utils.Compression.DecompressData(compressedData, Misc.CompressionAlgorithm.Deflate);

            Assert.AreEqual(decompressedData, SmallString);
        }
        
        [Test]
        public void DEFLATE_COMPRESSION_SIZE()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.Deflate);


            Assert.True(compressedData.ToString().Length < SmallString.Length);
        }
        
        [Test]
        public void L4Z_COMPRESSION_AND_DECOMPRESSION()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.L4Z);

            var decompressedData =
                m0ch.Utils.Compression.DecompressData(compressedData, Misc.CompressionAlgorithm.L4Z);

            Assert.AreEqual(decompressedData, SmallString);
        }
        
        [Test]
        public void L4Z_COMPRESSION_SIZE()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.L4Z);


            Assert.True(compressedData.ToString().Length < SmallString.Length);
        }
    }
}