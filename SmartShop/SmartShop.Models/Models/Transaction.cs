using System;
using System.Collections.Generic;

namespace SmartShop.Models.Models
{
    public class Transaction
    {
        public Transaction()
        {
            this.Orders = new HashSet<Order>();
        }

        public int IdTransaction { get; set; }
        public int CashboxId { get; set; }
        public int CashierId { get; set; }
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public float TotalPrice { get; set; }
        public Nullable<float> Discount { get; set; }
        public virtual Cashbox Cashbox { get; set; }
        public virtual Cashier Cashier { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
