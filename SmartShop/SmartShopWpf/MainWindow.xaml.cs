using SmartShopWpf.Asynchronous;
using SmartShopWpf.Data;
using SmartShopWpf.Models;
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
        private bool flagToEditQuantity = false;
        public static bool flagToTagKindOfDiscount = true;
        public static bool flagToOverwallDiscount = false;
        public static string totalPriceToPaymentLabel;

        public static List<Basket> listOfBoughtItems = new List<Basket>();

        static public float overwallAmount;

        public static List<Basket> listOfDeletedItems = new List<Basket>();

        public object tabFormList { get; private set; }

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

        public void UpdateDiscount()
        {
            lblAmount.Content = DiscountWindow.overwallAmountWithDiscount;
        }

        public void UpdateSigleDiscount()
        {
            DiscountWindow.overwallAmountWithDiscount = 0;
            foreach (Basket b in listVBasket.Items)
            {
                DiscountWindow.overwallAmountWithDiscount = DiscountWindow.overwallAmountWithDiscount + b.ChoseOptionPrice;
            }

            if (DiscountWindow.overwallDiscount != null)
            {
                if (DiscountWindow.typeOfDis == "%")
                {
                    double amount = DiscountWindow.overwallAmountWithDiscount * DiscountWindow.OverwallDicountValue * 0.01;
                    DiscountWindow.overwallAmountWithDiscount = (float)Math.Round(amount, 2);
                }
                else
                {
                    double amount = DiscountWindow.overwallAmountWithDiscount - DiscountWindow.OverwallDicountValue;
                    DiscountWindow.overwallAmountWithDiscount = (float)Math.Round(amount, 2);
                }
            }
            else
            {
                DiscountWindow.overwallAmountWithDiscount = (float)Math.Round(DiscountWindow.overwallAmountWithDiscount, 2);
            }

            overwallAmount = DiscountWindow.overwallAmountWithDiscount;
            lblAmount.Content = DiscountWindow.overwallAmountWithDiscount;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Basket basketToEditHisQuantity = (Basket)listVBasket.SelectedItem;
            string tagForManuDisplCode = "Kod produktu";
            string tagForManuDisplQuan = "Ilość";
            bool ifFound = false;
            if (flagToEditQuantity == false)
            {
                lblManuallyTagOfCode.Content = tagForManuDisplQuan;
                btnEdit.Content = "Potwierdz";
                flagToEditQuantity = true;
                btnManuallyAdd.IsEnabled = false;
            }
            else
            {
                foreach (var v in listOfBoughtItems)
                {
                    if (v.Number == basketToEditHisQuantity.Number)
                    {
                        float Sum = float.Parse(lblAmount.Content.ToString());
                        Sum -= v.BeforeDiscount;
                        float SinglePrice = v.BeforeDiscount / v.Count;
                        v.Count = Convert.ToInt32(txtManuallyCodeEntry.Text);
                        basketToEditHisQuantity.Count = Convert.ToInt32(txtManuallyCodeEntry.Text);
                        v.BeforeDiscount = SinglePrice * v.Count;
                        Sum += v.BeforeDiscount;
                        v.ChoseOptionPrice = v.BeforeDiscount;
                        basketToEditHisQuantity.ChoseOptionPrice = basketToEditHisQuantity.BeforeDiscount;
                        lblAmount.Content = Math.Round(Convert.ToDouble(Sum), 2);
                        lblAmountWithoutDiscount.Content = Math.Round(Convert.ToDouble(Sum), 2);
                        ifFound = true;
                        flagToEditQuantity = false;
                        lblManuallyTagOfCode.Content = tagForManuDisplCode;
                        btnEdit.Content = "Edytuj";
                        btnManuallyAdd.IsEnabled = true;
                        txtManuallyCodeEntry.Text = "0";
                    }
                }
                if (ifFound == true)
                {
                    listVBasket.SelectedItem = basketToEditHisQuantity;
                    listVBasket.Items.Refresh();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<Basket> newList = new List<Basket>();
            foreach (var v in listVBasket.SelectedItems)
            {
                newList.Add((Basket)v);
            }
            float newSuma = float.Parse(lblAmount.Content.ToString());
            float newSumaWithoutDiscounts = float.Parse(lblAmountWithoutDiscount.Content.ToString());
            foreach (var v in newList)
            {
                if (v.OverwallDiscountName != null && v.OverwallDiscountName.Contains("%"))
                {
                    float OverwallDiscountName = float.Parse(v.OverwallDiscountName.Remove(v.OverwallDiscountName.Length - 1));
                    newSuma -= v.ChoseOptionPrice * (1 - (OverwallDiscountName / 100));
                    newSumaWithoutDiscounts -= v.BeforeDiscount;
                }
                else if (v.OverwallDiscountName != null && v.OverwallDiscountName.Contains("zł"))
                {
                    float OverwallDiscountName = float.Parse(v.OverwallDiscountName.Remove(v.OverwallDiscountName.Length - 2));
                    newSuma = newSuma - v.ChoseOptionPrice;
                    newSumaWithoutDiscounts -= v.BeforeDiscount;
                }
                else
                {
                    newSuma -= v.ChoseOptionPrice;
                    newSumaWithoutDiscounts -= v.BeforeDiscount;
                }
                listOfBoughtItems.Remove(v);
                listVBasket.Items.Remove(v);
                listOfDeletedItems.Add(v);
            }
            lblAmount.Content = Math.Round(Convert.ToDouble(newSuma), 2);
            lblAmountWithoutDiscount.Content = Math.Round(Convert.ToDouble(newSumaWithoutDiscounts), 2);
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
            tabFromList.IsEnabled = true;
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
                    tabFromList.IsEnabled = false;
                   
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
                        overwallAmount = (float)Math.Round((SumOfPrices + basket.ChoseOptionPrice), 2);
                        lblAmount.Content = overwallAmount;
                        lblAmountWithoutDiscount.Content = lblAmount.Content;
                    }
                    else
                    {
                        basket.ChoseOptionPrice = manCod.basketContainer.TotalPriceWithoutVat;

                        basket.ChoseOptionPrice = basket.ChoseOptionPrice;
                        overwallAmount = (float)Math.Round(((float)SumOfPrices + basket.ChoseOptionPrice), 2);
                        lblAmount.Content = overwallAmount;
                        lblAmountWithoutDiscount.Content = lblAmount.Content;
                    }

                    if (flagToOverwallDiscount == true)
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
                            DiscountWindow.overwallAmountWithDiscount = (float)Math.Round((overwallAmount * percent), 2);
                            lblAmountWithoutDiscount.Content = overwallAmount;
                            lblAmount.Content = DiscountWindow.overwallAmountWithDiscount;
                        }
                        else if (flagToChar == false)

                        {
                            DiscountWindow.overwallAmountWithDiscount = (float)(overwallAmount - Convert.ToDouble(discountValue));
                            lblAmountWithoutDiscount.Content = overwallAmount;
                            lblAmount.Content = DiscountWindow.overwallAmountWithDiscount;
                        }
                    }
                    else
                    {
                        basket.DiscountValue = 0;
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
                    });
                }
            }
        }

        public float DiscountValueForOrders(float totalPriceWithSingleAndOverwallDiscount, float totalPriceWithSingleAndWithoutOverwallDiscount, float optionPriceOfSingleBasket)
        {
            float percentWithoutOverallDiscount, discountValue;

            percentWithoutOverallDiscount = (optionPriceOfSingleBasket * 100) / totalPriceWithSingleAndWithoutOverwallDiscount;
            discountValue = (percentWithoutOverallDiscount * totalPriceWithSingleAndOverwallDiscount) / 100;

            return discountValue;
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            DataHandler data = DataHandler.GetInstance();
            totalPriceToPaymentLabel = lblAmount.Content.ToString();

            float amountWithSingleWithoutOverwall = 0;
            listOfBoughtItems.Clear();

            foreach (Basket b in listVBasket.Items)
            {
                amountWithSingleWithoutOverwall = amountWithSingleWithoutOverwall + b.ChoseOptionPrice;
                listOfBoughtItems.Add(b);
            }

            if (data.Transaction != null)
            {
                PaymentWindow pW = new PaymentWindow(data.Transaction.TotalPrice, data.Transaction.Id);

                foreach (Basket b in listOfBoughtItems)
                {
                    b.DiscountValue = DiscountValueForOrders(overwallAmount, amountWithSingleWithoutOverwall, b.ChoseOptionPrice);
                }

                float price = float.Parse(lblAmount.Content.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                data.Transaction.TotalPrice = price / 100;

                new TransactionManager().AddOrdersToTransaction(listOfBoughtItems);

                new TransactionFinalizationInvoker().FinalizeCurrentTransaction();

                pW.Owner = this;
                pW.ShowDialog();
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

            overwallAmount = (float)Math.Round(totalPrice, 2);
            lblAmount.Content = overwallAmount;
            lblAmountWithoutDiscount.Content = lblAmount.Content;
        }

        private void btnDiscount_Click(object sender, RoutedEventArgs e)
        {
            btnVat.IsEnabled = false;
            btnEdit.IsEnabled = false;
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

        private void btnReturnsSearch_Click(object sender, RoutedEventArgs e)
        {
            listVReturnsListOfProductsToReturn.Items.Clear();
            TransactionManager tM = new TransactionManager();
            List<Transaction> transactions = tM.GetTransactions();
            List<Order> orders = new List<Order>();
            int idT = 0;

            string getIdTFromTxt = txtReturnsNumberOfTransaction.Text;

            try { idT = Convert.ToInt32(getIdTFromTxt); }
            catch { MessageBox.Show("Zły format"); }

            foreach (Transaction t in transactions)
            {
                if (t.Id == idT)
                {
                    MessageBox.Show(t.Id.ToString());
                    foreach (Order o in t.Orders)
                    {
                        orders.Add(o);
                    }

                    break;
                }
            }

            int counter = 0;
            foreach (Order o in orders)
            {
                counter++;

                ReturnObject rO = new ReturnObject { IdOrder = o.IdOrder, Number = counter, Name = o.Product.Name, Image = o.Product.Image, Count = o.Count, Price = o.Product.Price, Discount = o.Discount };
                listVReturnsListOfProductsToReturn.Items.Add(rO);
            }
        }

        private void btnReturnsTickAll_Click(object sender, RoutedEventArgs e)
        {
            string ContentTick = "Zaznacz Wszystkie";
            string ContentUnTick = "Odznacz Wszystkie";

            if (flagToTickAll == true)
            {
                btnReturnsTickAll.Content = ContentUnTick;
                listVReturnsListOfProductsToReturn.SelectAll();
                flagToTickAll = false;
            }
            else
            {
                btnReturnsTickAll.Content = ContentTick;
                listVReturnsListOfProductsToReturn.UnselectAll();
                flagToTickAll = true;
            }
        }

        private void dailyReportBtn_Click(object sender, RoutedEventArgs e)
        {
            new DailyReportInvoker().Download();
        }

        private void monthlyReportBtn_Click(object sender, RoutedEventArgs e)
        {
            new MonthlyReportInvoker().Download();
        }

        private void btnReturnsReturn_Click(object sender, RoutedEventArgs e)
        {
            List<ReturnObject> listReturns = new List<ReturnObject>();
            foreach (ReturnObject returnObject in listVReturnsListOfProductsToReturn.SelectedItems)
            {
                MessageBox.Show(returnObject.IdOrder.ToString() + " " + returnObject.Count.ToString());
                listReturns.Add(returnObject);
            }

            ReturnOrderInvoker returnOrderInvoker = new ReturnOrderInvoker(listReturns);
            returnOrderInvoker.Return();
            listVReturnsListOfProductsToReturn.Items.Clear();
            txtReturnsNumberOfTransaction.Text = "";
        }
    }
}