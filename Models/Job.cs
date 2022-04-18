using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPrototype.Models
{
    [Serializable]
    public class Job
    {
        public string Id { get; set; }
        public long blockHeight { get; set; }
    }
}
