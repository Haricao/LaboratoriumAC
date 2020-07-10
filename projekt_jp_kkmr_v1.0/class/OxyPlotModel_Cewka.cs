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

namespace projekt_jp_kkmr_v1._0
{
    public class OxyPlotModel_Cewka : INotifyPropertyChanged
    {
        public OxyPlotModel_Cewka(double Napiecie, double Indukcyjnosc, double Frq)
        {
            this.plotModel = new PlotModel { };

            Func<double, double> Wykres_Nap = (x) => Math.Sqrt(2) * (Napiecie / 2.3) * (Math.Sin(x * (Frq / 160) + (Math.PI / 2)));
            Func<double, double> Wykres_Prad = (x) => Math.Sqrt(2) * (Napiecie / (Indukcyjnosc/10)) * Math.Sin(x * (Frq / 160));

            //Ustawienie zakresu rysowania funkcja, start, koniec"
            this.plotModel.Series.Add(new FunctionSeries(Wykres_Nap, 0, 100, 0.1));
            this.plotModel.Series.Add(new FunctionSeries(Wykres_Prad, 0, 100, 0.1));


            plotModel.Axes.Add(new LinearAxis(AxisPosition.Bottom, 0, 100));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Left, -150, 150));



        }
        private OxyPlot.PlotModel plotModel;

        public OxyPlot.PlotModel CewkaModel
        {
            get { return plotModel; }

            set
            {
                plotModel = value;
                OnPropertyChanged("CewkaModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
    
    

