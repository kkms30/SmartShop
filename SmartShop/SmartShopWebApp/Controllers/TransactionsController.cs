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
using System.Threading.Tasks;

namespace SmartShopWebApp.Controllers
{
    public class TransactionsController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new ShopContext());

        // GET: api/Transactions
        [Authorize]
        public List<Transaction> GetTransactions()
        {
            return unitOfWork.Transactions.GetTransactions();
        }

        // GET: api/Transactions/5
        [Authorize]
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
        [Authorize]
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult PostTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Task addTransaction = Task.Factory.StartNew(() =>
                {
                    unitOfWork.Transactions.Add(transaction);
                    unitOfWork.Complete();
                });
                addTransaction.Wait();
            }
            catch (Exception e)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("An error occured during inserting transaction to database.")
                };
                throw new HttpResponseException(message);
            }

            return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, unitOfWork.Transactions.GetTransactionById(transaction.Id));
        }



        // PUT: api/Transactions/5
        [Authorize]
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
            };

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