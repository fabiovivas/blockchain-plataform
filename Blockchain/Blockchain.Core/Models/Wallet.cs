using Blockchain.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Wallet
    {
        public Miner Node { get; set; }
        public List<string> WalletsAddress { get; set; }
        private decimal fee;

        public Wallet(Miner Node = null, string addressName = null)
        {
            WalletsAddress = new List<string>();
            fee = 1;
            if (Node != null)
                this.Node = Node;
            else
                Node = new Miner();

            if (!string.IsNullOrEmpty(addressName))
                this.AddWalletAddress(addressName);
        }

        public string AddWalletAddress(string addressName)
        {
            var newAddress = addressName.GenerateSHA256String();

            if (WalletsAddress.IndexOf(newAddress) > -1)
                return "Wallet used by other user";
            else
                WalletsAddress.Add(newAddress);

            return newAddress;
        }

        public decimal Balance(string address)
        {
            decimal addressValue = Node.UtxoSet
                                        .Where(x => x.Address == address)
                                        .Sum(x => x.Value);
            return addressValue;
        }

        public void TransferValue(string addressFrom, decimal value, string addressTo)
        {
            var balance = Balance(addressFrom);
            var changeValue = balance - value - fee;

            if (changeValue >= 0)
            {
                var inputs = MakeInputsFromAddress(addressFrom);
                var output = new Output(value, addressTo);
                var changeOutupt = new Output(changeValue, addressFrom);
                var transaction = new Transaction(inputs, new List<Output> { output, changeOutupt });

                Node.Bitcoin.TransactionPool.Add(transaction);
            }
        }

        private List<Input> MakeInputsFromAddress(string addressFrom)
        {
            var inputs = new List<Input>();
            var outputs = Node.UtxoSet
                                .Where(x => x.Address == addressFrom)
                                .ToList();


            foreach (var item in outputs)
            {
                var transactions = Node.Bitcoin.Chain
                                        .SelectMany(x => x.TransactionList)
                                        .Where(x => x.OutputList.Any(y => y.Address == item.Address && y.Value == item.Value))
                                        .Distinct()
                                        .ToList();

                foreach (var transaction in transactions)
                {

                    var vOut = transaction.OutputList.FindIndex(x => x.Address == item.Address && x.Value == item.Value);
                    var input = new Input(transaction.TxId, vOut);
                    if (!inputs.Exists(x => x.TxId == input.TxId))
                        inputs.Add(input);
                }
                //break;
            }
            return inputs;
        }
    }
}
