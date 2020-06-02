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
    /// Interaction logic for MenuButton1_Window.xaml
    /// </summary>
    public partial class MenuButton1_Window : Window
    {
        public MenuButton1_Window()
        {
            InitializeComponent();
            WindowOnScreenLocation();
        }

        // Pozycojonowanie okna pod głównym oknem
        private void WindowOnScreenLocation()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;

            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        //Properties.Settings.Default      
        private void Suwak_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Przypisanie wartości z suwaka 
            Properties.Settings.Default.Napiecie = Suwak_Napiecie.Value;
            // Wyświetlanie 
            Napiecie_Sterowanie.Text = Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie));
            //Ustawienie wartości wykresu, 2)
            OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
            this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel
            //Wyświetlanie obliczonekj wartości prądu
            Prad.Text = Convert.ToString(1000 * Math.Round(Properties.Settings.Default.Napiecie / Properties.Settings.Default.Rezystancja, 4));
            Ur.Text = Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie, 4));
        }


        private void Suwak_ValueChanged_3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Rezystancja = Rez_Suwak.Value;
            Rezystancja_Sterowanie.Text = Convert.ToString(Math.Round(Properties.Settings.Default.Rezystancja));

            OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
            this.DataContext = oxyPlotModel;

            Prad.Text = Convert.ToString(1000 * Math.Round(Properties.Settings.Default.Napiecie / Properties.Settings.Default.Rezystancja, 6));
            Ur.Text = Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie, 4));
        }



        private void Suwak_ValueChanged_4(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Frq = Frq_Suwak.Value;
            Frq_Sterowanie.Text = Convert.ToString(Properties.Settings.Default.Frq);

            OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
            this.DataContext = oxyPlotModel;
        }
    }
}
