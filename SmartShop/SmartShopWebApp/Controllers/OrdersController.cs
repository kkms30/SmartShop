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
    public class OrdersController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new ShopContext());

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