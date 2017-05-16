using SmartShop.CommunicateToWebService;
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
    /// Interaction logic for OknoLogowania.xaml
    /// </summary>
    public partial class OknoLogowania : Window
    {
        public OknoLogowania()
        {
            InitializeComponent();
            txtLogin.Text = "5";
            txtHaslo.Text = "test";
        }

        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mW = new MainWindow();
            //mW.Show();
            //this.Close();
            LoginClient client = new LoginClient();
            string token = client.GetToken(txtLogin.Text, txtHaslo.Text);
            Cashier cashier = client.Login(txtLogin.Text, token);
            
            if (cashier != null)
            {
                MessageBox.Show("Dziala!");
            }
        }
    }
}
