using SmartShop.CommunicateToWebService.Clients;
using SmartShopWebApp.Persistance.Mappers;
using SmartShopWpf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShopWpf.Asynchronous
{
    class ReturnOrderInvoker
    {
        private List<ReturnObject> returnObjects;
        public ReturnOrderInvoker(List<ReturnObject> returnObjects)
        {
            this.returnObjects = returnObjects;          
        }

        //wywalic PO TESTACH
        //public ReturnOrderInvoker()
        //{
        //    this.returnObjects = new List<ReturnObject>();

        //    //returnObjects.Add(new ReturnObject() { idOrder = , Count =  });
        //    //returnObjects.Add(new ReturnObject() { idOrder = , Count =  });
        //}

        public void Return()
        {
            Task.Factory.StartNew(() =>
            {
                ReturnOrderClient returnClient = new ReturnOrderClient(DataHandler.GetInstance().Token);
                foreach (var returnObject in returnObjects)
                {
                    ReturnOrder returnOrder = new ReturnOrder();
                    returnOrder.IdOrder = returnObject.idOrder;
                    returnOrder.Count = returnObject.Count;
                    returnClient.ReturnOrder(returnOrder);
                }
            });
        }
    }
}
