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
    public class CashiersController : ApiController
    {
        private smartshopEntities db = new smartshopEntities();

        // GET: api/cashiers
        public IQueryable<Cashier> Getcashiers()
        {
            return db.Cashiers;
        }

        // GET: api/cashiers/5
        [ResponseType(typeof(Cashier))]
        public IHttpActionResult Getcashier(int id)
        {
            Cashier cashier = db.Cashiers.Find(id);
            if (cashier == null)
            {
                return NotFound();
            }

            return Ok(cashier);
        }

        // PUT: api/cashiers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcashier(int id, Cashier cashier)
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
        [ResponseType(typeof(Cashier))]
        public IHttpActionResult Postcashier(Cashier cashier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cashiers.Add(cashier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cashier.idcashiers }, cashier);
        }

        // DELETE: api/cashiers/5
        [ResponseType(typeof(Cashier))]
        public IHttpActionResult Deletecashier(int id)
        {
            Cashier cashier = db.Cashiers.Find(id);
            if (cashier == null)
            {
                return NotFound();
            }

            db.Cashiers.Remove(cashier);
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
            return db.Cashiers.Count(e => e.idcashiers == id) > 0;
        }
    }
}