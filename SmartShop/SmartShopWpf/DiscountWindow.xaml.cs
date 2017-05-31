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
        private bool flagToTagTypeOfDiscount = true;
        static public string overwallDiscount;
        static public string singleDiscount;

        static public double overwallAmountWithDiscount; // Wartosc konkretnej kwoty po całosciowej znizce
        static public double OverwallDicountValue; // wartosc z txtBoxa
        
        static public string typeOfDis;

        public DiscountWindow()
        {
            InitializeComponent();
        }

        private void btnTypeOfDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (flagToTagTypeOfDiscount)
            {
                lblKindOfDis.Content = "Zniżka Kwotowa";
                btnTypeOfDiscount.Content = "zł";
                flagToTagTypeOfDiscount = false;
            }
            else
            {
                lblKindOfDis.Content = "Zniżka Procentowa";
                btnTypeOfDiscount.Content = "%";
                flagToTagTypeOfDiscount = true;
            }
        }

        private void btnAddDiscount_Click(object sender, RoutedEventArgs e)
        {
            double discountValueConverter = 0;

            try { discountValueConverter = Convert.ToDouble(txtDiscount.Text.Trim().ToString()); }
            catch { MessageBox.Show("Zły Format Zniżki!"); }

            float discountValue = (float)discountValueConverter;

            if (discountValue <= 0)
            {
                MessageBox.Show("Zniżka musi być większa niż 0!");
            }
            else
            {
                MainWindow mW = Owner as MainWindow;

                if (MainWindow.flagToTagKindOfDiscount)
                {
                    foreach (Basket b in mW.listVBasket.Items)
                    {
                        b.OverwallDiscountName = discountValue.ToString() + btnTypeOfDiscount.Content;

                        MainWindow.flagToOverwallDiscount = false;
                    }
                    overwallDiscount = discountValue.ToString() + btnTypeOfDiscount.Content;

                    if (btnTypeOfDiscount.Content.ToString().Trim() == "%")
                    {
                        typeOfDis = "%";
                        double percent = 100 - discountValue;
                        OverwallDicountValue = percent;
                        overwallAmountWithDiscount = Math.Round((MainWindow.overwallAmount * percent * 0.01), 2);
                        mW.UpdateDiscount();
                    }
                    else
                    {
                        typeOfDis = "zl";
                        OverwallDicountValue = discountValue;
                        overwallAmountWithDiscount = Math.Round((MainWindow.overwallAmount - discountValue), 2);
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
                            b.ChoseOptionPrice =(float)Math.Round((MainWindow.overwallAmount * percent * 0.01), 2);
                        }
                        else
                        {
                            b.ChoseOptionPrice = b.ChoseOptionPrice - discountValue;
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