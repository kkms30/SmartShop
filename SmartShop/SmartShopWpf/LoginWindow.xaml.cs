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
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Cashier cashier = null;
            string id = txtLogin.Text;
            string password = txtPassword.Text;

            LoginClient loginClient = new LoginClient();
            string token = loginClient.GetToken(id, password);
            

            if (token != null)
            {
                cashier = loginClient.Login(id, token);
            }

            if (cashier != null)
            {
                InitAppData(cashier);

                MainWindow mW = new MainWindow();
                mW.Show();
                this.Close();
            }           
        }

        private void InitAppData(Cashier cashier)
        {
            DataHandler data = DataHandler.GetInstance();

            data.Cashier = cashier;
            data.CashboxId = "777";
        }
    }
}
