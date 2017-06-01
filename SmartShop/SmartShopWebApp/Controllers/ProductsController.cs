using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Persistance;

namespace SmartShopWebApp.Controllers
{
    public class ProductsController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ShopContext());

        // GET: api/Products
        [Authorize]
        public IEnumerable<Product> GetProducts()
        {
            return unitOfWork.Products.GetProductsWithCategories();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }      
    }
}