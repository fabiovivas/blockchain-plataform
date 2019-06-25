using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Utxo : Output
    {
        public string TxId { get; set; }
        public int vOut { get; set; }
        //public DateTime CreateDate { get; }

        public Utxo(string TxId, int vOut, decimal Value, string Address) : base(Value, Address)
        {
            this.TxId = TxId;
            this.vOut = vOut;
            //this.CreateDate = DateTime.Now; 
        }
    }
}
