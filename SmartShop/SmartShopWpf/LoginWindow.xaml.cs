using PluginLogIn;
using SmartShop.CommunicateToWebService;
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
        private DirectoryInfo _directoryInfo;

        public LoginWindow()
        {
            InitializeComponent();
            _directoryInfo = new DirectoryInfo(".");
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
            Task.Factory.StartNew((Action) delegate
            {
                foreach (FileInfo fi in _directoryInfo.GetFiles("PluginLogIn.dll"))
                {
                    Assembly pluginAssembly = Assembly.LoadFrom(fi.FullName);
                    foreach (Type pluginType in pluginAssembly.GetExportedTypes())
                    {
                        if (pluginType.GetInterface(typeof(ILogIn).Name) != null)
                        {
                            ILogIn typeLoadedFromPlugin = (ILogIn) Activator.CreateInstance(pluginType);
                            if (typeLoadedFromPlugin.CheckLoginData(id, password, ref productsClient, ref cashierClient,
                                ref cashier, ref products, ref token))
                            {
                                InitAppData(cashier, products, token);
                                Dispatcher.BeginInvoke(new Action(delegate
                                {
                                    MainWindow mainWindow = new MainWindow();
                                    mainWindow.Show();
                                    Close();
                                }));
                            }
                            else
                            {
                                MessageBox.Show("Nieprawidłowy login lub hasło!", "Błąd logowania", MessageBoxButton.OK,
                                    MessageBoxImage.Exclamation);
                            }
                        }
                    }
                }
            });
        }


        private void pswPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pswPassword.Tag = string.IsNullOrWhiteSpace(pswPassword.Password) ? "Hasło" : "";
        }

        private void InitAppData(Cashier cashier, List<Product> products, string token)
        {
            DataHandler data = DataHandler.GetInstance();
            data.Token = token;

            Cashbox cashbox = new Cashbox
            {
                IdCashbox = 13,
                ShopId = 14,
                Id = 1
            };

            data.Cashier = cashier;
            data.Products = products;
            data.Cashbox = cashbox;
        }
    }
}