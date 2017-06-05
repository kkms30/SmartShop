using SmartShopWebApp.Persistance.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class MonthlyReportClient : BaseClient<Report>
    {
        public MonthlyReportClient(string token) : base(token, Endpoint.REPORT_MONTHLY) { }

        public List<Report> GetDailyReport()
        {
            return base.Get();
        }
    }
}
