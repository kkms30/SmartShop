using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using SmartShopWpf.Data;
using SmartShopWpf.ReceipeMethods;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        private const int GwlStyle = -16;
        private const int WsSysmenu = 0x80000;

        private float _dataTotalPrice;
        private int _dataId;
        private bool _flagToKindOfPayment = true;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public PaymentWindow(float dataTotalPrice, int dataId)
        {
            _dataId = dataId;
            _dataTotalPrice = dataTotalPrice;
            InitializeComponent();
            lblToPayTag.Content = lblToPayTag.Content + " " + MainWindow.TotalPriceToPaymentLabel;
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            HandleBtnPayClick();
        }

        private void btnKinfOfPayment_Click(object sender, RoutedEventArgs e)
        {
            HandleBtnKindOfPaymentClick();
        }

        private void HandleBtnPayClick()
        {
            MainWindow mainWindow = Owner as MainWindow;

            float price = float.Parse(mainWindow.lblAmount.Content.ToString(),
                CultureInfo.InvariantCulture.NumberFormat);

            _dataTotalPrice = (float) Convert.ToDouble(MainWindow.TotalPriceToPaymentLabel);

            GenerateReceipe(mainWindow);
            InvokeResultsOnMainWindow(mainWindow);

            Close();
        }

        private void InvokeResultsOnMainWindow(MainWindow mainWindow)
        {
            mainWindow.listVBasket.Items.Clear();
            MainWindow.ListOfBoughtItems.Clear();
            MainWindow.ListOfDeletedItems.Clear();
            mainWindow.lblAmount.Content = 0;
            mainWindow.lblAmountWithoutDiscount.Content = 0;
            mainWindow.lblTransactionNumber.Content = "";
            MainWindow.FlagToOverwallDiscount = false;
            mainWindow.btnEdit.IsEnabled = true;
            mainWindow.btnVat.IsEnabled = true;
        }

        private void GenerateReceipe(MainWindow mainWindow)
        {
            Receipe receipe = new Receipe
            {
                TransactionNumber = _dataId,
                Data = DateTime.Now,
                ListOfBoughtProducts = MainWindow.ListOfBoughtItems,
                PriceSum = _dataTotalPrice,
                KindOfPayment = _flagToKindOfPayment ? "Gotowka" : "Karta"
            };

            receipe.PriceSum = _dataTotalPrice;
            receipe.CashNumber = Convert.ToInt32(mainWindow.lblCashRegisterNumber.Content);
            receipe.CashierNumber = Convert.ToInt32(mainWindow.lblCashierNumber.Content);
            if (MainWindow.ListOfDeletedItems.Count > 0)
                receipe.ListOfDeletedProducts = MainWindow.ListOfDeletedItems;
            ReceipePdfGenerator receipePdfGenerator = new ReceipePdfGenerator(receipe);
            receipePdfGenerator.GeneratePdf();
        }

        private void HandleBtnKindOfPaymentClick()
        {
            if (_flagToKindOfPayment)
            {
                btnKinfOfPayment.Content = "Karta";
                _flagToKindOfPayment = false;
            }
            else
            {
                btnKinfOfPayment.Content = "Gotówka";
                _flagToKindOfPayment = true;
            }
        }

        private void PaymentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GwlStyle, GetWindowLong(hwnd, GwlStyle) & ~WsSysmenu);
        }
    }
}