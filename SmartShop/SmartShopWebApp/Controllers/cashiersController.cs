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
    public class cashiersController : ApiController
    {
        private smartshopEntities db = new smartshopEntities();

        // GET: api/cashiers
        public IQueryable<cashier> Getcashiers()
        {
            return db.cashiers;
        }

        // GET: api/cashiers/5
        [ResponseType(typeof(cashier))]
        public IHttpActionResult Getcashier(int id)
        {
            cashier cashier = db.cashiers.Find(id);
            if (cashier == null)
            {
                return NotFound();
            }

            return Ok(cashier);
        }

        // PUT: api/cashiers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcashier(int id, cashier cashier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cashier.idcashiers)
            {
                return BadRequest();
            }

            db.Entry(cashier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cashierExists(id))
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

        // POST: api/cashiers
        [ResponseType(typeof(cashier))]
        public IHttpActionResult Postcashier(cashier cashier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cashiers.Add(cashier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cashier.idcashiers }, cashier);
        }

        // DELETE: api/cashiers/5
        [ResponseType(typeof(cashier))]
        public IHttpActionResult Deletecashier(int id)
        {
            cashier cashier = db.cashiers.Find(id);
            if (cashier == null)
            {
                return NotFound();
            }

            db.cashiers.Remove(cashier);
            db.SaveChanges();

            return Ok(cashier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cashierExists(int id)
        {
            return db.cashiers.Count(e => e.idcashiers == id) > 0;
        }
    }
}