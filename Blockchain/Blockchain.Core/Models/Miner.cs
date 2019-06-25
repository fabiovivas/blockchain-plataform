using Blockchain.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Miner
    {
        public Blockchain Bitcoin { get; set; }
        public List<Utxo> UtxoSet { get; set; }

        public string AddressMiner { get; set; }
        public decimal rewardMiner { get; set; }
        public decimal rewardMinerCoinbase { get; set; }

        public Miner(bool createNewBlockchain = true)
        {
            AddressMiner = Criptografy.GenerateSHA256String("satoshi");
            rewardMiner = 50;

            if (createNewBlockchain)
            {
                Bitcoin = new Blockchain();
                UtxoSet = new List<Utxo>();
                MinerGenesisBlock();
            }
            else
            {
                //aqui deve constar código de sincronização com a rede
            }
        }

        //public Miner() : this(true) { }

        private void MinerGenesisBlock()
        {
            Bitcoin.Chain.Add(CreateGenesisBlock());
            CreateUtxo();
            Bitcoin.TransactionPool.Clear();
            rewardMinerCoinbase = 0;
        }

        private Block CreateGenesisBlock()
        {
            var genesisTransaction = CreateGenesisTransaction();
            var genesisBlock = new Block(0, "0000000000", new List<Transaction>() { genesisTransaction });
            genesisBlock.Hash = genesisBlock.GenerateHashBlock(0);
            return genesisBlock;
        }

        private Transaction CreateGenesisTransaction()
        {
            var inputCoinBase = new Input("0000000000", 0);
            var outputCoinBase = new Output(rewardMiner, AddressMiner);

            var transactionCoinBase = new Transaction(
                new List<Input>() { inputCoinBase },
                new List<Output>() { outputCoinBase });

            //Bitcoin.TransactionPool.Add(transactionCoinBase);
            rewardMinerCoinbase = rewardMiner;
            return transactionCoinBase;
        }

        public void MinerTransactions()
        {
            if (ValidateValueTransactions())
            {
                var coinBase = CreateCoinBase();

                var transactions = new List<Transaction>();
                transactions.Add(coinBase);
                transactions.AddRange(Bitcoin.TransactionPool);

                var previousBlock = Bitcoin.returnLastBlock();
                var newBlock = new Block(previousBlock.Index + 1, previousBlock.Hash, transactions);

                var nonce = 0;
                do
                {
                    newBlock.Hash = newBlock.GenerateHashBlock(nonce);
                    nonce++;
                } while (newBlock.Hash.Substring(0, Bitcoin.Difficulty) != new string('0', Bitcoin.Difficulty));

                ExcludeUtxo();
                CreateUtxo();
                Bitcoin.Chain.Add(newBlock);
                Bitcoin.TransactionPool.Clear();
            }
        }

        private void ExcludeUtxo()
        {
            var inputs = Bitcoin.TransactionPool
                            .SelectMany(x => x.InputList)
                            .Distinct();

            var utxoList = new List<Utxo>();
            foreach (var item in inputs)
                UtxoSet.RemoveAll(x => x.TxId == item.TxId && x.vOut == item.VOut);

            //var exclude = UtxoSet.FirstOrDefault(x => x.TxId == "0000000000" && x.Address == AddressMiner);

            UtxoSet.RemoveAll(x => x.TxId == "0000000000" && x.Address == AddressMiner);
        }

        private void CreateUtxo()
        {
            var utxoMiner = new Utxo("0000000000", 0, rewardMinerCoinbase, AddressMiner);
            UtxoSet.Add(utxoMiner);

            foreach (var transaction in Bitcoin.TransactionPool.Distinct())
            {
                foreach (var output in transaction.OutputList)
                {
                    var vOut = transaction.OutputList.IndexOf(output);
                    var utxo = new Utxo(transaction.TxId, vOut, output.Value, output.Address);
                    UtxoSet.Add(utxo);
                }
            }
            rewardMinerCoinbase = 0;
        }

        private Transaction CreateCoinBase()
        {
            rewardMinerCoinbase = CalculateRewardMiner();

            var inputCoinBase = new Input("0000000000", 0);
            var outputCoinBase = new Output(rewardMinerCoinbase, AddressMiner);

            var transactionCoinBase = new Transaction(
                 new List<Input>() { inputCoinBase },
                 new List<Output>() { outputCoinBase });
            return transactionCoinBase;
        }

        public bool ValidateTransactions()
        {
            if (ValidateDoubleSpend() && ValidateValueTransactions())
                return true;
            return false;
        }

        private bool ValidateDoubleSpend()
        {
            var inputs = Bitcoin.TransactionPool                                
                                .SelectMany(x => x.InputList)
                                .Distinct();

            foreach (var item in inputs)
            {
                var utxo = UtxoSet.Where(x => x.TxId == item.TxId && x.vOut == item.VOut);
                if (utxo != null && utxo.Count() > 1)
                    return false;
            }
            return true;
        }

        private bool ValidateValueTransactions()
        {
            var sumOutputs = ReturnSumOutputs();
            var sumInputs = ReturnSumInputs();

            if (sumOutputs > sumInputs)
                return false;

            return true;
        }

        private decimal ReturnSumInputs()
        {
            var inputs = Bitcoin.TransactionPool
                               .SelectMany(x => x.InputList)
                               .Distinct(); 

            decimal sumInputs = 0;

            foreach (var item in inputs)
            {
                var utxo = UtxoSet.FirstOrDefault(x => x.TxId == item.TxId && x.vOut == item.VOut);
                if (utxo != null)
                    sumInputs += utxo.Value;
            }
            sumInputs += UtxoSet.Where(x => x.Address == AddressMiner && x.TxId == "0000000000").Sum(x => x.Value);

            return sumInputs;
        }

        private decimal ReturnSumOutputs()
        {
            var sumOutputs = Bitcoin.TransactionPool
                               .SelectMany(x => x.OutputList)
                               .Distinct()
                               .Sum(x => x.Value);

            return sumOutputs;
        }

        private decimal CalculateFee()
        {
            var sumOutputs = ReturnSumOutputs();
            var sumInputs = ReturnSumInputs();
            var fee = sumInputs - sumOutputs;
            return fee;
        }

        private decimal CalculateRewardMiner()
        {
            var fee = CalculateFee();
            var reward = fee + rewardMiner;
            return reward;
        }
    }
}
