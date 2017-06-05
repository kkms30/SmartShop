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
    class MonthlyReportInvoker
    {
        public void Download()
        {
            Task.Factory.StartNew<List<Report>>(() =>
            {
                MonthlyReportClient  reportClient = new MonthlyReportClient(DataHandler.GetInstance().Token);
                List<Report> monthlyReport = reportClient.GetDailyReport();
                return monthlyReport;

            }).ContinueWith((dailyReport) =>
            {

                Trace.WriteLine("POBRANO PODSUMOWANIE MIESIACA");
            });
        }
    }
}
