using System;

namespace BlockchainPrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // run embed web server
            new Networking.EmbedServer(new Networking.EmbedServerConfig());


            
        }
    }
}
