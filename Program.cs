using BlockchainPrototype.Networking.p2p;
using System;
using System.Threading.Tasks;

namespace BlockchainPrototype
{
    internal class Program
    {
        static Networking.EmbedServer webapiServer;
        static void Main(string[] args)
        {
            // run embed webapi server
            Task.Run(() => initEmbedServer());

            // run p2p server
            Peer2Peer p2pServer = new Peer2Peer(new Peer2PeerConfig());
           
            

            Console.ReadKey();
        }

        static void initEmbedServer()
        {
            webapiServer = new Networking.EmbedServer(new Networking.EmbedServerConfig());
        }

    }
}
