using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Persistance.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShopWebApp.Persistance
{
    public class ExtraFeatures
    {
        public List<BestSellingProduct> GetTop10SellingProducts()
        {
            using (var context = new ShopContext())
            {
                var bestSelling = context.Database.SqlQuery<BestSellingProduct>("topProducts").ToList();
                return bestSelling;
            }
        }

        public List<Report> GetMonthlyReport()
        {
            using (var context = new ShopContext())
            {
                var monthReport = context.Database.SqlQuery<Report>("reportMonth").ToList();
                return monthReport;
            }
        }

        public List<Report> GetDailyReport()
        {
            using (var context = new ShopContext())
            {
                var dailyReport = context.Database.SqlQuery<Report>("reportDay").ToList();
                return dailyReport;
            }
        }
    }
}