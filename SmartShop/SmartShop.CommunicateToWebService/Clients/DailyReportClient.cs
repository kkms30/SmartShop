using SmartShopWebApp.Persistance.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class DailyReportClient : BaseClient<Report>
    {
        public DailyReportClient(string token) : base(token, Endpoint.REPORT_DAILY) { }

        public List<Report> GetDailyReport()
        {
            return base.Get();
        }
    }
}
