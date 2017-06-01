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

        // GET: api/Cashiers/5
        [Authorize]
        [ResponseType(typeof(Cashier))]
        public IHttpActionResult GetCashier(string id)
        {
            Cashier cashier = unitOfWork.Cashiers.GetCashierById(id);
            if (cashier == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("No cashier with id = {0} found", id))
                };
                throw new HttpResponseException(message);
            }
            return Ok(cashier);
        }

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