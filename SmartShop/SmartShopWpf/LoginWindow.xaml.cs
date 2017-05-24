using PluginMockLogowanie;
using SmartShop.CommunicateToWebService;
using SmartShop.CommunicateToWebService.Authentication;
using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Data;
using SmartShopWpf.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private DirectoryInfo di;

        public LoginWindow()
        {
            InitializeComponent();

            txtLogin.Text = "5";
            pswPassword.Password = "test";
            di = new DirectoryInfo(".");
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            ProductsClient productsClient = null;
            CashierClient cashierClient= null;

            Cashier cashier = null;

            List<Product> products = new List<Product>();

            string id = txtLogin.Text;
            string password = pswPassword.Password;

            string token = TokenRequester.ReuqestToken(id, password);          
              
            if (token != null)
            {
                cashierClient = new CashierClient(token);
                productsClient = new ProductsClient(token);

                cashier = cashierClient.Login(id);
                products = productsClient.GetProducts(token);
            }

            if (cashier != null && products.Count > 0)
            {
                InitAppData(cashier, products, token);

                MainWindow mW = new MainWindow(false);
                mW.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Błąd logowania");
            }
        }


        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(pswPassword.Password))
                pswPassword.Tag = "Hasło";
            else
                pswPassword.Tag = "";
        }

        private void InitAppData(Cashier cashier, List<Product> products, string token)
        {
            DataHandler data = DataHandler.GetInstance();
            data.Token = token;

            Cashbox cashbox = new Cashbox();
            cashbox.IdCashbox = 13;
            cashbox.ShopId = 14;
            cashbox.Id = 1;

            data.Cashier = cashier;
            data.Products = products;
            data.Cashbox = cashbox;
        }

        private void btnLogin_ClickWithPlugin(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = pswPassword.Password.Trim();
            // bool checkLoginDataByPlugin = false;

            foreach (FileInfo fi in di.GetFiles("PluginMockLogowanie.dll"))
            {
                Assembly pluginAssembly = Assembly.LoadFrom(fi.FullName);
                foreach (Type pluginType in pluginAssembly.GetExportedTypes())
                {
                    if (pluginType.GetInterface(typeof(IMockLogowania).Name) != null)
                    {
                        IMockLogowania TypeLoadedFromPlugin = (IMockLogowania)Activator.CreateInstance(pluginType);
                        //checkLoginDataByPlugin = TypeLoadedFromPlugin.CheckLoginData(login,password);
                        if (TypeLoadedFromPlugin.CheckLoginData(login, password))
                        {
                            MainWindow mW = new MainWindow(true);
                            mW.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login or password. Please check the data", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
            }
        }
    }
}