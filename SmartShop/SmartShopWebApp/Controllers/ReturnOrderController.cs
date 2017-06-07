using SmartShopWebApp.Persistance;
using SmartShopWebApp.Persistance.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SmartShopWebApp.Controllers
{
    public class ReturnOrderController : ApiController
    {
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReturnOrder(int id, ReturnOrder returnOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != returnOrder.IdOrder)
            {
                return BadRequest();
            };

            ExtraFeatures features = new ExtraFeatures();
            features.ReturnOrder(returnOrder);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
