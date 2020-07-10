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
    public class OxyPlotModel_Uklad_Rozniczkujacy_Faza : INotifyPropertyChanged
    {
        public OxyPlotModel_Uklad_Rozniczkujacy_Faza(double Pojemnosc, double Rezystancja)
        {

            this.plotModel = new PlotModel { };

            double Rez_New = Rezystancja * 1000;
            double Poj_New = Pojemnosc * 0.000001;


            
            Func<double, double> Wykres_Fazowy = (x) => -Math.Atan(2 * Math.PI * Rez_New * Poj_New * x);

            
            this.plotModel.Series.Add(new FunctionSeries(Wykres_Fazowy, 0, 1000, 0.1));


            plotModel.Axes.Add(new LogarithmicAxis(AxisPosition.Bottom, 0, 1000));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Left, -2, 0));
        }
        private OxyPlot.PlotModel plotModel;

        public OxyPlot.PlotModel Calk_Model_Faza
        {
            get { return plotModel; }

            set
            {
                plotModel = value;
                OnPropertyChanged("Calk_Model_Faza");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
