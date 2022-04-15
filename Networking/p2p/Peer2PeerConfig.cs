using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Networking.p2p
{
    public class Peer2PeerConfig
    {
        public IPAddress Ip { get; set; }
        public int Port { get; set; }

    }
}
