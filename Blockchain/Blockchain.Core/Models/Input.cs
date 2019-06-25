using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Input
    {
        public string TxId { get; }
        public int VOut { get; set; }

        public Input(string TxId, int VOut)
        {
            this.TxId = TxId;
            this.VOut = VOut;
        }
    }
}
