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
    public class OxyPlotModel_Uklad_Rozniczkujacy : INotifyPropertyChanged
    {
        public OxyPlotModel_Uklad_Rozniczkujacy(double Pojemnosc, double Rezystancja)
        {
            
            this.plotModel = new PlotModel { };

            double Rez_New = Rezystancja * 1000;
            double Poj_New = Pojemnosc * 0.000001;

            if (Properties.Settings.Default.Wybor == 1)
            {
                plotModel.Title = "Charakterystyka: Amplitudowa";
                Func<double, double> Wykres_Frq = (x) => 1 / (Math.Sqrt(1 + Math.Pow(2 * Math.PI * x, 2) * Math.Pow(Rez_New, 2) * Math.Pow(Poj_New, 2)));


                this.plotModel.Series.Add(new FunctionSeries(Wykres_Frq, 0, 1000, 0.1));
                
            }
            else if (Properties.Settings.Default.Wybor == 2)
            {
                plotModel.Title = "Charakterystyka: Fazowa";
                Func<double, double> Wykres_Fazowy = (x) => -Math.Atan(2 * Math.PI * Rez_New * Poj_New * x);
                this.plotModel.Series.Add(new FunctionSeries(Wykres_Fazowy, 0, 1000, 0.1));
            }
            else
            {
                plotModel.Title = "Charakterystyka:";
            }



            
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Bottom, 0, 1000));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Left, -2, 2));
        }
        private OxyPlot.PlotModel plotModel;

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
