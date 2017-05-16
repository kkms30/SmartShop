using SmartShop.CommunicateToWebService;
using SmartShopWpf.Data;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            txtLogin.Text = "5";
            txtPassword.Text = "test";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Cashier cashier = null;
            List<Product> products = new List<Product>();

            string id = txtLogin.Text;
            string password = txtPassword.Text;

            ProductsClient productsClient = new ProductsClient();
            LoginClient loginClient = new LoginClient();

            string token = loginClient.GetToken(id, password);            

            if (token != null)
            {
                cashier = loginClient.Login(id, token);
                products = productsClient.GetProducts(token);
            }

            if (cashier != null && products.Count > 0)
            {
                InitAppData(cashier, products);

                MainWindow mW = new MainWindow();
                mW.Show();
                this.Close();
            }     
            else
            {
                MessageBox.Show("Błąd logowania");
            }      
        }

        private void InitAppData(Cashier cashier, List<Product> products)
        {
            DataHandler data = DataHandler.GetInstance();

            data.Cashier = cashier;
            data.Products = products;
            data.CashboxId = "777";
        }
    }
}
