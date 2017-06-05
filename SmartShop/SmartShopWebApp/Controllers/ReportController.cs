using SmartShopWebApp.Persistance;
using SmartShopWebApp.Persistance.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartShopWebApp.Controllers
{
    public class ReportController : ApiController
    {

        [Route("api/report/daily")]
        public List<Report> GetDailyReport()
        {
            ExtraFeatures features = new ExtraFeatures();
            return features.GetDailyReport();
        }


        [Route("api/report/monthly")]
        public List<Report> GetMonthlyReport()
        {
            ExtraFeatures features = new ExtraFeatures();
            return features.GetMonthlyReport();
        }

    }
}
