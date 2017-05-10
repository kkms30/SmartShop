using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using PluginMockLogowanie;
using System.Windows;

namespace SmartShopWpf
{
    /// <summary>
    /// Interaction logic for OknoLogowania.xaml
    /// </summary>
    public partial class OknoLogowania : Window
    {
        DirectoryInfo di;
        public OknoLogowania()
        {
            InitializeComponent();
            di = new DirectoryInfo(".");
        }

        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtHaslo.Text.Trim();
           // bool checkLoginDataByPlugin = false;
             
            foreach (FileInfo fi in di.GetFiles("PluginMockLogowanie.dll"))
            {
                Assembly pluginAssembly = Assembly.LoadFrom(fi.FullName);
                foreach (Type pluginType in pluginAssembly.GetExportedTypes())
                {
                    if (pluginType.GetInterface(typeof(IMockLogowania).Name) != null)
                    {
                        IMockLogowania TypeLoadedFromPlugin = (IMockLogowania)Activator.CreateInstance(pluginType);
                        //checkLoginDataByPlugin = TypeLoadedFromPlugin.CheckLoginData(login,password);
                        if (TypeLoadedFromPlugin.CheckLoginData(login, password))
                        {
                            MainWindow mW = new MainWindow();
                            mW.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login or password. Please check the data", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
            }

        }
    }
}
