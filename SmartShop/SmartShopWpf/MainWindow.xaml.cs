using SmartShopWpf.Data;
using SmartShopWpf.Models;
using SmartShopWpf.ReceipeMethods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool flagToTickAll = true;
        private bool flagToTagForManuDisp = true;
        private List<Basket> listOfBoughtItems = new List<Basket>();

        public MainWindow(bool withPlugin)
        {
            InitializeComponent();

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

            listVFromListListOfProducts.ItemsSource = data.Products;

            lblCashierNumber.Content = data.Cashier.Id;
            lblCashRegisterNumber.Content = data.Cashbox.Id;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow oL = new LoginWindow();
            oL.Show();
            this.Close();
        }

        private void btnManually1_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "1";
            }
        }

        private void btnManually2_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "2";
            }
        }

        private void btnManually3_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "3";
            }
        }

        private void btnManually4_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "4";
            }
        }

        private void btnManually5_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "5";
            }
        }

        private void btnManually6_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "6";
            }
        }

        private void btnManually7_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "7";
            }
        }

        private void btnManually8_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "8";
            }
        }

        private void btnManually9_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "9";
            }
        }

        private void btnManually0_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent.Length < 9)
            {
                txtManuallyCodeEntry.Text = txtManuallyCodeEntry.Text + "0";
            }
        }

        private void btnManuallyC_Click(object sender, RoutedEventArgs e)
        {
            txtManuallyCodeEntry.Text = "";
        }

        private void btnManuallyBackspace_Click(object sender, RoutedEventArgs e)
        {
            string currentmanuallyCodeEntryContent = txtManuallyCodeEntry.Text.ToString();

            if (currentmanuallyCodeEntryContent != "")
            {
                string sub = currentmanuallyCodeEntryContent.Substring(0, currentmanuallyCodeEntryContent.Length - 1);

                if (currentmanuallyCodeEntryContent.Length > 1)
                {
                    txtManuallyCodeEntry.Text = sub;
                }
                else
                {
                    txtManuallyCodeEntry.Text = "";
                }
            }
        }

        private void btnFromListAdd_Click(object sender, RoutedEventArgs e)
        {
            Product p = (Product)listVFromListListOfProducts.SelectedItem;
            txtManuallyCodeEntry.Text = p.Code.ToString();
            tabService.SelectedItem = tabManually;
        }

        private async void btnManuallyAdd_Click(object sender, RoutedEventArgs e)
        {
            string tagForManuDisplCode = "Kod produktu";
            string tagForManuDisplQuan = "Ilość";
            ManuallyCode manCod = ManuallyCode.GetInstance();
            DataHandler data = DataHandler.GetInstance();

            if (flagToTagForManuDisp==true)
            {
                string code = txtManuallyCodeEntry.Text.ToString().Trim();
                bool checkCode = manCod.CheckTheCode(code, data.Products);

                if (checkCode == true)
                {
                    lblManuallyTagOfCode.Content = tagForManuDisplQuan;
                    txtManuallyCodeEntry.Text = "";
                    flagToTagForManuDisp = false;
                }
                else
                {
                    MessageBox.Show("Zły Kod!");
                }
            }
            else
            {
                if (txtManuallyCodeEntry.Text == "0" || txtManuallyCodeEntry.Text == "")
                {
                    MessageBox.Show("Dodałeś 0 produktów :)");
                }
                else
                {
                    int getCount = Convert.ToInt32(txtManuallyCodeEntry.Text.Trim());
                    int counter = lstVBacket.Items.Count;
                    counter++;
                    Task taskOne = new Task(delegate { 
                    if (counter == 1)
                    {
                        new TransactionManager().PrepareNewTransaction();
                    }
                    });
                    taskOne.Start();
                    listOfBoughtItems.Add(manCod.AddToBasketList(getCount, counter));
                    lstVBacket.Items.Add(manCod.AddToBasketList(getCount, counter));
                    float SumOfPrices = float.Parse(lblAmount.Content.ToString().Trim(), CultureInfo.InvariantCulture);

                    lblAmount.Content = SumOfPrices + ManuallyCode.GetInstance().basketContainer.Price;
                    lblManuallyTagOfCode.Content = tagForManuDisplCode;

                    flagToTagForManuDisp = true;

                    txtManuallyCodeEntry.Text = "";
                    await taskOne.ContinueWith(_=> {
                        Dispatcher.BeginInvoke(new Action(delegate { 
                    lblTransactionNumber.Content = data.Transaction.Id;
                        }));
                        new TransactionManager().AddNewOrderToTransaction(ManuallyCode.GetInstance().checkedProduct, getCount);
                    });


                }
            }
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            new TransactionManager().FinalizeTransaction();

            Receipe recp = new Receipe();
            recp.TransactionNumber = 5555;
            recp.Data = DateTime.Now;
            recp.listOfBoughtProducts = listOfBoughtItems;
            recp.PriceSum = float.Parse(lblAmount.Content.ToString(), CultureInfo.InvariantCulture);
            recp.CashNumber = Convert.ToInt32(lblCashRegisterNumber.Content);
            recp.CashierNumber = Convert.ToInt32(lblCashierNumber.Content);
            ReceipePDFGenerator rPDFGen = new ReceipePDFGenerator(recp);
            rPDFGen.GeneratePDF();
            lstVBacket.Items.Clear();
            listOfBoughtItems.Clear();
            lblAmount.Content = 0;
        }

        private void btnTickAll_Click(object sender, RoutedEventArgs e)
        {
            string ContentTick = "Zaznacz Wszystkie";
            string ContentUnTick = "Odznacz Wszystkie";

            if (flagToTickAll == true)
            {
                btnTickAll.Content = ContentUnTick;
                lstVBacket.SelectAll();
                flagToTickAll = false;
            }
            else
            {
                btnTickAll.Content = ContentTick;
                lstVBacket.UnselectAll();
                flagToTickAll = true;
            }
        }
    }
}