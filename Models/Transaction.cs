using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Models
{
    public class Transaction
    {
        public Address From { get; set; }
        public Address To { get; set; }
        
        public decimal value;

       public bool verify()
        {
            if (From.balance >= value) return true;
            return false;
        }

    }
}
