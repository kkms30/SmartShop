using SmartShopWpf.Data;
using SmartShopWpf.ReceipeMethods;
using System;

using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public float dataTotalPrice;
        public int dataId;
        public bool flagToCard = false;
        public bool flagToCash = false;

        public PaymentWindow(float dataTotalPrice, int dataId)
        {
            this.dataId = dataId;
            this.dataTotalPrice = dataTotalPrice;       
            InitializeComponent();
            lblTitle.Content = lblTitle.Content + " " + dataTotalPrice.ToString();
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {

            if (flagToCash == false && flagToCard == false)
            {
                MessageBox.Show("Musisz wybrać sposób płatności");
            }

            else
            {
                MainWindow mW = Owner as MainWindow;

                float price = float.Parse(mW.lblAmount.Content.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                dataTotalPrice = price / 100;

                Receipe recp = new Receipe();
                //recp.TransactionNumber = data.Transaction.Id;
                recp.TransactionNumber = dataId;
                recp.Data = DateTime.Now;
                recp.listOfBoughtProducts = MainWindow.listOfBoughtItems;
                //recp.PriceSum = data.Transaction.TotalPrice;

                MessageBox.Show(dataTotalPrice.ToString());
                recp.PriceSum = dataTotalPrice;
                recp.CashNumber = Convert.ToInt32(mW.lblCashRegisterNumber.Content);
                recp.CashierNumber = Convert.ToInt32(mW.lblCashierNumber.Content);
                if (MainWindow.listOfDeletedItems.Count > 0)
                    recp.listOfDeletedProducts = MainWindow.listOfDeletedItems;
                ReceipePDFGenerator rPDFGen = new ReceipePDFGenerator(recp);
                rPDFGen.GeneratePDF();

                mW.listVBasket.Items.Clear();
                MainWindow.listOfBoughtItems.Clear();
                mW.lblAmount.Content = 0;
                mW.lblAmountWithoutDiscount.Content = 0;
                mW.lblTransactionNumber.Content = "";

                mW.btnEdit.IsEnabled = true;
                mW.btnVat.IsEnabled = true;

                this.Close();
            }
        }

        private void btnPayByCard_Click(object sender, RoutedEventArgs e)
        {
            flagToCard = true;
            flagToCash = false;
        }

        private void BtnPayByCash_Click(object sender, RoutedEventArgs e)
        {
            flagToCash = true;
            flagToCard = false;
        }

        public void CheckOneKindOfPayment()
        {
            if (flagToCard == true && flagToCash == false)
            {
                btnPayByCard.Background = new SolidColorBrush(Colors.White);
                btnPayByCash.Background = new SolidColorBrush(Colors.DarkOrange);
            }
            if (flagToCash == true && flagToCard == false)

            {
                btnPayByCash.Background = new SolidColorBrush(Colors.White);
                btnPayByCard.Background = new SolidColorBrush(Colors.DarkOrange);
            }
        }
    }
}