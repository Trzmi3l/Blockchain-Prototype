using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EllipticCurve;

namespace BlockchainPrototype.Models
{
    public class Address
    {

        public string Hash { get; set; }
        public PrivateKey PrivateKey { get; set; }
        public PublicKey PublicKey { get; set; }
        public decimal balance { get; set; }
        public List<Transaction> transactions { get; set; }

    }
}
