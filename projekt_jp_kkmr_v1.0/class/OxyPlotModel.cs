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
    public class OxyPlotModel : INotifyPropertyChanged
    {
        public OxyPlotModel(double Napiecie, double Rezystancja, double Frq)
        {
            this.plotModel = new PlotModel { };

            if (Frq != 0)//Dopracuj zakresy! Prąd nie może nigdy wyprzedzić napięcia!!!
            {
                Func<double, double> Wykres_Nap = (x) => Math.Sqrt(2) * (Napiecie / 2.3) * (Math.Sin(x * (Frq / 160)));
                Func<double, double> Wykres_Prad = (x) => (Math.Sqrt(2) * (Math.Sin(x * (Frq / 160)))) * ((Napiecie) / (Rezystancja/10));
                //Ustawienie zakresu rysowania funkcja, start, koniec"
                this.plotModel.Series.Add(new FunctionSeries(Wykres_Nap, 0, 100, 0.1, "Napięcie"));
                this.plotModel.Series.Add(new FunctionSeries(Wykres_Prad, 0, 100, 0.1, "Prąd"));
            }
            else
            {
                Func<double, double> Wykres_Nap = (x) => Napiecie / 2.3;
                Func<double, double> Wykres_Prad = (x) => (Napiecie) / (Rezystancja) * 95;
                //Ustawienie zakresu rysowania funkcja, start, koniec"
                this.plotModel.Series.Add(new FunctionSeries(Wykres_Nap, 0, 100, 0.1, "Napięcie"));
                this.plotModel.Series.Add(new FunctionSeries(Wykres_Prad, 0, 100, 0.1, "Prąd"));
            }





            //Osie wykresu. Muszą by takie same jak te w xaml
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Bottom, 0, 100));
            plotModel.Axes.Add(new LinearAxis(AxisPosition.Left, -150, 150));

            /*plotModel.LegendTitle = "Legenda";
            plotModel.LegendOrientation = OxyPlot.LegendOrientation.Horizontal;

            //Orientacja pozioma
            plotModel.LegendPlacement = OxyPlot.LegendPlacement.Outside; //Poza planszą wykresu
            plotModel.LegendPosition = OxyPlot.LegendPosition.TopLeft; //Pozycja: góra, prawo
            plotModel.LegendBackground = OxyPlot.OxyColor.FromAColor(200, OxyPlot.OxyColors.White);//Tło białe
            plotModel.LegendBorder = OxyPlot.OxyColors.Black; //Ramka okna czarna*/

        }


        private OxyPlot.PlotModel plotModel;

        public OxyPlot.PlotModel RezystorModel
        {
            get { return plotModel; }

            set
            {
                plotModel = value;
                OnPropertyChanged("RezystorModel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
