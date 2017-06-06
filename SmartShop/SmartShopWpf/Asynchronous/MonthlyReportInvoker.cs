using SmartShop.CommunicateToWebService.Clients;
using SmartShopWebApp.Persistance.Mappers;
using SmartShopWpf.Data;
using SmartShopWpf.ReceipeMethods;
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
            MonthlyPDFGenerator dPG;
            Task.Factory.StartNew<List<Report>>(() =>
            {
                MonthlyReportClient  reportClient = new MonthlyReportClient(DataHandler.GetInstance().Token);
                List<Report> monthlyReport = reportClient.GetDailyReport();
                return monthlyReport;

            }).ContinueWith((monthlyReport) =>
            {
                dPG = new MonthlyPDFGenerator(monthlyReport.Result);
                dPG.GeneratePDF();
                Trace.WriteLine("POBRANO PODSUMOWANIE MIESIACA");
            });
        }
    }
}
