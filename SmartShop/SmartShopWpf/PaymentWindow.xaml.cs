using SmartShopWpf.Data;
using SmartShopWpf.Models;
using SmartShopWpf.ReceipeMethods;
using System;
using System.Collections.Generic;
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

        public PaymentWindow(float dataTotalPrice, int dataId)
        {
            this.dataId = dataId;
            this.dataTotalPrice = dataTotalPrice;
            InitializeComponent();
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            TransactionManager tM = new TransactionManager();
            List<Transaction> transactions = new List<Transaction>();
            transactions = tM.GetTransactions();

            MainWindow mW = Owner as MainWindow;

            int idT = Convert.ToInt32(mW.lblTransactionNumber.Content.ToString().Trim());

            int index = 0;

            float amountPrceWithSIgleWihoutOverwall = 0;

            foreach (Basket b in mW.listVBasket.Items)
            {
                amountPrceWithSIgleWihoutOverwall = amountPrceWithSIgleWihoutOverwall + b.ChoseOptionPrice;
                index++;
            }

            foreach (Basket b in mW.listVBasket.Items)
            {
                MainWindow.listOfBoughtItems.Clear();
                MainWindow.listOfBoughtItems.Add(b);
            }

            float price = float.Parse(mW.lblAmount.Content.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            //  data.Transaction.TotalPrice = price / 100;

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
}