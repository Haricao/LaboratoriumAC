using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_jp_kkmr_v1._0
{

    class Dane_Rzeczywisty
    {
        public static double Impedancja { get; set; }
        public static double Impedancja_Urojona { get; set; }
        public static double Modul_Z { get; set; }
        public static double Rezystancja_R { get; set; }

        public static double Irms { get; set; }
        public static double Ic_rms { get; set; }
        public static double Irl_rms { get; set; }

        public static double Ir_rms { get; set; }

        public static double Z_1 { get; set; }
        public static double Czesc_urojona { get; set; }
        public static double Faza { get; set; }

        public Dane_Rzeczywisty(double _napiecie, double _rezystancja, double _frq, double _indukcyjnosc, double _pojemnosc, double _uplywnosc)
        {
            switch (Properties.Settings.Default.Wybor)
            {

                case 0:

                    //Dla rezystancji rzeczywistej

                    //R - Omy, C - piko, Indukcyjnosc - nano

                    double _pojemnosc_mnoznik = _pojemnosc * 10e-12;
                    double _indukcyjnosc_mnoznik = _indukcyjnosc * 10e-9;

                    Impedancja = (_rezystancja / Math.Pow(2 * Math.PI * _frq * _pojemnosc_mnoznik, 2)) / (Math.Pow(_rezystancja, 2) + Math.Pow(2 * Math.PI * _frq * _indukcyjnosc_mnoznik, 2) - (2 * _indukcyjnosc_mnoznik / _pojemnosc_mnoznik) + (1 / Math.Pow(2 * Math.PI * _frq * _pojemnosc_mnoznik, 2))) * 0.1;
                    Impedancja_Urojona = ((_indukcyjnosc_mnoznik / (2 * Math.PI * _frq * Math.Pow(_pojemnosc_mnoznik, 2))) - (2 * Math.PI * _frq * Math.Pow(_indukcyjnosc_mnoznik, 2) / _pojemnosc_mnoznik) - (Math.Pow(_rezystancja, 2) / 2 * Math.PI * _frq * _pojemnosc_mnoznik)) / (Math.Pow(_rezystancja, 2) + Math.Pow(2 * Math.PI * _frq * _indukcyjnosc_mnoznik, 2) - (2 * _indukcyjnosc_mnoznik / _pojemnosc_mnoznik) + (1 / Math.Pow(2 * Math.PI * _frq * _pojemnosc_mnoznik, 2)));
                    Modul_Z = Math.Sqrt(Math.Pow(Impedancja, 2) + Math.Pow(Impedancja_Urojona, 2));
                    Rezystancja_R = Impedancja;

                    Irms = _napiecie / Modul_Z;
                    Z_1 = Math.Sqrt((Math.Pow(_rezystancja, 2) + Math.Pow(2 * Math.PI * _frq * _indukcyjnosc_mnoznik, 2))) * 0.1; // j(?)
                    Ic_rms = (Irms - Irl_rms);
                    Irl_rms = _napiecie / Z_1;



                    Faza = Math.Atan(Impedancja_Urojona / Impedancja);
                    break;

                case 1:

                    //Dla pojemności rzeczywistej

                    //Pousuwać potem zbędne nawiasy

                    double _uplywnosc_mnoznik1 = _uplywnosc * 10e6;
                    double _indukcyjnosc_mnoznik1 = _indukcyjnosc * 10e-9;
                    double _pojemnosc_mnoznik1 = _pojemnosc * 10e-6;



                    Impedancja = ((_uplywnosc_mnoznik1 / (2 * Math.PI * _frq * Math.Pow(_pojemnosc_mnoznik1, 2))) / (Math.Pow(_uplywnosc_mnoznik1, 2) + (1 / Math.Pow(_pojemnosc_mnoznik1 * 2 * _frq * Math.PI, 2))) + _rezystancja);



                    Impedancja_Urojona = ((2 * Math.PI * _frq * _indukcyjnosc_mnoznik1) - ((Math.Pow(_uplywnosc_mnoznik1, 2) / 2 * Math.PI * _frq * _pojemnosc_mnoznik1)) / (Math.Pow(_uplywnosc_mnoznik1, 2) + (1 / (Math.Pow(2 * Math.PI * _frq * _pojemnosc_mnoznik1, 2)))));

                    Modul_Z = Math.Sqrt(Math.Pow(Impedancja, 2) + Math.Pow(Impedancja_Urojona, 2));

                    Rezystancja_R = Impedancja;

                    Irms = _napiecie / Modul_Z;

                    Ic_rms = _napiecie * 2 * Math.PI * _frq * _pojemnosc_mnoznik1;

                    Ir_rms = _napiecie / _uplywnosc_mnoznik1;

                    Faza = 360 - (Math.Atan(Impedancja / Impedancja_Urojona));




                    break;

                case 2:

                    //Dla indukcyjności rzeczywistej 

                    double _pojemnosc_mnoznik2 = _pojemnosc * 10e-12;
                    double _indukcyjnosc_mnoznik2 = _indukcyjnosc * 10e-3;

                    Impedancja = (_rezystancja / Math.Pow(2 * Math.PI * _frq * _pojemnosc_mnoznik2, 2)) / (Math.Pow(_rezystancja, 2) + Math.Pow(2 * Math.PI * _frq * _indukcyjnosc_mnoznik2, 2) - (2 * _indukcyjnosc_mnoznik2 / _pojemnosc_mnoznik2) + (1 / Math.Pow(2 * Math.PI * _frq * _pojemnosc_mnoznik2, 2))) * 0.1;
                    Impedancja_Urojona = ((_indukcyjnosc_mnoznik2 / (2 * Math.PI * _frq * Math.Pow(_pojemnosc_mnoznik2, 2))) - (2 * Math.PI * _frq * Math.Pow(_indukcyjnosc_mnoznik2, 2) / _pojemnosc_mnoznik2) - (Math.Pow(_rezystancja, 2) / 2 * Math.PI * _frq * _pojemnosc_mnoznik2)) / (Math.Pow(_rezystancja, 2) + Math.Pow(2 * Math.PI * _frq * _indukcyjnosc_mnoznik2, 2) - (2 * _indukcyjnosc_mnoznik2 / _pojemnosc_mnoznik2) + (1 / Math.Pow(2 * Math.PI * _frq * _pojemnosc_mnoznik2, 2)));
                    Modul_Z = Math.Sqrt(Math.Pow(Impedancja, 2) + Math.Pow(Impedancja_Urojona, 2));
                    Rezystancja_R = Impedancja;
                    Irms = _napiecie / Modul_Z;
                    Irl_rms = _napiecie / Z_1;
                    Ic_rms = _napiecie * 2 * Math.PI * _frq * _pojemnosc_mnoznik2;

                    Z_1 = Math.Sqrt((Math.Pow(_rezystancja, 2) + Math.Pow(2 * Math.PI * _frq * _indukcyjnosc_mnoznik2, 2))); // j(?)

                    Faza = (Math.Atan(Impedancja_Urojona / Impedancja));



                    break;
            }

        }

    }
}
