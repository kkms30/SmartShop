using SmartShop.CommunicateToWebService.Clients;
using SmartShopWebApp.Persistance.Mappers;
using SmartShopWpf.Data;
using SmartShopWpf.ReceipeMethods;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartShopWpf.Asynchronous
{
    public class DailyReportInvoker
    {
        public void Download()
        {
            DailyPdfGenerator dailyPdfGenerator;
            Task.Factory.StartNew(() =>
            {
                DailyReportClient reportClient = new DailyReportClient(DataHandler.GetInstance().Token);
                List<Report> dailyReport = reportClient.GetDailyReport();
                return dailyReport;
            }).ContinueWith((dailyReport) =>
            {
                dailyPdfGenerator = new DailyPdfGenerator(dailyReport.Result);
                dailyPdfGenerator.GeneratePdf();
                Trace.WriteLine("POBRANO PODSUMOWANIE DNIA");
            });
        }
    }
}