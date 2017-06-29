using System.Collections.Generic;

namespace SmartShop.Models.Models
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
