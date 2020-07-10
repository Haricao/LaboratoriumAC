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
    public class OxyPlotModel_Kondensator : INotifyPropertyChanged
    {
        public OxyPlotModel_Kondensator(double Napiecie, double Pojemnosc, double Frq)
        {
            this.plotModel = new PlotModel { };

            Func<double, double> Wykres_Nap = (x) => (Napiecie / 2.3) * (Math.Sin(x * (Frq / 160)));
            Func<double, double> Wykres_Prad = (x) => (Pojemnosc/1000) * Napiecie * (Math.Sin(x * (Frq / 160) + Math.PI / 2));
            //Ustawienie zakresu rysowania funkcja, start, koniec"
            this.plotModel.Series.Add(new FunctionSeries(Wykres_Nap, 0, 100, 0.1));
            this.plotModel.Series.Add(new FunctionSeries(Wykres_Prad, 0, 100, 0.1));


            plotModel.Axes.Add(new LinearAxis(AxisPosition.Bottom, 0, 100));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Left, -100, 100));



        }
        private OxyPlot.PlotModel plotModel;

        public OxyPlot.PlotModel KondensatorModel
        {
            get { return plotModel; }

            set
            {
                plotModel = value;
                OnPropertyChanged("KondensatorModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
