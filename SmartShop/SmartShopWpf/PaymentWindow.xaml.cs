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
        private const int GwlStyle = -16;
        private const int WsSysmenu = 0x80000;

        public float dataTotalPrice;
        public int dataId;
        public bool flagToKindOfPayment = true;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public PaymentWindow(float dataTotalPrice, int dataId)
        {
            this.dataId = dataId;
            this.dataTotalPrice = dataTotalPrice;
            InitializeComponent();
            lblToPayTag.Content = lblToPayTag.Content + " " + MainWindow.TotalPriceToPaymentLabel;
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Owner as MainWindow;

            float price = float.Parse(mainWindow.lblAmount.Content.ToString(),
                CultureInfo.InvariantCulture.NumberFormat);

            //dataTotalPrice = price / 100;
            dataTotalPrice = (float) Convert.ToDouble(MainWindow.TotalPriceToPaymentLabel);

            Receipe receipe = new Receipe();
            //recp.TransactionNumber = data.Transaction.Id;
            receipe.TransactionNumber = dataId;
            receipe.Data = DateTime.Now;
            receipe.ListOfBoughtProducts = MainWindow.ListOfBoughtItems;
            receipe.PriceSum = dataTotalPrice;
            if (flagToKindOfPayment)
            {
                receipe.KindOfPayment = "Gotowka";
            }
            else
            {
                receipe.KindOfPayment = "Karta";
            }

            receipe.PriceSum = dataTotalPrice;
            receipe.CashNumber = Convert.ToInt32(mainWindow.lblCashRegisterNumber.Content);
            receipe.CashierNumber = Convert.ToInt32(mainWindow.lblCashierNumber.Content);
            if (MainWindow.ListOfDeletedItems.Count > 0)
                receipe.ListOfDeletedProducts = MainWindow.ListOfDeletedItems;
            ReceipePdfGenerator receipePdfGenerator = new ReceipePdfGenerator(receipe);
            receipePdfGenerator.GeneratePdf();

            mainWindow.listVBasket.Items.Clear();
            MainWindow.ListOfBoughtItems.Clear();
            MainWindow.ListOfDeletedItems.Clear();
            mainWindow.lblAmount.Content = 0;
            mainWindow.lblAmountWithoutDiscount.Content = 0;
            mainWindow.lblTransactionNumber.Content = "";
            MainWindow.FlagToOverwallDiscount = false;
            mainWindow.btnEdit.IsEnabled = true;
            mainWindow.btnVat.IsEnabled = true;

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
            SetWindowLong(hwnd, GwlStyle, GetWindowLong(hwnd, GwlStyle) & ~WsSysmenu);
        }
    }
}