using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Windows.Media.Animation;

namespace projekt_jp_kkmr_v1._0
{
    public class OxyPlotModel_Uklad_Calkujacy : INotifyPropertyChanged
    {
        public OxyPlotModel_Uklad_Calkujacy(double Pojemnosc, double Rezystancja)
        {
            
            this.plotModel = new PlotModel { };
            // Przeliczniki
            double Rez_New = Rezystancja * 1000 ;
            double Poj_New = Pojemnosc * 0.000001;
            //Stała czasowa
            double RC = Rez_New * Poj_New; 

            //Wzory na wykresy
            if (Properties.Settings.Default.Wybor == 1)
            {
                plotModel.Title = "Charakterystyka: Amplitudowa";
                Func<double, double> Wykres_Frq = (x) => -20 * Math.Log10(Math.Sqrt(1+100*Math.Pow(x*RC,2))) ;


                this.plotModel.Series.Add(new FunctionSeries(Wykres_Frq, 0.0001, 1000, 0.01));
                
            }
            else if (Properties.Settings.Default.Wybor == 2)
            {
                plotModel.Title = "Charakterystyka: Fazowa";
                Func<double, double> Wykres_Fazowy = (x) => (-Math.Atan(RC * 10 * x)*180)/Math.PI;
                this.plotModel.Series.Add(new FunctionSeries(Wykres_Fazowy, 0.0001, 1000, 0.01));
            }
            else
            {
                plotModel.Title = "Charakterystyka:";
            }

            plotModel.Axes.Add(new LogarithmicAxis(AxisPosition.Bottom, 0.0001, 10000));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Left, -100, 0));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Right, -100, 0));
        }
        private OxyPlot.PlotModel plotModel;

        //Strona microsoft 
        public OxyPlot.PlotModel Calk_Model
        {
            get { return plotModel; }

            set
            {
                plotModel = value;
                OnPropertyChanged("Calk_Model");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
