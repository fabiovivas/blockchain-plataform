using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blockchain.Web.Models;
using Blockchain.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blockchain.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlockchainClient _blockchainClient;

        public HomeController(IOptions<BlockchainClient> blockchainClient_)
        {
            _blockchainClient = blockchainClient_.Value;
        }

        public IActionResult Index()
        {
            var blocks = _blockchainClient.miner.Bitcoin.Chain;
            return View(blocks);
        }

        public JsonResult ReturnBlockchainJson()
        {
            var chain = _blockchainClient.miner.Bitcoin.Chain;
            return Json(chain);
        }

        public JsonResult ReturnUtxoJson()
        {
            var UtxoSet = _blockchainClient.miner.UtxoSet;
            return Json(UtxoSet);
        }

        public JsonResult ReturnTransactionPoolJson()
        {
            var transactionPool = _blockchainClient.miner.Bitcoin.TransactionPool;
            return Json(transactionPool);
        }

        public IActionResult PesquisarBlock(string search)
        {
            var index = 0;
            if (Int32.TryParse(search, out index))
            {
                var block = _blockchainClient.miner.Bitcoin.Chain
                                            .Where(x => x.Index == index)
                                            .ToList();

                return View("Index", block);
            }
            else
            {
                var transactions = _blockchainClient.miner.Bitcoin.Chain
                                                .SelectMany(x => x.TransactionList)
                                                .Where(x => x.TxId == search)
                                                .ToList();

                return View("Miner", transactions);
            }
        }

        public IActionResult Miner()
        {
            var transactions = _blockchainClient.miner.Bitcoin.TransactionPool;
            return View(transactions);
        }

        public IActionResult Wallet()
        {
            var wallet = _blockchainClient.wallet;
            return View(wallet);
        }

        public IActionResult CreateWallet()
        {
            var walletModel = new WalletModel();
            return PartialView("../Home/_CreateWallet", walletModel);
        }

        [HttpPost]
        public IActionResult CreateWallet(WalletModel wallet)
        {
            _blockchainClient.wallet.AddWalletAddress(wallet.Name);
            return RedirectToAction("Wallet");
        }

        public IActionResult Send()
        {
            var walletTransfer = new WalletTransfer();
            ViewBag.Address = new SelectList(_blockchainClient.wallet.WalletsAddress);

            return PartialView("../Home/_Send", walletTransfer);
        }

        [HttpPost]
        public IActionResult Send(WalletTransfer walletTransfer)
        {
            _blockchainClient.wallet.TransferValue(walletTransfer.AddressFrom, walletTransfer.Value, walletTransfer.AddressTo);
            return RedirectToAction("Miner");
        }

        public IActionResult MinerTransactions()
        {
            _blockchainClient.miner.MinerTransactions();
            return RedirectToAction("Miner");
        }

        public IActionResult RemoveTransaction(string txId)
        {
            _blockchainClient.miner.Bitcoin.TransactionPool.RemoveAll(x => x.TxId == txId);
            return RedirectToAction("Miner");
        }

        public IActionResult ClearBlockachain()
        {
            _blockchainClient.miner = new Miner();
            _blockchainClient.wallet = new Wallet(_blockchainClient.miner, "satoshi");
            return RedirectToAction("Index");
        }
    }
}
