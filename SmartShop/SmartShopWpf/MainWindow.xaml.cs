using SmartShop.CommunicateToWebService.Clients;
using SmartShopWpf.Asynchronous;
using SmartShopWpf.Data;
using SmartShopWpf.Models;
using SmartShopWpf.Models.Mappers;
using SmartShopWpf.ReceipeMethods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool flagToTickAll = true;
        private bool flagToTagForManuDisp = true;
        private bool flagToVat = true;
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

            new Top10Invoker().Download(listVTop10ListTop10);
            new DoneTransactionInvoker().Download(listVTransactions);
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
            Binding myBinding = new Binding();

            if (flagToTagForManuDisp == true)
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
                    Task taskOne = new Task(delegate
                    {
                        if (counter == 1)
                        {
                            new TransactionManager().PrepareNewTransaction();
                        }
                    });
                    taskOne.Start();

                    Basket basket = manCod.AddToBasketList(getCount, counter);

                    double SumOfPrices = Convert.ToDouble(lblAmount.Content.ToString().Trim());

                    if (flagToVat == true)
                    {
                        basket.ChoseOptionPrice = manCod.basketContainer.TotalPriceWithVat;
                        lblAmount.Content = ((float)SumOfPrices + basket.ChoseOptionPrice).ToString("0.00");
                    }
                    else
                    {
                        basket.ChoseOptionPrice = manCod.basketContainer.TotalPriceWithoutVat;
                        lblAmount.Content = ((float)SumOfPrices + basket.ChoseOptionPrice).ToString("0.00");
                    }

                    listOfBoughtItems.Add(basket);
                    lstVBacket.Items.Add(basket);

                    lblManuallyTagOfCode.Content = tagForManuDisplCode;
                    flagToTagForManuDisp = true;
                    txtManuallyCodeEntry.Text = "";

                    await taskOne.ContinueWith(_ =>
                    {
                        Dispatcher.BeginInvoke(new Action(delegate
                        {
                            lblTransactionNumber.Content = data.Transaction.Id;
                        }));
                        new TransactionManager().AddNewOrderToTransaction(ManuallyCode.GetInstance().checkedProduct, getCount);
                    });
                }
            }
        }


        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            DataHandler data = DataHandler.GetInstance();

            if (data.Transaction != null)
            {
                float price = float.Parse(lblAmount.Content.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                data.Transaction.TotalPrice = price / 100;

                Receipe recp = new Receipe();
                recp.TransactionNumber = data.Transaction.Id;
                recp.Data = DateTime.Now;
                recp.listOfBoughtProducts = listOfBoughtItems;
                recp.PriceSum = data.Transaction.TotalPrice;
                recp.CashNumber = Convert.ToInt32(lblCashRegisterNumber.Content);
                recp.CashierNumber = Convert.ToInt32(lblCashierNumber.Content);
                ReceipePDFGenerator rPDFGen = new ReceipePDFGenerator(recp);
                rPDFGen.GeneratePDF();
                lstVBacket.Items.Clear();
                listOfBoughtItems.Clear();
                lblAmount.Content = 0;
                lblTransactionNumber.Content = "";


                new TransactionFinalizationInvoker().FinalizeCurrentTransaction();
            }
            else
            {
                MessageBox.Show("Rozpocznij nową transakcje dodając produkt do zamówienia");
            }
           
        }


        private void tabService_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (tabTop10.IsSelected)
            {
                new Top10Invoker().Download(listVTop10ListTop10);
            }
            if (tabTransactions.IsSelected)
            {
                new DoneTransactionInvoker().Download(listVTransactions);
            }
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

        private void txtFromListProductName_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            DataHandler data = DataHandler.GetInstance();
            List<Product> RegularListWithAllProducts = data.Products;
            if (txtFromListProductName.Text == "" || txtFromListProductName.Text == " ")
            {
                listVFromListListOfProducts.ItemsSource = data.Products;
            }
            else
            {
                string beginOfSearchedWord = txtFromListProductName.Text.Trim();
                var query = RegularListWithAllProducts
                    .Where(x => x.Name.ToLower().Contains(beginOfSearchedWord.ToLower()));
                listVFromListListOfProducts.ItemsSource = query;
            }
        }
        private void btnVat_Click(object sender, RoutedEventArgs e)
        {
            float totalPrice = 0;

            if (flagToVat)
            {
                lblVat.Content = "";
                flagToVat = false;

                foreach (Basket v in lstVBacket.Items)
                {
                    foreach (Basket v2 in listOfBoughtItems)
                    {
                        v.ChoseOptionPrice = v.TotalPriceWithoutVat;
                        v2.ChoseOptionPrice = v2.TotalPriceWithoutVat;
                        totalPrice = totalPrice + v.ChoseOptionPrice;
                    }
                }


                lstVBacket.Items.Refresh();
            }
            else
            {

                lblVat.Content = "VAT";
                flagToVat = true;

                foreach (Basket v in lstVBacket.Items)
                {
                    foreach (Basket v2 in listOfBoughtItems)
                    {
                        v.ChoseOptionPrice = v.TotalPriceWithVat;
                        v2.ChoseOptionPrice = v2.TotalPriceWithVat;
                        totalPrice = totalPrice + v.ChoseOptionPrice;
                    }
                }

                lstVBacket.Items.Refresh();
            }

            lblAmount.Content = Math.Round(totalPrice, 2);

        }
    }
}