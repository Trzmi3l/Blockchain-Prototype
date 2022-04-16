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
        static TcpClient server;
        static TcpListener listener;
        static NetworkStream stream;
        static bool recievePackets = true;

        public Peer2Peer(Peer2PeerConfig config)
        {
            Console.WriteLine("Initializing p2p");
            listener = new TcpListener(IPAddress.Parse(config.Ip), config.Port);
            StartListener();
            InitPeer2Peer();
            Task.Run(() => RecieveLoop());
        }

        static async Task InitPeer2Peer()
        {
           server = listener.AcceptTcpClient();
           stream = server.GetStream();
        
        }

        static async Task RecieveLoop()
        {
            Console.WriteLine("Recieving loop running");
            byte[] bytes = new byte[4096];
            string data;
            int i = 0;

            while(recievePackets)
            {
                i = stream.Read(bytes, 0, bytes.Length);
                while(i != 0)
                {
                    Console.WriteLine("Data recieved");
                    data = System.Text.Encoding.UTF8.GetString(bytes);
                    Console.WriteLine(data);
                    i = 0;
                }
            }
        }

        public void StopRecieving()
        {
            recievePackets = false;
        }
        public void StartRecieving()
        {
            recievePackets = true;
        }

        public async Task<Boolean> StartListener()
        {
            try
            {
                listener.Start();
                return true;
            } catch(Exception e)
            {
                return false;
            }
        }
        public async Task<Boolean> StopListener()
        {
            try
            {
                listener.Stop();
                return true;
            } catch(Exception e)
            {
                return false;
            }
        }
    }
}
