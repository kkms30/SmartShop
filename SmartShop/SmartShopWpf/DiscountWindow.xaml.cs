using SmartShopWpf.Data;
using System;
using System.Windows;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for DiscountWindow.xaml
    /// </summary>
    public partial class DiscountWindow : Window
    {
        public static string OverwallDiscount;
        public static string SingleDiscount;
        public static float OverwallAmountWithDiscount; // Wartosc konkretnej kwoty po całosciowej znizce
        public static double OverwallDicountValue; // wartosc z txtBoxa

        public static string TypeOfDiscount;

        private bool _flagToTagTypeOfDiscount = true;

        public DiscountWindow()
        {
            InitializeComponent();
        }

        private void btnTypeOfDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (_flagToTagTypeOfDiscount)
            {
                btnTypeOfDiscount.Content = "zł";
                _flagToTagTypeOfDiscount = false;
            }
            else
            {
                btnTypeOfDiscount.Content = "%";
                _flagToTagTypeOfDiscount = true;
            }
        }

        private void btnAddDiscount_Click(object sender, RoutedEventArgs e)
        {
            double discountValueConverter = 0;

            try
            {
                discountValueConverter = Convert.ToDouble(txtDiscount.Text.Trim().ToString());
            }
            catch
            {
                MessageBox.Show("Zły Format Zniżki!");
            }

            float discountValue = (float) discountValueConverter;

            if (discountValue <= 0)
            {
                MessageBox.Show("Zniżka musi być większa niż 0!");
            }
            else
            {
                MainWindow mW = Owner as MainWindow;

                if (MainWindow.FlagToTagKindOfDiscount)
                {
                    foreach (Basket b in mW.listVBasket.Items)
                    {
                        b.OverwallDiscountName = discountValue.ToString() + btnTypeOfDiscount.Content;

                        MainWindow.FlagToOverwallDiscount = true;
                    }
                    OverwallDiscount = discountValue.ToString() + btnTypeOfDiscount.Content;

                    if (btnTypeOfDiscount.Content.ToString().Trim() == "%")
                    {
                        TypeOfDiscount = "%";
                        double percent = 100 - discountValue;
                        OverwallDicountValue = percent;
                        OverwallAmountWithDiscount =
                            (float) Math.Round((MainWindow.OverwallAmount * percent * 0.01), 2);
                        mW.UpdateDiscount();
                    }
                    else
                    {
                        TypeOfDiscount = "zl";
                        OverwallDicountValue = discountValue;
                        OverwallAmountWithDiscount = (float) Math.Round((MainWindow.OverwallAmount - discountValue), 2);
                        mW.UpdateDiscount();
                    }
                }
                else
                {
                    foreach (Basket b in mW.listVBasket.SelectedItems)
                    {
                        b.SigleDiscountName = discountValue.ToString() + btnTypeOfDiscount.Content;

                        if (btnTypeOfDiscount.Content.ToString().Trim() == "%")
                        {
                            double percent = 100 - discountValue;
                            if (b.BeforeDiscount != 0)
                            {
                                b.ChoseOptionPrice = (float) Math.Round((b.BeforeDiscount * percent * 0.01), 2);
                            }
                            else
                            {
                                b.BeforeDiscount = b.ChoseOptionPrice;
                                b.ChoseOptionPrice = (float) Math.Round((b.ChoseOptionPrice * percent * 0.01), 2);
                            }
                        }
                        else
                        {
                            if (b.BeforeDiscount != 0)
                            {
                                b.ChoseOptionPrice = b.BeforeDiscount - (discountValue * b.Count);
                            }
                            else
                            {
                                b.ChoseOptionPrice = b.ChoseOptionPrice - (discountValue * b.Count);
                            }
                        }
                    }

                    mW.UpdateSigleDiscount();
                }

                mW.listVBasket.Items.Refresh();
                this.Close();
            }
        }
    }
}