using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using SmartShop.CommunicateToWebService.Clients;
using SmartShop.Models.Mappers;
using SmartShopWpf.Data;

namespace SmartShopWpf.Asynchronous
{
    public class Top10Invoker
    {
        public void Download(ListView top10ListView)
        {
            Task.Factory.StartNew(() =>
            {
                Top10Client top10Client = new Top10Client(DataHandler.GetInstance().Token);
                List<BestSellingProduct> top10 = top10Client.GetTop10Products();
                return top10;
            }).ContinueWith(asct =>
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