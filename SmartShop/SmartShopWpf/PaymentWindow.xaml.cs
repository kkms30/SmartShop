using SmartShopWpf.Data;
using SmartShopWpf.ReceipeMethods;
using System;
using System.Globalization;
using System.Windows;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public float dataTotalPrice;
        public int dataId;
        public bool flagToKindOfPayment = true;
      

        public PaymentWindow(float dataTotalPrice, int dataId)
        {
            this.dataId = dataId;
            this.dataTotalPrice = dataTotalPrice;
            InitializeComponent();
            lblToPayTag.Content = lblToPayTag.Content + " " + MainWindow.totalPriceToPaymentLabel;
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
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
            if (flagToKindOfPayment == true)
            {
                recp.kindOfPayment = "Gotowka";
            }
            else
            {
                recp.kindOfPayment = "Karta";
            }

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

        private void btnKinfOfPayment_Click(object sender, RoutedEventArgs e)
        {
            if (flagToKindOfPayment == true)
            {
                btnKinfOfPayment.Content = "Karta";
                flagToKindOfPayment = false;
            }
            else
            {
                btnKinfOfPayment.Content = "Gotówka";
                flagToKindOfPayment = true;
            }
        }
    }
}