using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SmartShopWebApp.Core;
using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Persistance;

namespace SmartShopWebApp.Controllers
{
    public class OrdersController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public OrdersController()
        {
            _unitOfWork = new UnitOfWork(new ShopContext());
        }

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Orders
        [Authorize]
        public IEnumerable<Order> GetOrders()
        {
            return _unitOfWork.Orders.GetOrderWithProducts();
        }

        // PUT: api/Orders/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.IdOrder)
            {
                return BadRequest();
            }

            _unitOfWork.Orders.Modify(order);

            _unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
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