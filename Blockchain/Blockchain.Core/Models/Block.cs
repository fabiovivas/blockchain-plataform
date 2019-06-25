using Blockchain.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Block
    {
        public int Index { get; }
        public string PreviousHash { get; }
        public string Hash { get; set; }
        public List<Transaction> TransactionList { get; }
        public int Nonce { get; set; }

        public Block(int Index, string PreviousHash, List<Transaction> TransactionList)
        {
            this.Index = Index;
            this.PreviousHash = PreviousHash;
            this.TransactionList = TransactionList;
        }

        public Block CreateGenesisBlock()
        {
            var newBlock = new Block(0, "0000000000", null);
            return newBlock;
        }

        public Block CreateBlock(int Index, string PreviousHash, List<Transaction> TransactionList)
        {
            return new Block(Index, PreviousHash, TransactionList);
        }

        public string GenerateHashBlock(int Nonce)
        {
            this.Nonce = Nonce;
            var stringConcat = Serialization.GenerateUniqueString(
                new List<object>() { Index, PreviousHash, TransactionList, Nonce });

            return stringConcat.GenerateSHA256String();
        }
    }
}
