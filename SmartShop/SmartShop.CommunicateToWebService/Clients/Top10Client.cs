using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartShopWpf.Models.Mappers;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class Top10Client : BaseClient<BestSellingProduct>
    {
        public Top10Client(string token) : base(token, Endpoint.TOP10)
        {
        }

        public List<BestSellingProduct> GetTop10Products()
        {
            return base.Get();
        }
    }
}
