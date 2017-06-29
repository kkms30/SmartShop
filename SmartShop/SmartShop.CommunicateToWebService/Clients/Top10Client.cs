using System.Collections.Generic;
using SmartShop.CommunicateToWebService.Utils;
using SmartShop.Models.Mappers;

namespace SmartShop.CommunicateToWebService.Clients
{
    public class Top10Client : BaseClient<BestSellingProduct>
    {
        public Top10Client(string token) : base(token, Endpoint.Top10)
        {
        }

        public List<BestSellingProduct> GetTop10Products()
        {
            return base.Get();
        }
    }
}
