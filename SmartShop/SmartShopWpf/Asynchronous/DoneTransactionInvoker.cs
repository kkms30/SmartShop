using SmartShopWpf.Data;
using SmartShopWpf.Models;
using SmartShopWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SmartShopWpf.Asynchronous
{
    public class DoneTransactionInvoker
    {
        public void Download(ListView transactionsListView)
        {
            Task.Factory.StartNew<List<DoneTransactionViewModel>>(() =>
            {
                List<Transaction> transactions = new TransactionManager().GetTransactions();
                List<DoneTransactionViewModel> viewModels = new List<DoneTransactionViewModel>();

                transactions.ForEach(t => viewModels.Add(new DoneTransactionViewModel(t)));
                             
                return viewModels;

            }).ContinueWith((asct) =>
            {
                transactionsListView.Dispatcher.BeginInvoke(new Action(() =>
                {
                    transactionsListView.ItemsSource = asct.Result;

                    Trace.WriteLine("POBRANO WYKONANE TRANSAKCJE");
                }));
            });
        }
    }
}
