using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blockchain.Web.Models
{
    public class WalletTransfer
    {
        [Required(ErrorMessage = "Select a wallet")]
        public string AddressFrom { get; set; }

        [Required(ErrorMessage = "Select a wallet")]
        public string AddressTo { get; set; }

        [Required(ErrorMessage = "Fill in the transfer value")]
        public decimal Value { get; set; }
    }
}
