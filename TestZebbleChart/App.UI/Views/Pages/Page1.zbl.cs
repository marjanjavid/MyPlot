namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using OxyPlot.Axes;
    using OxyPlot;
    using OxyPlot.Series;

    partial class Page1
    {
        public override async Task OnInitializing()
        {
            //line plotmodel
            var linePlotModel = new Chart.PlotModel
            {
                Title = "zebbleLineChart",
                Chart = new Chart.Line(new List<Chart.DataPoint>
            {
                  new Chart.DataPoint(0.0, 6.0),
                  new Chart.DataPoint(1.4, 2.1),
                  new Chart.DataPoint(2.0, 4.2),
                  new Chart.DataPoint(3.3, 2.3),
                  new Chart.DataPoint(4.7, 7.4),
                  new Chart.DataPoint(6.0, 6.2),

            })
            };
            //area plotmodel
            var areaPlotModel = new Chart.PlotModel
            {
                Title = "zebbleAreaChart",
                Chart = new Chart.Area(new List<Chart.DataPoint>
                {
                    new Chart.DataPoint(0, 50),
                    new Chart.DataPoint(10, 40),
                    new Chart.DataPoint(20, 60),
                    new Chart.DataPoint(0, 60),
                    new Chart.DataPoint(5, 80),
                    new Chart.DataPoint(20, 70)
                })
            };
            //pie plotmodel
            var piePlotModel = new Chart.PlotModel
            {
                Title = "zebbleAreaChart",
                Chart = new Chart.Pie(new List<Chart.PieSlice>
                {
                    new Chart.PieSlice("Africa", 1030),
                    new Chart.PieSlice("Americas", 929),
                    new Chart.PieSlice("Asia", 4157),
                    new Chart.PieSlice("Europe", 739),
                    new Chart.PieSlice("Oceania", 35)
                })
            };
            await base.OnInitializing();

            await linePlotView.Add(linePlotModel);
            await areaPlotView.Add(areaPlotModel);
            await piePlotView.Add(piePlotModel);
        }




    }
}