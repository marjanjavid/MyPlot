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

    partial class ScatterChart
    {
        public override async Task OnInitializing()
        {
            var model = new Chart.PlotModel { Title = "ScatterSeries" };
            var scatterSeries = new Chart.Scatter ();
            var r = new Random(314);
            for (int i = 0; i < 100; i++)
            {
                var x = r.NextDouble();
                var y = r.NextDouble();
                var size = r.Next(5, 15);
                var colorValue = r.Next(100, 1000);
                scatterSeries.Data.Add(new Chart.ScatterPoint(x, y, size, colorValue));
            }

            model.Series.Add(scatterSeries);
            model.Axes.Add(new LinearColorAxis { Position = AxisPosition.Right, Palette = OxyPalettes.Jet(200) });
            await base.OnInitializing();
            await scatterBarPlotView.Add(model);
        }
    }
}