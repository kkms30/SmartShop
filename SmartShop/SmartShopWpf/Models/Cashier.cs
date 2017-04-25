using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Models
{
    public class Cashier
    {
        public Cashier()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        public int IdCashier { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
