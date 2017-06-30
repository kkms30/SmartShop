using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartShopWebApp.Core;
using SmartShopWebApp.Core.GeneratedModels;
using SmartShopWebApp.Persistance;

namespace SmartShopWebApp.Controllers
{
    public class CashiersController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CashiersController()
        {
            _unitOfWork = new UnitOfWork(new ShopContext());
        }

        public CashiersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cashiers/5
        [Authorize]
        [ResponseType(typeof(Cashier))]
        public IHttpActionResult GetCashier(string id)
        {
            Cashier cashier = _unitOfWork.Cashiers.GetCashierById(id);
            if (cashier == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent($"No cashier with id = {id} found")
                };
                throw new HttpResponseException(message);
            }
            return Ok(cashier);
        }

        // GET: api/Cashiers
        [Authorize]
        public List<Cashier> GetCashiers()
        {
            return _unitOfWork.Cashiers.GetCashiers();
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

            _unitOfWork.Cashiers.Modify(cashier);
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