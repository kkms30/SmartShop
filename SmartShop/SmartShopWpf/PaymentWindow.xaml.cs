using SmartShopWpf.Data;
using SmartShopWpf.ReceipeMethods;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

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

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

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

            //dataTotalPrice = price / 100;
            dataTotalPrice = (float)Convert.ToDouble(MainWindow.totalPriceToPaymentLabel);

            Receipe recp = new Receipe();
            //recp.TransactionNumber = data.Transaction.Id;
            recp.TransactionNumber = dataId;
            recp.Data = DateTime.Now;
            recp.ListOfBoughtProducts = MainWindow.listOfBoughtItems;
            recp.PriceSum = dataTotalPrice;
            if (flagToKindOfPayment)
            {
                recp.KindOfPayment = "Gotowka";
            }
            else
            {
                recp.KindOfPayment = "Karta";
            }

            recp.PriceSum = dataTotalPrice;
            recp.CashNumber = Convert.ToInt32(mW.lblCashRegisterNumber.Content);
            recp.CashierNumber = Convert.ToInt32(mW.lblCashierNumber.Content);
            if (MainWindow.listOfDeletedItems.Count > 0)
                recp.ListOfDeletedProducts = MainWindow.listOfDeletedItems;
            ReceipePdfGenerator rPDFGen = new ReceipePdfGenerator(recp);
            rPDFGen.GeneratePdf();

            mW.listVBasket.Items.Clear();
            MainWindow.listOfBoughtItems.Clear();
            MainWindow.listOfDeletedItems.Clear();
            mW.lblAmount.Content = 0;
            mW.lblAmountWithoutDiscount.Content = 0;
            mW.lblTransactionNumber.Content = "";
            MainWindow.flagToOverwallDiscount = false;
            mW.btnEdit.IsEnabled = true;
            mW.btnVat.IsEnabled = true;

            this.Close();
        }

        private void btnKinfOfPayment_Click(object sender, RoutedEventArgs e)
        {
            if (flagToKindOfPayment)
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

        private void PaymentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}