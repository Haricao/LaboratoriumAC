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
            Properties.Settings.Default.Wybor = 0;
            if (Properties.Settings.Default.Wybor == 0)
            {
                Properties.Settings.Default.Napiecie = Suwak_Napiecie.Value;

                // Przepisanie danych do klasy Dane
                Dane dane = new Dane(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);

               

                //Ustawienie wartości wykresu, 2)
                OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
                this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel

                //Wyświetlanie obliczonekj wartości prądu
                Prad.Text = "IR= " + Convert.ToString(1000 * Math.Round(Dane.Prad, 4)) + " [mA]";
                Ur.Text = "UR= " + Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie, 4)) + " [V]";
            }
            
        }


        private void Suwak_ValueChanged_3(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 0;
            if (Properties.Settings.Default.Wybor == 0)
            {
                Dane dane = new Dane(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);

                Properties.Settings.Default.Rezystancja = Rez_Suwak.Value;
                

                OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
                this.DataContext = oxyPlotModel;

                Prad.Text = "IR= "+Convert.ToString(1000 * Math.Round(Dane.Prad, 4))+" [mA]";
                Ur.Text = "UR= "+Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie, 4))+" [V]";
            }
        }
        



        private void Suwak_ValueChanged_4(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 0;
            if (Properties.Settings.Default.Wybor == 0)
            {
                Dane dane = new Dane(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
                Properties.Settings.Default.Frq = Frq_Suwak.Value;
              

                OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
                this.DataContext = oxyPlotModel;
            }
        }

        private void Suwak_ValueChanged_LV(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 1;
            if (Properties.Settings.Default.Wybor == 1)
            {
                Properties.Settings.Default.Napiecie_L = Suwak_Napiecie_L.Value;
                Dane dane = new Dane(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Frq_L);

                OxyPlotModel_Cewka oxyPlotModel = new OxyPlotModel_Cewka(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Frq_L);
                this.DataContext = oxyPlotModel;

                Prad_L.Text = "IL= " + Convert.ToString(1000 * Math.Round(Dane.Prad, 4)) + " [A]";
                Ur_L.Text = "UL= " + Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie_L, 4)) + " [V]";
            }

        }

        private void Suwak_ValueChanged_LP(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 1;
            if (Properties.Settings.Default.Wybor == 1)
            {
                Properties.Settings.Default.Indukcyjnosc = Suwak_Indukcyjnosc.Value;
                Dane dane = new Dane(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Frq_L);


                OxyPlotModel_Cewka oxyPlotModel = new OxyPlotModel_Cewka(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Frq_L);
                this.DataContext = oxyPlotModel;

                
                Prad_L.Text = "IL= " + Convert.ToString(Math.Round(Dane.Prad, 4)) + " [A]";
                Ur_L.Text = "UL= " + Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie_L, 4)) + " [V]";
            }

        }

        private void Suwak_ValueChanged_LF(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 1;
            if (Properties.Settings.Default.Wybor == 1)
            {
                Properties.Settings.Default.Frq_L = Suwak_Frq_L.Value;
                Dane dane = new Dane(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Frq_L);


                OxyPlotModel_Cewka oxyPlotModel = new OxyPlotModel_Cewka(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Frq_L);
                this.DataContext = oxyPlotModel;

                Prad_L.Text = "IL= " + Convert.ToString(1000 * Math.Round(Dane.Prad, 4)) + " [A]";
                Ur_L.Text = "UR= " + Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie_L, 4)) + " [V]";
            }

        }

        private void Suwak_ValueChanged_KV(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Napiecie_C = Suwak_Napiecie_C.Value;
                Dane dane = new Dane(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Frq_C);


                OxyPlotModel_Kondensator oxyPlotModel = new OxyPlotModel_Kondensator(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Frq_C);
                this.DataContext = oxyPlotModel;

                Prad_C.Text = "Ic= " + Convert.ToString(1000 * Math.Round(Dane.Prad, 4)) + " [mA]";
                Ur_C.Text = "Uc= " + Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie_C, 4)) + " [V]";

            }
        }

        private void Suwak_ValueChanged_KP(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Pojemnosc = Suwak_Pojemnosc.Value;

                Dane dane = new Dane(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Frq_C);


                OxyPlotModel_Kondensator oxyPlotModel = new OxyPlotModel_Kondensator(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Frq_C);
                this.DataContext = oxyPlotModel;

                Prad_C.Text = "Ic= " + Convert.ToString(1000 * Math.Round(Dane.Prad, 4)) + " [mA]";
                Ur_C.Text = "Uc= " + Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie_C, 4)) + " [V]";


            }

        }

        private void Suwak_ValueChanged_KF(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Frq_C = Suwak_Frq_C.Value;


                Dane dane = new Dane(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Frq_C);


                OxyPlotModel_Kondensator oxyPlotModel = new OxyPlotModel_Kondensator(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Frq_C);
                this.DataContext = oxyPlotModel;

                Prad_C.Text = "Ic= " + Convert.ToString(1000 * Math.Round(Dane.Prad, 4)) + " [mA]";
                Ur_C.Text = "Uc= " + Convert.ToString(Math.Round(Properties.Settings.Default.Napiecie_C, 4)) + " [V]";
            }

        }

       
    }
}
