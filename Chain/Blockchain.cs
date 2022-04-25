using BlockchainPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Chain
{
    class Blockchain
    {

        static List<Block> CHAIN = new List<Block>();


        public Blockchain()
        {






        }



        static void DumpChain()
        {
            
        }

        public static Block GetLastBlock()
        {
            return CHAIN.LastOrDefault();
        }
        public static List<Block> GetLast50Blocks()
        {
            return (List<Block>)CHAIN.Skip(Math.Max(0, CHAIN.Count - 50));
        }



    }
}
