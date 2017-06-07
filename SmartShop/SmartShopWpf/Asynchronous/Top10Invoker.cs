using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Data;
using SmartShopWpf.Models.Mappers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmartShopWpf.Asynchronous
{
    class Top10Invoker
    {
        public void Download(ListView top10ListView)
        {
            Task.Factory.StartNew<List<BestSellingProduct>>(() =>
            {
                Top10Client top10Client = new Top10Client(DataHandler.GetInstance().Token);
                List<BestSellingProduct> top10 = top10Client.GetTop10Products();
                return top10;

            }).ContinueWith((asct) =>
            {
                top10ListView.Dispatcher.BeginInvoke(new Action(() =>
                {
                    top10ListView.ItemsSource = asct.Result;

                    Trace.WriteLine("POBRANO TOP10 SPRZEDANYCH PRODUKTÓW");
                }));
            });
        }
    }
}
