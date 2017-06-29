using System.Collections.Generic;

namespace SmartShop.Models.Models
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
