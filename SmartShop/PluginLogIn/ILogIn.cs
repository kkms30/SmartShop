﻿using SmartShop.CommunicateToWebService;
using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginLogIn
{
    public interface ILogIn
    {
        bool CheckLoginData(string id, string password,ref ProductsClient productsClient,
            ref CashierClient cashierClient,ref Cashier cashier,ref List<Product> products, ref string token);
    }
}