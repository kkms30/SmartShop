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
using System.Threading;

namespace SmartShopWebApp.Controllers
{
    public class TransactionsController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ShopContext());

        // GET: api/Transactions
        public List<Transaction> GetTransactions()
        {
            return unitOfWork.Transactions.GetTransactions();
        }

        // GET: api/Transactions/5
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult GetTransaction(int id)
        {
            Transaction transaction = unitOfWork.Transactions.GetTransactionByIdTransaction(id);
            if (transaction == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("No transaction with id = {0} found", id))
                };
                throw new HttpResponseException(message);            
            }
            return Ok(transaction);
        }

        // POST: api/Transactions
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult PostTransaction(Transaction transaction)
        {
            Transaction t = new Transaction();
            t.Cashbox = unitOfWork.Cashboxes.GetCashboxById(1);
            t.Cashier = unitOfWork.Cashiers.GetCashierById(5.ToString());
            //t.Id = 788896;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //try
            //{
                unitOfWork.Transactions.Add(transaction);
                unitOfWork.Complete();
            //}
            //catch(Exception e)
            //{
            //    var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
            //    {
            //        Content = new StringContent("An error occured during inserting transaction to database.")
            //    };
            //    throw new HttpResponseException(message);
            //}  

            return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, unitOfWork.Transactions.GetTransactionById(transaction.Id));
        }



        // PUT: api/Transactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransaction(int id, Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.IdTransaction)
            {
                return BadRequest();
            }

            //Transaction test = unitOfWork.Transactions.GetTransactionByIdTransaction(1077);
            //Product product = unitOfWork.Products.Get(1);
            //Order order = new Order();
            //order.ProductId = product.IdProduct;
            //order.Count = 3;

            //test.Orders.Add(order);

            unitOfWork.Transactions.ModifyWithNewOrders(transaction);
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