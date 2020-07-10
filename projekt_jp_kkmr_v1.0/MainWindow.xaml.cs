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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projekt_jp_kkmr_v1._0
{
    //Klasa glowna MainWindow.xaml
    public partial class MainWindow : Window
    {
        // Glowne wywolanie okna
        public MainWindow()
        {
            InitializeComponent();
        }


        //zmienne
        private bool HelperButton1_ClickBoolean;
        private bool HelperButton2_ClickBoolean;
        private bool HelperButton3_ClickBoolean;
        private bool HelperButton4_ClickBoolean;


        //Funckje
        public void HelperButton1_ClickBooleanClicked()
        {
            HelperButton1_ClickBoolean = !HelperButton1_ClickBoolean;
        }

        public void HelperButton2_ClickBooleanClicked()
        {
            HelperButton2_ClickBoolean = !HelperButton2_ClickBoolean;
        }

        public void HelperButton3_ClickBooleanClicked()
        {
            HelperButton3_ClickBoolean = !HelperButton3_ClickBoolean;
        }

        public void HelperButton4_ClickBooleanClicked()
        {
            HelperButton4_ClickBoolean = !HelperButton4_ClickBoolean;
        }

        //Przyciski MenuButton
        //
        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            //Wybór wykresu
            Properties.Settings.Default.Napiecie = 0;
            Properties.Settings.Default.Indukcyjnosc_L = 0;
            Properties.Settings.Default.Rezystancja = 0;
            Properties.Settings.Default.Frq = 0;
            Properties.Settings.Default.Pojemnosc = 0;
            Properties.Settings.Default.Indukcyjnosc_C = 0;
            Properties.Settings.Default.Napiecie_C = 0;
            Properties.Settings.Default.Napiecie_L = 0;
            Properties.Settings.Default.Frq_C = 0;
            Properties.Settings.Default.Pojemnosc_L = 0;
            Properties.Settings.Default.Frq_L = 0;
            Properties.Settings.Default.Indukcyjnosc = 0;
            Properties.Settings.Default.Wybor = 0;
            MenuButton1_Window button1_Window = new MenuButton1_Window();
            button1_Window.Show();
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Napiecie = 0;
            Properties.Settings.Default.Indukcyjnosc_L = 0;
            Properties.Settings.Default.Rezystancja = 0;
            Properties.Settings.Default.Frq = 0;
            Properties.Settings.Default.Pojemnosc = 0;
            Properties.Settings.Default.Indukcyjnosc_C = 0;
            Properties.Settings.Default.Napiecie_C = 0;
            Properties.Settings.Default.Napiecie_L = 0;
            Properties.Settings.Default.Frq_C = 0;
            Properties.Settings.Default.Pojemnosc_L = 0;
            Properties.Settings.Default.Frq_L = 0;
            Properties.Settings.Default.Indukcyjnosc = 0;
            Properties.Settings.Default.Wybor = 0;
            HelperWindow1 button2_Window = new HelperWindow1();
            button2_Window.Show();
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Napiecie = 0;
            Properties.Settings.Default.Indukcyjnosc_L = 0;
            Properties.Settings.Default.Rezystancja = 0;
            Properties.Settings.Default.Frq = 0;
            Properties.Settings.Default.Pojemnosc = 0;
            Properties.Settings.Default.Indukcyjnosc_C = 0;
            Properties.Settings.Default.Napiecie_C = 0;
            Properties.Settings.Default.Napiecie_L = 0;
            Properties.Settings.Default.Frq_C = 0;
            Properties.Settings.Default.Pojemnosc_L = 0;
            Properties.Settings.Default.Frq_L = 0;
            Properties.Settings.Default.Indukcyjnosc = 0;
            Properties.Settings.Default.Wybor = 0;
            MenuButton3_Window button3_Window = new MenuButton3_Window();
            button3_Window.Show();

        }

        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton9_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuButton10_Click(object sender, RoutedEventArgs e)
        {

        }



        //Przyciski MenuHelper

        public void HelperButton1_Click(object sender, RoutedEventArgs e)
        {
            HelperButton1_ClickBooleanClicked();

            if (HelperButton1_ClickBoolean == true)
            {
                LabGrid.Visibility = Visibility.Visible;
                ProgInfo.Visibility = Visibility.Hidden;
                AuthorInfo.Visibility = Visibility.Hidden;
                HelperButton2_ClickBoolean = false;
                HelperButton3_ClickBoolean = false;
            }
            else
            {
                LabGrid.Visibility = Visibility.Hidden;
                HelperButton2_ClickBoolean = false;
                HelperButton3_ClickBoolean = false;
            }

           
        }

        private void HelperButton2_Click(object sender, RoutedEventArgs e)
        {
            HelperButton2_ClickBooleanClicked();

            if (HelperButton2_ClickBoolean == true)
            {
                ProgInfo.Visibility = Visibility.Visible;
                LabGrid.Visibility = Visibility.Hidden;
                AuthorInfo.Visibility = Visibility.Hidden;
                HelperButton1_ClickBoolean = false;
                HelperButton3_ClickBoolean = false;
            }
            else
            {
                ProgInfo.Visibility = Visibility.Hidden;
                HelperButton1_ClickBoolean = false;
                HelperButton3_ClickBoolean = false;
            }

        }

        private void HelperButton3_Click(object sender, RoutedEventArgs e)
        {
            HelperButton3_ClickBooleanClicked();

            if (HelperButton3_ClickBoolean == true)
            {
                AuthorInfo.Visibility = Visibility.Visible;
                LabGrid.Visibility = Visibility.Hidden;
                ProgInfo.Visibility = Visibility.Hidden;
                HelperButton1_ClickBoolean = false;
                HelperButton2_ClickBoolean = false;
            }
            else
            {
                AuthorInfo.Visibility = Visibility.Hidden;
                HelperButton1_ClickBoolean = false;
                HelperButton2_ClickBoolean = false;
            }


        }

        private void HelperButton4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }

}
