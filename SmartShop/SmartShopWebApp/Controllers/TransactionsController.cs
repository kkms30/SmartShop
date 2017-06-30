using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Persistance;
using System.Threading.Tasks;
using SmartShopWebApp.Core;

namespace SmartShopWebApp.Controllers
{
    public class TransactionsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public TransactionsController()
        {
            _unitOfWork = new UnitOfWork(new ShopContext());
        }

        public TransactionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Transactions
        [Authorize]
        public List<Transaction> GetTransactions()
        {
            return _unitOfWork.Transactions.GetTransactions();
        }

        // GET: api/Transactions/5
        [Authorize]
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult GetTransaction(int id)
        {
            Transaction transaction = _unitOfWork.Transactions.GetTransactionByIdTransaction(id);
            if (transaction == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent($"No transaction with id = {id} found")
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
                    _unitOfWork.Transactions.Add(transaction);
                    _unitOfWork.Complete();
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

            return CreatedAtRoute("DefaultApi", new {id = transaction.Id},
                _unitOfWork.Transactions.GetTransactionById(transaction.Id));
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
            }
            ;

            _unitOfWork.Transactions.ModifyWithNewOrders(transaction);
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