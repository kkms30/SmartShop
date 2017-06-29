using SmartShop.CommunicateToWebService.Clients;
using SmartShopWebApp.Persistance.Mappers;
using SmartShopWpf.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartShopWpf.Asynchronous
{
    public class ReturnOrderInvoker
    {
        private List<ReturnObject> _returnObjects;

        public ReturnOrderInvoker(List<ReturnObject> returnObjects)
        {
            _returnObjects = returnObjects;
        }

        public void Return()
        {
            Task.Factory.StartNew(() =>
            {
                ReturnOrderClient returnClient = new ReturnOrderClient(DataHandler.GetInstance().Token);
                foreach (var returnObject in _returnObjects)
                {
                    ReturnOrder returnOrder = new ReturnOrder
                    {
                        IdOrder = returnObject.IdOrder,
                        Count = returnObject.Count
                    };
                    returnClient.ReturnOrder(returnOrder);
                }
            });
        }
    }
}