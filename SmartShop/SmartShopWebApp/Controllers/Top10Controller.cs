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
    public class Top10Controller : ApiController
    {
        [Authorize]
        public List<BestSellingProduct> GetTop10()
        {
            ExtraFeatures features = new ExtraFeatures();
            return features.GetTop10SellingProducts();
        }
    }
}
