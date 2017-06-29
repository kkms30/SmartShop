using SmartShop.CommunicateToWebService.Clients;
using SmartShopWebApp.Persistance.Mappers;
using SmartShopWpf.Data;
using SmartShopWpf.ReceipeMethods;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartShopWpf.Asynchronous
{
    public class MonthlyReportInvoker
    {
        public void Download()
        {
            MonthlyPDFGenerator monthlyPdfGenerator;
            Task.Factory.StartNew(() =>
            {
                MonthlyReportClient reportClient = new MonthlyReportClient(DataHandler.GetInstance().Token);
                List<Report> monthlyReport = reportClient.GetDailyReport();
                return monthlyReport;
            }).ContinueWith((monthlyReport) =>
            {
                monthlyPdfGenerator = new MonthlyPDFGenerator(monthlyReport.Result);
                monthlyPdfGenerator.GeneratePDF();
                Trace.WriteLine("POBRANO PODSUMOWANIE MIESIACA");
            });
        }
    }
}