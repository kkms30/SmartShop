using MySql.Data.MySqlClient;
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

        public void ReturnOrder(ReturnOrder returnOrder)
        {
            using (var context = new ShopContext())
            {
                MySqlParameter[] queryParams = new MySqlParameter[] {
                     new MySqlParameter("@IdOrder", returnOrder.IdOrder),
                     new MySqlParameter("@Count", returnOrder.Count)
            };

                var affectedRows = context.Database.ExecuteSqlCommand("CALL returnProduct({0}, {1});", returnOrder.IdOrder, returnOrder.Count);


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