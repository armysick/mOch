using System;
using m0ch.Utils;
using Xunit;
using Xunit.Sdk;

namespace m0chTests.Utils
{
    public class Compression
    {

        private static string SmallString = "A small phase just to try compression";

        [Fact]
        public void COMPRESSION_NULL_STRING()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                m0ch.Utils.Compression.DataCompression(null, Misc.CompressionAlgorithm.Gzip);
            });
        }
        
        [Fact]
        public void DECOMPRESSION_NULL_STRING()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                m0ch.Utils.Compression.DecompressData(null, Misc.CompressionAlgorithm.Gzip);
            });
        }

        [Fact]
        public void GZIP_COMPRESSION_AND_DECOMPRESSION()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.Gzip);

            var decompressedData =
                m0ch.Utils.Compression.DecompressData(compressedData, Misc.CompressionAlgorithm.Gzip);

            Assert.Equal(decompressedData, SmallString);
        }
        
        [Fact]
        public void GZIP_COMPRESSION_SIZE()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.Gzip);


            Assert.True(compressedData.ToString().Length < SmallString.Length);
        }
        
        [Fact]
        public void DEFLATE_COMPRESSION_AND_DECOMPRESSION()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.Deflate);

            var decompressedData =
                m0ch.Utils.Compression.DecompressData(compressedData, Misc.CompressionAlgorithm.Deflate);

            Assert.Equal(decompressedData, SmallString);
        }
        
        [Fact]
        public void DEFLATE_COMPRESSION_SIZE()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.Deflate);


            Assert.True(compressedData.ToString().Length < SmallString.Length);
        }
        
        [Fact]
        public void L4Z_COMPRESSION_AND_DECOMPRESSION()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.L4Z);

            var decompressedData =
                m0ch.Utils.Compression.DecompressData(compressedData, Misc.CompressionAlgorithm.L4Z);

            Assert.Equal(decompressedData, SmallString);
        }
        
        [Fact]
        public void L4Z_COMPRESSION_SIZE()
        {
            var compressedData = m0ch.Utils.Compression.DataCompression(SmallString, Misc.CompressionAlgorithm.L4Z);


            Assert.True(compressedData.ToString().Length < SmallString.Length);
        }
    }
}