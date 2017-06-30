using System.Collections.Generic;
using System.Web.Http;
using SmartShopWebApp.Core;
using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Persistance;

namespace SmartShopWebApp.Controllers
{
    public class ProductsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ProductsController()
        {
            _unitOfWork = new UnitOfWork(new ShopContext());
        }

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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