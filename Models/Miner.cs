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
        public decimal Balance { get; set; }
        public Block FocusedBlock { get; set; } 
        public List<Share> Shares { get; set; }
        public List<Block> BlocksMined { get; set; }
    }
}
