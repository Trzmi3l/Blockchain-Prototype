using BlockchainPrototype.Networking.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Networking.p2p
{
    public class Peer2Peer
    {
        public Peer2Peer()
        {
            Task.Run(() => RecieveMessages());
        }

        public struct UdpState
        {
            public UdpClient u;
            public IPEndPoint e;
        }

        public static bool mesageRevieved = false;

        public static void RecieveCallback(IAsyncResult ar)
        {
            UdpClient u = ((UdpState)(ar.AsyncState)).u;
            IPEndPoint e = ((UdpState)(ar.AsyncState)).e;

            byte[] recieveBytes = u.EndReceive(ar, ref e);
            string recieveString = Encoding.ASCII.GetString(recieveBytes);
            
            // recognise packet

            mesageRevieved = true;
        }

        static void RecieveMessages()
        {
            IPEndPoint e = new IPEndPoint(IPAddress.Any, 5001);
            UdpClient u = new UdpClient(e);

            UdpState s = new UdpState();
            s.e = e;
            s.u = u;

            u.BeginReceive(new AsyncCallback(RecieveCallback), s);
        }


       
    }
}
