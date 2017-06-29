using SmartShopWpf.Asynchronous;
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
        public static bool FlagToTagKindOfDiscount = true;
        public static bool FlagToOverwallDiscount = false;
        public static string TotalPriceToPaymentLabel;
        public static int IdTransToReturn;
        public static float OverwallAmount;

        public static List<Basket> ListOfBoughtItems = new List<Basket>();
        public static List<Basket> ListOfDeletedItems = new List<Basket>();

        private bool _flagToTickAll = true;
        private bool _flagToTagForManuDisp = true;
        private bool _flagToVat = true;
        private bool _flagToEditQuantity = false;

        public object TabFormList { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            InitView();
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
            lblAmount.Content = DiscountWindow.OverwallAmountWithDiscount;
        }

        public void UpdateSigleDiscount()
        {
            DiscountWindow.OverwallAmountWithDiscount = 0;
            foreach (Basket b in listVBasket.Items)
            {
                DiscountWindow.OverwallAmountWithDiscount =
                    DiscountWindow.OverwallAmountWithDiscount + b.ChoseOptionPrice;
            }

            if (DiscountWindow.OverwallDiscount != null)
            {
                if (DiscountWindow.TypeOfDiscount == "%")
                {
                    double amount = DiscountWindow.OverwallAmountWithDiscount * DiscountWindow.OverwallDicountValue *
                                    0.01;
                    DiscountWindow.OverwallAmountWithDiscount = (float) Math.Round(amount, 2);
                }
                else
                {
                    double amount = DiscountWindow.OverwallAmountWithDiscount - DiscountWindow.OverwallDicountValue;
                    DiscountWindow.OverwallAmountWithDiscount = (float) Math.Round(amount, 2);
                }
            }
            else
            {
                DiscountWindow.OverwallAmountWithDiscount =
                    (float) Math.Round(DiscountWindow.OverwallAmountWithDiscount, 2);
            }

            OverwallAmount = DiscountWindow.OverwallAmountWithDiscount;
            lblAmount.Content = DiscountWindow.OverwallAmountWithDiscount;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listVBasket.SelectedItems.Count != 1)
            {
                MessageBox.Show("Musisz zaznaczyć jeden produkt");
            }

            else
            {
                Basket basketToEditHisQuantity = (Basket) listVBasket.SelectedItem;
                string tagForManuDisplCode = "Kod produktu";
                string tagForManuDisplQuan = "Ilość";
                bool ifFound = false;
                if (_flagToEditQuantity == false)
                {
                    lblManuallyTagOfCode.Content = tagForManuDisplQuan;
                    btnEdit.Content = "Potwierdz";
                    _flagToEditQuantity = true;
                    btnManuallyAdd.IsEnabled = false;
                }
                else
                {
                    if (txtManuallyCodeEntry.Text == "" || txtManuallyCodeEntry.Text == "0")
                    {
                        MessageBox.Show("Ilosc musi byc wieksza niż 0");
                    }
                    else
                    {
                        foreach (var v in ListOfBoughtItems)
                        {
                            if (v.Number == basketToEditHisQuantity.Number)
                            {
                                //Przekazujemy całą kwotę ze zniżkami
                                float Sum = float.Parse(lblAmount.Content.ToString());

                                //Od sumy odejmujemy cenę Orderu przed zniżką 
                                Sum -= v.BeforeDiscount;
                                float singlePrice = 0;

                                singlePrice = v.BeforeDiscount / v.Count;

                                //Ilość z Ręcznej klawiatury
                                v.Count = Convert.ToInt32(txtManuallyCodeEntry.Text);

                                basketToEditHisQuantity.Count = Convert.ToInt32(txtManuallyCodeEntry.Text);
                                v.BeforeDiscount = singlePrice * v.Count;


                                //Do sumy pdodajemy cenę Orderu przed zniżką
                                Sum += v.BeforeDiscount;

                                //Cena pojdeycznego Orderu = Cenie przed Zniżką
                                v.ChoseOptionPrice = v.BeforeDiscount;
                                basketToEditHisQuantity.ChoseOptionPrice = basketToEditHisQuantity.BeforeDiscount;
                                lblAmount.Content = Math.Round(Convert.ToDouble(Sum), 2);
                                lblAmountWithoutDiscount.Content = Math.Round(Convert.ToDouble(Sum), 2);


                                ifFound = true;
                                _flagToEditQuantity = false;
                                lblManuallyTagOfCode.Content = tagForManuDisplCode;
                                btnEdit.Content = "Edytuj";
                                btnManuallyAdd.IsEnabled = true;
                                txtManuallyCodeEntry.Text = "";
                            }
                        }
                    }

                    if (ifFound)
                    {
                        listVBasket.SelectedItem = basketToEditHisQuantity;
                        listVBasket.Items.Refresh();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<Basket> newList = new List<Basket>();
            foreach (var v in listVBasket.SelectedItems)
            {
                newList.Add((Basket) v);
            }
            float newSuma = float.Parse(lblAmount.Content.ToString());
            float newSumaWithoutDiscounts = float.Parse(lblAmountWithoutDiscount.Content.ToString());
            foreach (var v in newList)
            {
                if (v.OverwallDiscountName != null && v.OverwallDiscountName.Contains("%"))
                {
                    float overwallDiscountName =
                        float.Parse(v.OverwallDiscountName.Remove(v.OverwallDiscountName.Length - 1));
                    newSuma -= v.ChoseOptionPrice * (1 - (overwallDiscountName / 100));
                    newSumaWithoutDiscounts -= v.BeforeDiscount;
                }
                else if (v.OverwallDiscountName != null && v.OverwallDiscountName.Contains("zł"))
                {
                    float overwallDiscountName =
                        float.Parse(v.OverwallDiscountName.Remove(v.OverwallDiscountName.Length - 2));
                    newSuma = newSuma - v.ChoseOptionPrice;
                    newSumaWithoutDiscounts -= v.BeforeDiscount;
                }
                else
                {
                    newSuma -= v.ChoseOptionPrice;
                    newSumaWithoutDiscounts -= v.BeforeDiscount;
                }
                ListOfBoughtItems.Remove(v);
                listVBasket.Items.Remove(v);
                ListOfDeletedItems.Add(v);
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
            Product p = (Product) listVFromListListOfProducts.SelectedItem;
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

            if (_flagToTagForManuDisp)
            {
                string code = txtManuallyCodeEntry.Text.ToString().Trim();
                bool checkCode = manCod.CheckTheCode(code, data.Products);

                if (checkCode)
                {
                    lblManuallyTagOfCode.Content = tagForManuDisplQuan;
                    txtManuallyCodeEntry.Text = "";
                    _flagToTagForManuDisp = false;
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

                    if (_flagToVat)
                    {
                        basket.ChoseOptionPrice = manCod.BasketContainer.TotalPriceWithVat;
                        basket.BeforeDiscount = basket.ChoseOptionPrice;
                        OverwallAmount = (float) Math.Round((SumOfPrices + basket.ChoseOptionPrice), 2);
                        lblAmount.Content = OverwallAmount;
                        lblAmountWithoutDiscount.Content = lblAmount.Content;
                    }
                    else
                    {
                        basket.ChoseOptionPrice = manCod.BasketContainer.TotalPriceWithoutVat;
                        basket.BeforeDiscount = basket.ChoseOptionPrice;
                        OverwallAmount = (float) Math.Round(((float) SumOfPrices + basket.ChoseOptionPrice), 2);
                        lblAmount.Content = OverwallAmount;
                        lblAmountWithoutDiscount.Content = lblAmount.Content;
                    }

                    if (FlagToOverwallDiscount)
                    {
                        bool flagToChar = true;

                        string discountValue = "";
                        basket.OverwallDiscountName = DiscountWindow.OverwallDiscount;

                        char[] takeDisCount = DiscountWindow.OverwallDiscount.ToCharArray();
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

                        if (flagToChar)
                        {
                            DiscountWindow.OverwallAmountWithDiscount =
                                (float) Math.Round((OverwallAmount * percent), 2);
                            lblAmountWithoutDiscount.Content = OverwallAmount;
                            lblAmount.Content = DiscountWindow.OverwallAmountWithDiscount;
                        }
                        else if (!flagToChar)

                        {
                            DiscountWindow.OverwallAmountWithDiscount =
                                (float) (OverwallAmount - Convert.ToDouble(discountValue));
                            lblAmountWithoutDiscount.Content = OverwallAmount;
                            lblAmount.Content = DiscountWindow.OverwallAmountWithDiscount;
                        }
                    }
                    else
                    {
                        basket.DiscountValue = 0;
                    }

                    ListOfBoughtItems.Add(basket);
                    listVBasket.Items.Add(basket);
                    btnVat.IsEnabled = false;
                    lblManuallyTagOfCode.Content = tagForManuDisplCode;
                    _flagToTagForManuDisp = true;
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

        public float DiscountValueForOrders(float totalPriceWithSingleAndOverwallDiscount,
            float totalPriceWithSingleAndWithoutOverwallDiscount, float optionPriceOfSingleBasket)
        {
            float percentWithoutOverallDiscount, discountValue;

            percentWithoutOverallDiscount = (optionPriceOfSingleBasket * 100) /
                                            totalPriceWithSingleAndWithoutOverwallDiscount;
            discountValue = (percentWithoutOverallDiscount * totalPriceWithSingleAndOverwallDiscount) / 100;

            return discountValue;
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            DataHandler data = DataHandler.GetInstance();
            TotalPriceToPaymentLabel = lblAmount.Content.ToString();
            OverwallAmount = (float) Convert.ToDouble(TotalPriceToPaymentLabel);

            float amountWithSingleWithoutOverwall = 0;
            ListOfBoughtItems.Clear();

            foreach (Basket b in listVBasket.Items)
            {
                amountWithSingleWithoutOverwall = amountWithSingleWithoutOverwall + b.ChoseOptionPrice;
                ListOfBoughtItems.Add(b);
            }

            if (data.Transaction != null)
            {
                PaymentWindow pW = new PaymentWindow(data.Transaction.TotalPrice, data.Transaction.Id);

                foreach (Basket b in ListOfBoughtItems)
                {
                    b.DiscountValue = DiscountValueForOrders(OverwallAmount, amountWithSingleWithoutOverwall,
                        b.ChoseOptionPrice);
                }

                float price = float.Parse(lblAmount.Content.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                data.Transaction.TotalPrice = price / 100;

                new TransactionManager().AddOrdersToTransaction(ListOfBoughtItems);

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

            if (_flagToTickAll == true)
            {
                btnTickAll.Content = ContentUnTick;
                listVBasket.SelectAll();
                _flagToTickAll = false;
            }
            else
            {
                btnTickAll.Content = ContentTick;
                listVBasket.UnselectAll();
                _flagToTickAll = true;
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

            if (_flagToVat)
            {
                lblVat.Content = "";
                _flagToVat = false;

                foreach (Basket v in listVBasket.Items)
                {
                    v.ChoseOptionPrice = v.TotalPriceWithoutVat;
                    totalPrice = totalPrice + v.ChoseOptionPrice;
                }
                foreach (Basket v2 in ListOfBoughtItems)
                {
                    v2.ChoseOptionPrice = v2.TotalPriceWithoutVat;
                }

                listVBasket.Items.Refresh();
            }
            else
            {
                lblVat.Content = "VAT";
                _flagToVat = true;

                foreach (Basket v in listVBasket.Items)
                {
                    v.ChoseOptionPrice = v.TotalPriceWithVat;

                    totalPrice = totalPrice + v.ChoseOptionPrice;
                }
                foreach (Basket v2 in ListOfBoughtItems)
                {
                    v2.ChoseOptionPrice = v2.TotalPriceWithVat;
                }

                listVBasket.Items.Refresh();
            }

            OverwallAmount = (float) Math.Round(totalPrice, 2);
            lblAmount.Content = OverwallAmount;
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
                    FlagToTagKindOfDiscount = false;
                }
                else
                {
                    dW.lblKindOfDis.Content = "Zniżka Całościowa";
                    FlagToTagKindOfDiscount = true;
                }

                dW.Owner = this;
                dW.ShowDialog();
            }
        }

        private void btnReturnsSearch_Click(object sender, RoutedEventArgs e)
        {
            listVReturnsListOfProductsToReturn.Items.Clear();

            string idTransactionText = txtReturnsNumberOfTransaction.Text;
            int idTransaction = 0;

            try
            {
                idTransaction = Convert.ToInt32(idTransactionText);
            }
            catch
            {
                MessageBox.Show("Zły format");
            }

            ReturnSearchInvoker returnSearchInvoker = new ReturnSearchInvoker();
            returnSearchInvoker.ShowReturnedProducts(idTransaction, listVReturnsListOfProductsToReturn,
                informationLabel);
            informationLabel.Content = "Szukam transakcji...";
        }

        private void btnReturnsTickAll_Click(object sender, RoutedEventArgs e)
        {
            string ContentTick = "Zaznacz Wszystkie";
            string ContentUnTick = "Odznacz Wszystkie";

            if (_flagToTickAll == true)
            {
                btnReturnsTickAll.Content = ContentUnTick;
                listVReturnsListOfProductsToReturn.SelectAll();
                _flagToTickAll = false;
            }
            else
            {
                btnReturnsTickAll.Content = ContentTick;
                listVReturnsListOfProductsToReturn.UnselectAll();
                _flagToTickAll = true;
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
            bool alreadyReturned = false;

            List<ReturnObject> listReturns = new List<ReturnObject>();
            List<ReturnObject> listRecipeBeforeReturn = new List<ReturnObject>();
            float priceToReturn = 0;
            float totalPriceAfterReturn = 0;

            foreach (ReturnObject returnObject in listVReturnsListOfProductsToReturn.Items)
            {
                if (returnObject.ReturnedText.Equals("NIE"))
                {
                    listRecipeBeforeReturn.Add(returnObject);
                    totalPriceAfterReturn = totalPriceAfterReturn + (float) returnObject.Discount;
                }
            }

            foreach (ReturnObject returnObject in listVReturnsListOfProductsToReturn.SelectedItems)
            {
                if (returnObject.ReturnedText.Equals("TAK"))
                {
                    alreadyReturned = true;
                }

                listReturns.Add(returnObject);
                priceToReturn = priceToReturn + (float) returnObject.Discount;
                totalPriceAfterReturn = totalPriceAfterReturn - (float) returnObject.Discount;
            }

            if (listVReturnsListOfProductsToReturn.SelectedItems.Count >= 1)
            {
                if (!alreadyReturned)
                {
                    ReturnOrderInvoker returnOrderInvoker = new ReturnOrderInvoker(listReturns);
                    returnOrderInvoker.Return();

                    Receipe recp = new Receipe();
                    recp.TransactionNumber = IdTransToReturn;
                    recp.Data = DateTime.Now;
                    recp.ListOfAllOrdersInTransactionToReturn = listRecipeBeforeReturn;
                    recp.PriceToReturn = priceToReturn;
                    recp.PriceSum = totalPriceAfterReturn;
                    recp.CashNumber = Convert.ToInt32(lblCashRegisterNumber.Content);
                    recp.CashierNumber = Convert.ToInt32(lblCashierNumber.Content);

                    if (listReturns.Count > 0)
                        recp.ListOfReturnsOrders = listReturns;
                    ReturnPdfGenerator rPDFGen = new ReturnPdfGenerator(recp);
                    rPDFGen.GeneratePdf();

                    listVReturnsListOfProductsToReturn.Items.Clear();
                    txtReturnsNumberOfTransaction.Text = "";
                }
                else
                {
                    informationLabel.Content = "Produkt już został zwrócony";
                }
            }
            else
            {
                informationLabel.Content = "Wybierz Produkt do zwrotu!";
            }
        }
    }
}