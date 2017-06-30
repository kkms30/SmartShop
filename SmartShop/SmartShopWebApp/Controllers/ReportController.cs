using SmartShopWebApp.Persistance;
using SmartShopWebApp.Persistance.Mappers;
using System.Collections.Generic;
using System.Web.Http;

namespace SmartShopWebApp.Controllers
{
    public class ReportController : ApiController
    {
        [Route("api/report/daily")]
        [Authorize]
        public List<Report> GetDailyReport()
        {
            ExtraFeatures features = new ExtraFeatures();
            return features.GetDailyReport();
        }


        [Route("api/report/monthly")]
        [Authorize]
        public List<Report> GetMonthlyReport()
        {
            ExtraFeatures features = new ExtraFeatures();
            return features.GetMonthlyReport();
        }
    }
}