using BlockchainPrototype.Chain;
using BlockchainPrototype.Models;
using BlockchainPrototype.Networking.enums;
using Newtonsoft.Json;
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
            Console.WriteLine(recieveString);
            // recognise packet

            if(recieveString.StartsWith("2c440fx0:"))
            {
                string temp = recieveString.Substring("2c440fx0:".Length + 1);
                Task.Run(() => SerializeAndSendResponseData(PacketType.BLOCK, Blockchain.GetLastBlock(), e));
            }
            


            mesageRevieved = true;
        }

        static void RecieveMessages()
        {
            IPEndPoint e = new IPEndPoint(IPAddress.Any, 5001);
            UdpClient u = new UdpClient(e);

            UdpState s = new UdpState();
            s.e = e;
            s.u = u;
            for (;;)
            {
                u.BeginReceive(new AsyncCallback(RecieveCallback), s);
            }
        }

        static void SerializeAndSendResponseData(PacketType type, Block block, IPEndPoint ep)
        {

            UdpClient client = new UdpClient();
            client.Connect(ep.Address.ToString(), 5001);

            switch (type)
            {
                case PacketType.BLOCK:

                    string temp = "2c440fx0:" + JsonConvert.SerializeObject(block);

                    byte[] tempBytes = Encoding.ASCII.GetBytes(temp);
                    client.Send(tempBytes, tempBytes.Length);
                    
                    break;
            }

        }

    }
}
