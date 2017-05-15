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
    public class CashiersController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ShopContext());

        // GET: api/Cashiers
        [Authorize]
        public List<Cashier> GetCashiers()
        {
            return unitOfWork.Cashiers.GetCashiers();
        }

        // PUT: api/Cashiers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCashier(int id, Cashier cashier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cashier.IdCashier)
            {
                return BadRequest();
            }

            unitOfWork.Cashiers.Modify(cashier);
            unitOfWork.Complete();

            return StatusCode(HttpStatusCode.NoContent);
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