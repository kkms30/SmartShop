using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.CommunicateToWebService
{
    public class ApiAuthenticationResponse
    {
        public string access_token { get; set; }
   
        public string token_type { get; set; }

        public int expires_in { get; set; }
    }
}
