using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Exceptions
{
    public class BlockNotFoundException : Exception
    {

        public BlockNotFoundException()
        {

        }
        public void Print()
        {
            Console.WriteLine("There is no block that u want to find");
        }

    }
}
