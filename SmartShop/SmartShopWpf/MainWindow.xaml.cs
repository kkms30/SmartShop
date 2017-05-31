using SmartShopWpf.Data;
using SmartShopWpf.Models;
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
        public static bool flagToTagKindOfDiscount = true;
        public static bool flagToOverwallDiscount = true;

        public static List<Basket> listOfBoughtItems = new List<Basket>();
        static public double overwallAmount;

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

        public void UpdateDiscount()
        {
            lblAmount.Content = DiscountWindow.overwallAmountWithDiscount;

         
        }

        public void UpdateSigleDiscount()
        {
            DiscountWindow.overwallAmountWithDiscount = 0;
            foreach (Basket b in listVBasket.Items)
            {
                DiscountWindow.overwallAmountWithDiscount = DiscountWindow.overwallAmountWithDiscount+ b.ChoseOptionPrice;
            }


            if(DiscountWindow.overwallDiscount!=null)
            {
                if(DiscountWindow.typeOfDis=="%")
                {
                    double amount = DiscountWindow.overwallAmountWithDiscount * DiscountWindow.OverwallDicountValue*0.01;
                    DiscountWindow.overwallAmountWithDiscount = Math.Round(amount,2);
                }

                else
                {
                    double amount = DiscountWindow.overwallAmountWithDiscount - DiscountWindow.OverwallDicountValue;
                    DiscountWindow.overwallAmountWithDiscount = Math.Round(amount, 2);
                }
            }
            lblAmount.Content = DiscountWindow.overwallAmountWithDiscount;
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
                    int counter = listVBasket.Items.Count;
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

                    double SumOfPrices = Convert.ToDouble(lblAmountWithoutDiscount.Content.ToString().Trim());

                    if (flagToVat == true)
                    {
                        basket.ChoseOptionPrice = manCod.basketContainer.TotalPriceWithVat;
                        basket.BeforeDiscount = basket.ChoseOptionPrice;
                        overwallAmount = Math.Round((SumOfPrices + basket.ChoseOptionPrice), 2);
                        lblAmount.Content = overwallAmount;
                        lblAmountWithoutDiscount.Content = lblAmount.Content;
                    }
                    else
                    {
                        basket.ChoseOptionPrice = manCod.basketContainer.TotalPriceWithoutVat;
                        basket.ChoseOptionPrice = basket.ChoseOptionPrice;
                        overwallAmount = Math.Round(((float)SumOfPrices + basket.ChoseOptionPrice), 2);
                        lblAmount.Content = overwallAmount;
                        lblAmountWithoutDiscount.Content = lblAmount.Content;
                    }

                    if (flagToOverwallDiscount == false)
                    {
                        bool flagToChar = true;

                        string discountValue = "";
                        basket.OverwallDiscountName = DiscountWindow.overwallDiscount;

                        char[] takeDisCount = DiscountWindow.overwallDiscount.ToCharArray();
                        foreach (char v in takeDisCount)
                        {
                            if (v == '%')
                            {
                                flagToChar = true;
                                break;
                            }
                            else if (v == 'z')
                            {
                                flagToChar = false;
                                break;
                            }

                            discountValue = discountValue + v;
                        }
                        double percent = (100 - Convert.ToDouble(discountValue)) * 0.01;

                        if (flagToChar == true)
                        {
                            DiscountWindow.overwallAmountWithDiscount = Math.Round((overwallAmount * percent), 2);                           
                            lblAmountWithoutDiscount.Content = overwallAmount;
                            lblAmount.Content = DiscountWindow.overwallAmountWithDiscount;
                        }
                        else if (flagToChar == false)

                        {
                            DiscountWindow.overwallAmountWithDiscount = overwallAmount - Convert.ToDouble(discountValue);
                            lblAmountWithoutDiscount.Content = overwallAmount;
                            lblAmount.Content = DiscountWindow.overwallAmountWithDiscount;
                        }
                    }

                    listOfBoughtItems.Add(basket);
                    listVBasket.Items.Add(basket);

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
            listOfBoughtItems.Clear();
            foreach(Basket b in listVBasket.Items)
            {
                listOfBoughtItems.Add(b);
            }
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
            listVBasket.Items.Clear();
            listOfBoughtItems.Clear();
            lblAmount.Content = 0;
            lblAmountWithoutDiscount.Content = 0;
        }

        private void btnTickAll_Click(object sender, RoutedEventArgs e)
        {
            string ContentTick = "Zaznacz Wszystkie";
            string ContentUnTick = "Odznacz Wszystkie";

            if (flagToTickAll == true)
            {
                btnTickAll.Content = ContentUnTick;
                listVBasket.SelectAll();
                flagToTickAll = false;
            }
            else
            {
                btnTickAll.Content = ContentTick;
                listVBasket.UnselectAll();
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

                foreach (Basket v in listVBasket.Items)
                {
                    v.ChoseOptionPrice = v.TotalPriceWithoutVat;
                    totalPrice = totalPrice + v.ChoseOptionPrice;
                }
                foreach (Basket v2 in listOfBoughtItems)
                {
                    v2.ChoseOptionPrice = v2.TotalPriceWithoutVat;
                }

                listVBasket.Items.Refresh();
            }
            else
            {
                lblVat.Content = "VAT";
                flagToVat = true;

                foreach (Basket v in listVBasket.Items)
                {
                    v.ChoseOptionPrice = v.TotalPriceWithVat;

                    totalPrice = totalPrice + v.ChoseOptionPrice;
                }
                foreach (Basket v2 in listOfBoughtItems)
                {
                    v2.ChoseOptionPrice = v2.TotalPriceWithVat;
                }

                listVBasket.Items.Refresh();
            }

            overwallAmount = Math.Round(totalPrice, 2);
            lblAmount.Content = overwallAmount;
            lblAmountWithoutDiscount.Content = lblAmount.Content;
        }

        private void btnDiscount_Click(object sender, RoutedEventArgs e)
        {
            btnVat.IsEnabled = false;

            if (listVBasket.Items.Count <= 0)
            {
                MessageBox.Show("Transakcja nie została rozpoczęta!");
            }
            else
            {
                int counter = 0;

                foreach (Basket b in listVBasket.SelectedItems)
                {
                    counter++;
                }

                DiscountWindow dW = new DiscountWindow();

                if (counter > 0)
                {
                    dW.lblKindOfDis.Content = "Zniżka Pojedyncza";
                    flagToTagKindOfDiscount = false;
                }
                else
                {
                    dW.lblKindOfDis.Content = "Zniżka Całościowa";
                    flagToTagKindOfDiscount = true;
                }

                dW.Owner = this;
                dW.ShowDialog();
            }
        }
    }
}