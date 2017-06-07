using SmartShopWpf.Data;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmartShopWpf.Asynchronous
{
    public class ReturnSearchInvoker
    {
        public void ShowReturnedProducts(int idTransaction, ListView listVReturnsListOfProductsToReturn, Label informationLabel)
        {
            Task.Factory.StartNew(() =>
            {
                TransactionManager tM = new TransactionManager();
                List<Transaction> transactions = tM.GetTransactions();
                List<Order> orders = new List<Order>();

                foreach (Transaction t in transactions)
                {
                    if (t.Id == idTransaction)
                    {
                        foreach (Order o in t.Orders)
                        {
                            orders.Add(o);
                        }
                        break;
                    }
                }

                int counter = 0;
                foreach (Order o in orders)
                {
                    counter++;

                    ReturnObject rO = new ReturnObject { IdOrder = o.IdOrder, Number = counter, Name = o.Product.Name, Image = o.Product.Image, Count = o.Count, Price = o.Product.Price, Discount = o.Discount };
                    if (o.Return == 1)
                    {
                        rO.ReturnedText = "TAK";
                    }
                    else
                    {
                        rO.ReturnedText = "NIE";
                    }

                    listVReturnsListOfProductsToReturn.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        listVReturnsListOfProductsToReturn.Items.Add(rO);
                    }));

                    informationLabel.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        informationLabel.Content = "Wyszukano produkty";
                    }));
                }
            });
        }
    }
}
