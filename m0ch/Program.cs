using System;
using m0ch.Network;
using m0ch.Utils;

namespace m0ch
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //Networking ntwk = new Networking();
            GZIP g = new GZIP("Testing gzip algorithm ");
            g.DecompressData(g.CompressData());
            Console.WriteLine(g.getStatistics());
            
            Deflate t = new Deflate("Testing deflate algorithm ");
            t.DecompressData(t.CompressData());
            Console.WriteLine(t.getStatistics());

            Console.ReadLine();
        }
    }
}
