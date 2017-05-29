using SmartShopWpf.Data;
using SmartShopWpf.Models;
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
            Task.Factory.StartNew<List<Transaction>>(() =>
            {
                List<Transaction> transactions = new TransactionManager().GetTransactions();
                return transactions;

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
