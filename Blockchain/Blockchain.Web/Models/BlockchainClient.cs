using Blockchain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockchain.Web.Models
{
    public class BlockchainClient
    {
        public Miner miner { get; set; }
        public Wallet wallet { get; set; }
    }
}
