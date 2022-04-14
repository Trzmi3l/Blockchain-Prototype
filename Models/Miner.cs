using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Models
{
    public class Miner
    {
        public Address Address { get; set; }
        public string WorkerName { get; set; }
        public bool isMining { get; set; }
        public decimal MiningSpeed { get; set; }
    }
}
