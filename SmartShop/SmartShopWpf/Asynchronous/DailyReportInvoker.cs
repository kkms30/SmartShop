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
    class DailyReportInvoker
    {
        public void Download()
        {
            DailyPDFGenerator dPG;
            Task op = Task.Factory.StartNew<List<Report>>(() =>
            {
                DailyReportClient reportClient = new DailyReportClient(DataHandler.GetInstance().Token);
                List<Report> dailyReport = reportClient.GetDailyReport();
                return dailyReport;
                
            }).ContinueWith((dailyReport) =>
            {
                dPG = new DailyPDFGenerator(dailyReport.Result);
                dPG.GeneratePDF();
                Trace.WriteLine("POBRANO PODSUMOWANIE DNIA");
                //dailyReport.Wait();
            });
            //op.Wait();
        }
    }
}
