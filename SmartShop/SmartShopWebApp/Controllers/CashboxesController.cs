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
    public class CashboxesController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CashboxesController()
        {
            _unitOfWork = new UnitOfWork(new ShopContext());
        }

        public CashboxesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cashboxes
        [Authorize]
        public List<Cashbox> GetCashboxes()
        {
            return _unitOfWork.Cashboxes.GetCashboxes();
        }

        // GET: api/Cashboxes/5
        [Authorize]
        [ResponseType(typeof(Cashbox))]
        public IHttpActionResult GetCashbox(int id)
        {
            Cashbox cashbox = _unitOfWork.Cashboxes.GetCashboxById(id);
            if (cashbox == null)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent($"No cashbox with id = {id} found")
                };
                throw new HttpResponseException(message);
            }
            return Ok(cashbox);
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