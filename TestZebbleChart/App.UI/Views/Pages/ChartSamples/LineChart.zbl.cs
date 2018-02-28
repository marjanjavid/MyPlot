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

    partial class LineChart
    {
        public override async Task OnInitializing()
        {
           
            var linePlotModel = new Chart.PlotModel { Title = "zebbleLineChart" };
            linePlotModel.Series.Add(new Chart.Line(new List<Chart.DataPoint>
                {
                  new Chart.DataPoint(0.0, 6.0),
                  new Chart.DataPoint(1.4, 2.1),
                  new Chart.DataPoint(2.0, 4.2),
                  new Chart.DataPoint(3.3, 2.3),
                  new Chart.DataPoint(4.7, 7.4),
                  new Chart.DataPoint(6.0, 6.2),

                }));
            await base.OnInitializing();
            linePlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Temperature", Unit = "°C" });
            linePlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Date" });
            await linePlotView.Add(linePlotModel);
           
        }
    }
}