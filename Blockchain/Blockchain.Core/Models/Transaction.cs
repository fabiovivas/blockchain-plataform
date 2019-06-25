using Blockchain.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Transaction
    {
        public string TxId { get; }
        public List<Input> InputList { get; }
        public List<Output> OutputList { get; set; }

        public Transaction(List<Input> InputList, List<Output> OutputList)
        {
            this.InputList = InputList;
            this.OutputList = OutputList;
            this.TxId = GenerateHashTransaction();
        }

        private string GenerateHashTransaction()
        {
            var stringConcat = Serialization.GenerateUniqueString(new List<object>() { InputList, OutputList }).ToString();
            return stringConcat.GenerateSHA256String();
        }
    }
}
