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
    /// Interaction logic for HelperWindow1.xaml
    /// </summary>
    public partial class HelperWindow1 : Window
    {
        public HelperWindow1()
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

        /* BLOK 1
         * Pomiar Rezystancji Rzeczywistej 
         * ************************************************RR
         * ************************************************RR
         */
        private void Suwak_ValueChanged_RR_V(object sender, RoutedPropertyChangedEventArgs<double> e)
        { 
            Properties.Settings.Default.Wybor = 0;
            if (Properties.Settings.Default.Wybor == 0)
            {
                Properties.Settings.Default.Napiecie = Suwak_Napiecie_RR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Uplywnosc );

                // Wyświetlanie     
                 
                //Ustawienie wartości wykresu, 2)
                OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
                this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel

                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS.Text = "Ic= "+Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4))+ " [µA]";
                Faza.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4))+ " °";

            }


        }

        private void Suwak_ValueChanged_RR_R(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 0;
            if (Properties.Settings.Default.Wybor == 0)
            {
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Uplywnosc);

                Properties.Settings.Default.Rezystancja = Rez_Suwak.Value;
                

                OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
                this.DataContext = oxyPlotModel;


                Z.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS.Text = "Ic= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " °";
            }

        }

        private void Suwak_ValueChanged_RR_T(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 0;
            if (Properties.Settings.Default.Wybor == 0)
            {
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Uplywnosc);
                Properties.Settings.Default.Frq = Frq_Suwak.Value;
                
                OxyPlotModel oxyPlotModel = new OxyPlotModel(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq);
                this.DataContext = oxyPlotModel;

                Z.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS.Text = "Ic= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " °";

            }

        }

        private void Suwak_ValueChanged_RR_P(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 0;
            if (Properties.Settings.Default.Wybor == 0)
            {
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Uplywnosc);
                Properties.Settings.Default.Pojemnosc = Suwak_Pojemnosc.Value;


                Z.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS.Text = "Ic= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " °";

            }

        }

        private void Suwak_ValueChanged_RR_L(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 0;
            if (Properties.Settings.Default.Wybor == 0)
            {
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie, Properties.Settings.Default.Rezystancja, Properties.Settings.Default.Frq, Properties.Settings.Default.Indukcyjnosc, Properties.Settings.Default.Pojemnosc, Properties.Settings.Default.Uplywnosc);
                Properties.Settings.Default.Indukcyjnosc = Suwak_Indukcyjnosc.Value;


                Z.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS.Text = "Ic= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " °";

            }

        }
        /**************CEWKA*******************************/
        private void Suwak_ValueChanged_LR_V(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 1;
            if (Properties.Settings.Default.Wybor == 1)
            {
                Properties.Settings.Default.Napiecie_L = Suwak_Napiecie_LR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Rezystancja_L, Properties.Settings.Default.Frq_L, Properties.Settings.Default.Indukcyjnosc_L, Properties.Settings.Default.Pojemnosc_L, Properties.Settings.Default.Uplywnosc);

                // Wyświetlanie     
               

                //Ustawienie wartości wykresu, 2)
                OxyPlotModel_Cewka oxyPlotModel = new OxyPlotModel_Cewka(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc_L, Properties.Settings.Default.Frq_L);
                this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel

                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_L.Text = "Z= " +  Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";
                
                Z_Modul_L.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS_L.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS_L.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS_L.Text = "Ic= "+Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza_L.Text = "ρ= "+ Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " [°]";

            }
        }

        private void Suwak_ValueChanged_LR_L(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            Properties.Settings.Default.Wybor = 1;
            if (Properties.Settings.Default.Wybor == 1)
            {
                Properties.Settings.Default.Indukcyjnosc_L = Suwak_Indukcyjnosc_LR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Rezystancja_L, Properties.Settings.Default.Frq_L, Properties.Settings.Default.Indukcyjnosc_L, Properties.Settings.Default.Pojemnosc_L, Properties.Settings.Default.Uplywnosc);

                // Wyświetlanie     
                

                //Ustawienie wartości wykresu, 2)
                OxyPlotModel_Cewka oxyPlotModel = new OxyPlotModel_Cewka(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc_L, Properties.Settings.Default.Frq_L);
                this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel

                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_L.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_L.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS_L.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS_L.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS_L.Text = "Ic= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza_L.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " [°]";

            }
        }

        private void Suwak_ValueChanged_LR_T(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 1;
            if (Properties.Settings.Default.Wybor == 1)
            {
                Properties.Settings.Default.Frq_L = Suwak_Frq_LR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Rezystancja_L, Properties.Settings.Default.Frq_L, Properties.Settings.Default.Indukcyjnosc_L, Properties.Settings.Default.Pojemnosc_L, Properties.Settings.Default.Uplywnosc);

                // Wyświetlanie     
               

                //Ustawienie wartości wykresu, 2)
                OxyPlotModel_Cewka oxyPlotModel = new OxyPlotModel_Cewka(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Indukcyjnosc_L, Properties.Settings.Default.Frq_L);
                this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel

                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_L.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_L.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS_L.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS_L.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS_L.Text = "Ic= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza_L.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " [°]";

            }

        }

        private void Suwak_ValueChanged_LR_R(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 1;
            if (Properties.Settings.Default.Wybor == 1)
            {
                Properties.Settings.Default.Rezystancja_L = Suwak_Rezystancja_LR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Rezystancja_L, Properties.Settings.Default.Frq_L, Properties.Settings.Default.Indukcyjnosc_L, Properties.Settings.Default.Pojemnosc_L, Properties.Settings.Default.Uplywnosc);

                // Wyświetlanie     




                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_L.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_L.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS_L.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS_L.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS_L.Text = "Ic= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza_L.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " [°]";

            }

        }

        private void Suwak_ValueChanged_LR_C(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 1;
            if (Properties.Settings.Default.Wybor == 1)
            {
                Properties.Settings.Default.Pojemnosc_L = Suwak_Pojemnosc_LR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_L, Properties.Settings.Default.Rezystancja_L, Properties.Settings.Default.Frq_L, Properties.Settings.Default.Indukcyjnosc_L, Properties.Settings.Default.Pojemnosc_L, Properties.Settings.Default.Uplywnosc);

                // Wyświetlanie     




                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_L.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 4)) + " + j" + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_L.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 4)) + " [Ω]";
                IRMS_L.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 4)) + " [A]";
                IRL_RMS_L.Text = "IRL= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 4)) + " [A]";
                IC_RMS_L.Text = "Ic= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 4)) + " [µA]";
                Faza_L.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 4)) + " [°]";

            }

        }


        /***********KONDENSATOR***********/
        private void Suwak_ValueChanged_CR_V(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Napiecie_C = Suwak_Napiecie_CR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Rezystancja_C, Properties.Settings.Default.Frq_C, Properties.Settings.Default.Indukcyjnosc_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Uplywnosc);

                //Ustawienie wartości wykresu, 2)
                OxyPlotModel_Kondensator oxyPlotModel = new OxyPlotModel_Kondensator(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Frq_C);
                this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel

                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_C.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 8)) + " + j " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_C.Text = "|Z|= " +Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 12)) + " [Ω]";
                IRMS_C.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 3)) + " [A]";
                IRL_RMS_C.Text = "IC= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 3)) + " [A]";
                IC_RMS_C.Text = "IR= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 3)) + " [µA]";
                Faza_C.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 3)) + " [°]";

            }

        }

        private void Suwak_ValueChanged_CR_C(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Pojemnosc_C = Suwak_Pojemnosc_CR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Rezystancja_C, Properties.Settings.Default.Frq_C, Properties.Settings.Default.Indukcyjnosc_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Uplywnosc);

                //Ustawienie wartości wykresu, 2)
                OxyPlotModel_Kondensator oxyPlotModel = new OxyPlotModel_Kondensator(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Frq_C);
                this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel

                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_C.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 8)) + " + j " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_C.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 12)) + " [Ω]";
                IRMS_C.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 3)) + " [A]";
                IRL_RMS_C.Text = "IC= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 3)) + " [A]";
                IC_RMS_C.Text = "IR= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 3)) + " [µA]";
                Faza_C.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 3)) + " [°]";

            }

        }

        private void Suwak_ValueChanged_CR_T(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Frq_C = Suwak_Frq_CR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Rezystancja_C, Properties.Settings.Default.Frq_C, Properties.Settings.Default.Indukcyjnosc_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Uplywnosc);

                //Ustawienie wartości wykresu, 2)
                OxyPlotModel_Kondensator oxyPlotModel = new OxyPlotModel_Kondensator(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Frq_C);
                this.DataContext = oxyPlotModel; // To pozwala połączyć kontrolki z polami klasy OxyPlotModel

                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_C.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 8)) + " + j " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_C.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 12)) + " [Ω]";
                IRMS_C.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 3)) + " [A]";
                IRL_RMS_C.Text = "IC= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 3)) + " [A]";
                IC_RMS_C.Text = "IR= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 3)) + " [µA]";
                Faza_C.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 3)) + " [°]";

            }

        }

        private void Suwak_ValueChanged_CR_R(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Rezystancja_C = Suwak_Rezystancja_CR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Rezystancja_C, Properties.Settings.Default.Frq_C, Properties.Settings.Default.Indukcyjnosc_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Uplywnosc);

                //Ustawienie wartości wykresu, 2)

                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_C.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 8)) + " + j " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_C.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 12)) + " [Ω]";
                IRMS_C.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 3)) + " [A]";
                IRL_RMS_C.Text = "IC= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 3)) + " [A]";
                IC_RMS_C.Text = "IR= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 3)) + " [µA]";
                Faza_C.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 3)) + " [°]";

            }
        }
        private void Suwak_ValueChanged_CR_L(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Indukcyjnosc_C = Suwak_Indukcyjnosc_CR.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Rezystancja_C, Properties.Settings.Default.Frq_C, Properties.Settings.Default.Indukcyjnosc_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Uplywnosc);


                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_C.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 8)) + " + j " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_C.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 12)) + " [Ω]";
                IRMS_C.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 3)) + " [A]";
                IRL_RMS_C.Text = "IC= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 3)) + " [A]";
                IC_RMS_C.Text = "IR= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 3)) + " [µA]";
                Faza_C.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 3)) + " [°]";
            }
        }


        private void Suwak_ValueChanged_CR_U(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Properties.Settings.Default.Wybor = 2;
            if (Properties.Settings.Default.Wybor == 2)
            {
                Properties.Settings.Default.Uplywnosc = Suwak_Uplywnosc.Value;

                // Przepisanie danych do klasy Dane
                Dane_Rzeczywisty dane = new Dane_Rzeczywisty(Properties.Settings.Default.Napiecie_C, Properties.Settings.Default.Rezystancja_C, Properties.Settings.Default.Frq_C, Properties.Settings.Default.Indukcyjnosc_C, Properties.Settings.Default.Pojemnosc_C, Properties.Settings.Default.Uplywnosc);


                //Wyświetlanie obliczonekj wartości OBLICZONYCH
                Z_C.Text = "Z= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja, 8)) + " + j " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Impedancja_Urojona, 8)) + " [Ω]";

                Z_Modul_C.Text = "|Z|= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Modul_Z, 12)) + " [Ω]";
                IRMS_C.Text = "I= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irms, 3)) + " [A]";
                IRL_RMS_C.Text = "IC= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Irl_rms, 3)) + " [A]";
                IC_RMS_C.Text = "IR= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Ic_rms, 3)) + " [µA]";
                Faza_C.Text = "ρ= " + Convert.ToString(Math.Round(Dane_Rzeczywisty.Faza, 3)) + " [°]";

            }

        }
    }
}
