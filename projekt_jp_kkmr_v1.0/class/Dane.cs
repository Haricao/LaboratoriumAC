using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_jp_kkmr_v1._0
{
    public class Dane
    {
        
        public static double Napiecie { get; set; }
        public static double Rezystancja { get; set; }
        public static double Prad { get; set; }
        public static double Frq { get; set; }

        public Dane(double _napiecie, double _rezystancja, double _frq)
        {
            switch (Properties.Settings.Default.Wybor)
            {
                
                case 0:

                    Prad = _napiecie / (_rezystancja*1000);
                    

                    break;
                
                case 1:

                    Prad = _napiecie / (2 * Math.PI * _frq * (_rezystancja)); //Rezystancja = indukcyjnosc



                    break;

                case 2:

                    Prad = _napiecie * 2 * Math.PI * _frq * (_rezystancja/1000000);

                    break;
            }
            
        }
        
    }
}

