using Blockchain.Core.Models;
using Blockchain.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var miner = new Miner();
            var wallet = new Wallet(miner);

            var satoshiddress = Criptografy.GenerateSHA256String("satoshi");
            var fabioAddress = wallet.AddWalletAddress("fabio");
            var leneAddress = wallet.AddWalletAddress("lene");

            //wallet.TransferValue(satoshiddress, 25, fabioAddress);
            miner.MinerTransactions();
            miner.MinerTransactions();

            Console.WriteLine(miner.Bitcoin.Chain.ToJson());
            Console.ReadKey();
        }
    }
}
