using SmartShopWebApp.Persistance.Mappers;
using System.Collections.Generic;
using SmartShop.CommunicateToWebService.Utils;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class DailyReportClient : BaseClient<Report>
    {
        public DailyReportClient(string token) : base(token, Endpoint.ReportDaily) { }

        public List<Report> GetDailyReport()
        {
            return base.Get();
        }
    }
}
