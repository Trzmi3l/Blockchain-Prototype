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
        public Share ResolveHash { get; set; }
        public List<Share> Shares { get; set; }
        public List<string> HashSet { get; set; }
        public decimal BlockReward { get; set; }

        
        


    }
    public static class BlockExtensions
    {
        public static void PutTransaction(this Transaction _tx, List<Transaction> _list)
        {
            _list.Add(_tx);
        }
        public static void PutShare(this Share _sh, List<Share> _list)
        {
            _list.Add(_sh);
        }
    }


}
