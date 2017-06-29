using SmartShopWebApp.Persistance.Mappers;
using System.Collections.Generic;
using SmartShop.CommunicateToWebService.Utils;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class MonthlyReportClient : BaseClient<Report>
    {
        public MonthlyReportClient(string token) : base(token, Endpoint.ReportMonthly) { }

        public List<Report> GetDailyReport()
        {
            return base.Get();
        }
    }
}
