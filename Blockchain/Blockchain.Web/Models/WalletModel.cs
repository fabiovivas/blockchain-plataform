using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blockchain.Web.Models
{
    public class WalletModel
    {
        [Required(ErrorMessage = "Fill in the name to generate your wallet")]
        public string Name { get; set; }
    }
}
