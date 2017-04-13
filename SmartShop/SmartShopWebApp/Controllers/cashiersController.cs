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
using log4net;
using System.Reflection;

namespace SmartShopWebApp.Controllers
{
    public class CashiersController : ApiController
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private UnitOfWork unitOfWork = new UnitOfWork(new ShopContext());

        private ShopContext context = new ShopContext();

        // GET: api/cashiers
        public Shop Getcashiers()
        {
            //Category category = new Category() { Name = "CHuj" };
            //Product product = new Product() { Name = "Apteczka", Code = "67841", Price = 7, Category = category };
            //Product product2 = new Product() { Name = "Apteczka", Code = "78", Price = 8, Category = category };
            Product product = unitOfWork.Products.Get(102);
            unitOfWork.Products.Attach(product);
            Order order = new Order() { Return = 0, Count = 1, Discount = 0, Product = product };

            Product product2 = unitOfWork.Products.Get(105);
            unitOfWork.Products.Attach(product2);
            Order order2 = new Order() { Return = 0, Count = 1, Discount = 0, Product = product2 };

            Cashbox cashbox = unitOfWork.Cashboxes.Get(5);
            unitOfWork.Cashboxes.Attach(cashbox);

            Cashier cashier = unitOfWork.Cashiers.Get(1);
            unitOfWork.Cashiers.Attach(cashier);

            Transaction transaction = new Transaction() { Id = 9870, TotalPrice = 789, Discount = 0, Cashbox = cashbox, Cashier = cashier };

            //Shop shop = new Shop() { Name = "Caly", Address = "Test" };

            //Cashier cashier = new Cashier() { Id = "Aldona", Name = "Was", Surname = "Szklanka", Password = "tajne" };
                               

            unitOfWork.Transactions.Add(transaction);
            unitOfWork.Complete();

            //context.Transactions.Add(transaction);
            //context.SaveChanges();

            //try
            //{

            //}
            //catch (DbUpdateException e)
            //{
            //    log.Debug("Debug message ");
            //    log.Debug("Inner " + e.InnerException);
            //    log.Debug("Inner message " + e.InnerException.Message);
            //}




            Shop shop5 = unitOfWork.Shops.GetShopWithCashboxes(1);

            return shop5;
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