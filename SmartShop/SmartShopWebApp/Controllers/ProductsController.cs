using System.Collections.Generic;
using System.Web.Http;
using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Persistance;

namespace SmartShopWebApp.Controllers
{
    public class ProductsController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new ShopContext());

        // GET: api/Products
        [Authorize]
        public IEnumerable<Product> GetProducts()
        {
            return _unitOfWork.Products.GetProductsWithCategories();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }      
    }
}