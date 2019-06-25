using Blockchain.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Blockchain
    {
        public List<Transaction> TransactionPool { get; set; }
        public List<Block> Chain { get; }
        public int Difficulty { get; }

        public Blockchain()
        {
            Difficulty = 3;
            Chain = new List<Block>();
            TransactionPool = new List<Transaction>();
        }

        public Block returnLastBlock()
        {
            var chainLenght = Chain.Count() - 1;
            return Chain[chainLenght];
        }
    }
}
