using SmartShopWpf.Models;

namespace SmartShopWpf.ViewModel
{
    public class DoneTransactionViewModel
    {
        public int CashboxId { get; set; }
        public int CashierId { get; set; }
        public int Id { get; set; }
        public string TotalPrice { get; set; }
        public string DateFormatted { get; set; }

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
