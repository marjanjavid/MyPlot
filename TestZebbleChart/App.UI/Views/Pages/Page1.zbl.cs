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
            var myPlotModel = new Chart.PlotModel
            {
                Title = "myPlotModeljon"
            };
            myPlotModel.Chart = new Chart.Line(new List<Chart.DataPoint>
            {
                  new Chart.DataPoint(0.0, 6.0),
                  new Chart.DataPoint(1.4, 2.1),
                  new Chart.DataPoint(2.0, 4.2),
                  new Chart.DataPoint(3.3, 2.3),
                  new Chart.DataPoint(4.7, 7.4),
                  new Chart.DataPoint(6.0, 6.2),

            });
            await base.OnInitializing();

            await myPlotView.Add(myPlotModel);

        }




    }
}