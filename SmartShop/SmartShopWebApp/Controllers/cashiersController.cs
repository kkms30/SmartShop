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
using SmartShopWebApp.Core.Repositories;
using SmartShopWebApp.Persistance.Repositories;
using SmartShopWebApp.Persistance;
using Newtonsoft.Json;

namespace SmartShopWebApp.Controllers
{
    public class CashiersController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ShopContext());

        private ShopContext context = new ShopContext();

        // GET: api/cashiers
        public Shop Getcashiers()
        {
            //unitOfWork.Shops.Add(new Shop() { Address = "test", Name = "uow" });
            //unitOfWork.Complete();

            //List<Shop> shops = unitOfWork.Shops.GetAll().ToList(); ;

            Shop shopAdd = new Shop() { Address = "Tescik", Name = "Imie" };
            Cashbox cashbox = new Cashbox() { Id = 555 };

            shopAdd.Cashboxes.Add(cashbox);
            context.Shops.Add(shopAdd);
            context.SaveChanges();


            Shop shop = unitOfWork.Shops.GetShopWithCashboxes(1);

            return shop;
        }

        // GET: api/cashiers/5
        [ResponseType(typeof(Cashier))]
        public IHttpActionResult Getcashier(int id)
        {
            Cashier cashier = context.Cashiers.Find(id);
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

            if (id != cashier.IdCashier)
            {
                return BadRequest();
            }

            context.Entry(cashier).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
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

            context.Cashiers.Add(cashier);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cashier.IdCashier }, cashier);
        }

        // DELETE: api/cashiers/5
        [ResponseType(typeof(Cashier))]
        public IHttpActionResult Deletecashier(int id)
        {
            Cashier cashier = context.Cashiers.Find(id);
            if (cashier == null)
            {
                return NotFound();
            }

            context.Cashiers.Remove(cashier);
            context.SaveChanges();

            return Ok(cashier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cashierExists(int id)
        {
            return context.Cashiers.Count(e => e.IdCashier == id) > 0;
        }
    }
}