using SmartShop.CommunicateToWebService.Clients;
using SmartShopWebApp.Persistance.Mappers;
using SmartShopWpf.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Asynchronous
{
    class DailyReportInvoker
    {
        public void Download()
        {
            Task.Factory.StartNew<List<Report>>(() =>
            {
                DailyReportClient reportClient = new DailyReportClient(DataHandler.GetInstance().Token);
                List<Report> dailyReport = reportClient.GetDailyReport();
                return dailyReport;

            }).ContinueWith((dailyReport) =>
            {

                Trace.WriteLine("POBRANO PODSUMOWANIE DNIA");
            });
        }
    }
}
