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
using SmartShopWebApp.Models;

namespace SmartShopWebApp.Controllers
{
    public class CashBoxesController : ApiController
    {
        private smartshopEntities db = new smartshopEntities();

        // GET: api/CashBoxes
        public IQueryable<CashBox> GetCashBoxes()
        {
            Shop shop = new Shop() { name = "Test", address = "test", idshops = 5 };
            CashBox cashBox = new CashBox() { id = 3, idcashboxs = 3, shops_idshops = 5 };
            cashBox.Shop = shop;
            shop.CashBoxes.Add(cashBox);

            db.Shops.Add(shop);
            db.CashBoxes.Add(cashBox);

            return db.CashBoxes;
        }

        // GET: api/CashBoxes/5
        [ResponseType(typeof(CashBox))]
        public IHttpActionResult GetCashBox(int id)
        {
            CashBox cashBox = db.CashBoxes.Find(id);
            if (cashBox == null)
            {
                return NotFound();
            }

            return Ok(cashBox);
        }

        // PUT: api/CashBoxes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCashBox(int id, CashBox cashBox)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cashBox.idcashboxs)
            {
                return BadRequest();
            }

            db.Entry(cashBox).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashBoxExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CashBoxes
        [ResponseType(typeof(CashBox))]
        public IHttpActionResult PostCashBox(CashBox cashBox)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CashBoxes.Add(cashBox);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cashBox.idcashboxs }, cashBox);
        }

        // DELETE: api/CashBoxes/5
        [ResponseType(typeof(CashBox))]
        public IHttpActionResult DeleteCashBox(int id)
        {
            CashBox cashBox = db.CashBoxes.Find(id);
            if (cashBox == null)
            {
                return NotFound();
            }

            db.CashBoxes.Remove(cashBox);
            db.SaveChanges();

            return Ok(cashBox);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CashBoxExists(int id)
        {
            return db.CashBoxes.Count(e => e.idcashboxs == id) > 0;
        }
    }
}