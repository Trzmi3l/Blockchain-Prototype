using BlockchainPrototype.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Networking.p2p
{
    public class DataSerializer
    {
        /// <summary>
        /// Serializes Job Packet
        /// </summary>
        /// <param name="_">Job object</param>
        /// <returns></returns>
        public static byte[] SerializeData(Job _)
        {
            if (_ == null) return null;

            string packet = JsonConvert.SerializeObject(_);
            Console.WriteLine(packet);
            return Encoding.UTF8.GetBytes(packet);

        }


    }
}
