using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Models
{
    public class Cashbox
    {
        public Cashbox()
        {
            this.Transactions = new HashSet<Transaction>();
        }
        public int IdCashbox { get; set; }
        public int ShopId { get; set; }
        public int Id { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
