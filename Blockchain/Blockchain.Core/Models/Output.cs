using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Output
    {
        public decimal Value { get; set; }
        public string Address { get; set; }

        public Output(decimal Value, string Address)
        {
            this.Value = Value;
            this.Address = Address;
        }
    }
}
