using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Models
{
    public class Block
    {
        public string Hash { get; set; }
        public string PrevHash { get; set; }
        public int Height { get; set; }
        public int Difficulty { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Share> Shares { get; set; }
        public List<string> HashSet { get; set; }
        public decimal BlockReward { get; set; }

    }
}
