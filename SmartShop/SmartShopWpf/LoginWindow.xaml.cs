using PluginLogIn;
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

            string id = txtLogin.Text;
            string password = pswPassword.Password;
            ProductsClient productsClient = null;
            CashierClient cashierClient = null;
            Cashier cashier = null;
            List<Product> products = new List<Product>();
            string token = "";
            btnLogin.IsEnabled = false;
            Task.Factory.StartNew((Action)delegate { 

            foreach (FileInfo fi in di.GetFiles("PluginLogIn.dll"))
            {
                Assembly pluginAssembly = Assembly.LoadFrom(fi.FullName);
                foreach (Type pluginType in pluginAssembly.GetExportedTypes())
                {
                    if (pluginType.GetInterface(typeof(ILogIn).Name) != null)
                    {
                        ILogIn TypeLoadedFromPlugin = (ILogIn)Activator.CreateInstance(pluginType);
                        if (TypeLoadedFromPlugin.CheckLoginData(id, password, ref productsClient, ref cashierClient, ref cashier, ref products, ref token))
                        {

                                InitAppData(cashier, products, token);
                                Dispatcher.BeginInvoke(new Action(delegate
                                {
                                    
                                    MainWindow mW = new MainWindow(false);
                                    mW.Show();
                                    this.Close();
                                }));
                            }
                        else
                        {
                            MessageBox.Show("Invalid login or password. Please check the data", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
            }
            });
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

    }
}
