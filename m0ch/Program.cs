using System;
using m0ch.Network;
using m0ch.Utils;

namespace m0ch
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Lz4 c = new Lz4("ASDAASASDASDASDASDASDASDASDASDASDASASDASDASDASS");


            Console.WriteLine(c.DecompressData(c.CompressData()));
            Console.ReadLine();
        }
    }
}
