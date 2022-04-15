using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Models
{
    public class Share
    {
        public string Hash { get; set; }
        public Miner Miner { get; set; }   
        public Block Parrent { get; set; }
        public decimal reward { get; set; }

        public decimal CalculateReward()
        {
            List<Share> shares = new List<Share>();
            foreach(Share share in Miner.Shares)
            {
                if (share.Hash == Hash) shares.Add(share);
            }
            int SharesCount = shares.Count;
            int totalShares = Parrent.Shares.Count;
            decimal BlockReward = Parrent.BlockReward;
            return BlockReward * (SharesCount/totalShares);
        }
    }
}
