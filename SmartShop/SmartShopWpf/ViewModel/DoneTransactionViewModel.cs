using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.ViewModel
{
    public class DoneTransactionViewModel
    {
        public int CashboxId { get; set; }
        public int CashierId { get; set; }
        public int Id { get; set; }
        public String TotalPrice { get; set; }
        public String DateFormatted { get; set; }

        public DoneTransactionViewModel(Transaction transaction)
        {
            CashboxId = transaction.CashboxId;
            CashierId = transaction.CashierId;
            Id = transaction.Id;
            TotalPrice = transaction.TotalPrice.ToString("0.00");
            DateFormatted = transaction.Date.ToString("dd-MM-yyyy HH:mm");
        }
    }
}
