using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projekt_jp_kkmr_v1._0
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class MenuButton3_Window : Window
    {
        public MenuButton3_Window()
        {
            InitializeComponent();
            WindowOnScreenLocation();

        }
        private void WindowOnScreenLocation()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;

            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void Rezystancja_Suwak_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            Properties.Settings.Default.Rezystancja = Rezystancja_Suwak.Value;
            OxyPlotModel_Uklad_Rozniczkujacy oxyPlotModel = new OxyPlotModel_Uklad_Rozniczkujacy(Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Pojemnosc);
            this.DataContext = oxyPlotModel; 

            


        }

        private void Pojemnosc_Suwak_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            Properties.Settings.Default.Pojemnosc = Pojemnosc_Suwak.Value;
            OxyPlotModel_Uklad_Rozniczkujacy oxyPlotModel = new OxyPlotModel_Uklad_Rozniczkujacy(Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Pojemnosc);
            this.DataContext = oxyPlotModel; 

            

        }

        private void Zmiana_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Wybor = 1;
            OxyPlotModel_Uklad_Rozniczkujacy oxyPlotModel = new OxyPlotModel_Uklad_Rozniczkujacy(Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Pojemnosc);
            this.DataContext = oxyPlotModel;
        }

        private void Zmiana2_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Wybor = 2;
            OxyPlotModel_Uklad_Rozniczkujacy oxyPlotModel = new OxyPlotModel_Uklad_Rozniczkujacy(Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Pojemnosc);
            this.DataContext = oxyPlotModel;
        }
    }
}
