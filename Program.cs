using BlockchainPrototype.Database;
using BlockchainPrototype.Networking.p2p;
using System;
using System.Threading.Tasks;

namespace BlockchainPrototype
{
    internal class Program
    {
        static Networking.EmbedServer webapiServer;
        static Peer2Peer P2PServer;
        static DbManager DbManager;
        static void Main(string[] args)
        {
            // run embed webapi server
            Task.Run(() => initEmbedServer());

            // run p2p server
            Task.Run(() => initP2PServer());

            // run database
            initDb();
            DbManager.GetBlock(0);
            Console.ReadKey();
        }

        static void initDb()
        {
            DbManager = new DbManager();
        }
        static void initP2PServer()
        {
            P2PServer = new Peer2Peer(new Peer2PeerConfig());
        }
        static void initEmbedServer()
        {
            webapiServer = new Networking.EmbedServer(new Networking.EmbedServerConfig());
        }

    }
}
