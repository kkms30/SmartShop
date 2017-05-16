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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string manuallyCodeEntryContent = "  0";


        public MainWindow(bool withPlugin)
        {
            InitializeComponent();
            lblManuallyCodeEntry.Content = manuallyCodeEntryContent;

            if (!withPlugin)
            {
                InitView();
            }            
        }

        private void InitView()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            lblDate.Content = dateTime.ToString("dd/MM/yyyy");

            DataHandler data = DataHandler.GetInstance();

            List<Product> products = data.Products;

            lblCashierNumber.Content = data.Cashier.Id;
            lblCashRegisterNumber.Content = data.CashboxId;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow oL = new LoginWindow();
            oL.Show();
            this.Close();
        }      

        private void btnManually1_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }

                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "1";
            }
        }

        private void btnManually2_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "2";
            }
        }

        private void btnManually3_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "3";
            }
        }

        private void btnManually4_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "4";
            }
        }

        private void btnManually5_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "5";
            }

        }

        private void btnManually6_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "6";
            }
        }

        private void btnManually7_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "7";
            }
        }

        private void btnManually8_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "8";
            }
        }

        private void btnManually9_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {

                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "9";
            }
        }

        private void btnManually0_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                if (currentmanuallyCodeEntryContent == manuallyCodeEntryContent)
                {
                    lblManuallyCodeEntry.Content = "";
                }
                lblManuallyCodeEntry.Content = lblManuallyCodeEntry.Content + "0";
            }
        }

        private void btnManuallyC_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent != manuallyCodeEntryContent)
            {
                lblManuallyCodeEntry.Content = manuallyCodeEntryContent;
            }

        }

        private void btnManuallyBackspace_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = lblManuallyCodeEntry.Content.ToString();

            if (currentmanuallyCodeEntryContent != manuallyCodeEntryContent)
            {
                string sub = currentmanuallyCodeEntryContent.Substring(0, currentmanuallyCodeEntryContent.Length - 1);

                if (currentmanuallyCodeEntryContent.Length > 1)
                {
                    lblManuallyCodeEntry.Content = sub;
                }
                else
                {
                    lblManuallyCodeEntry.Content = manuallyCodeEntryContent;
                }
            }
        }       
    }
}
