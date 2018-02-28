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

    partial class HighLowChart
    {
        public override async Task OnInitializing()

        {
            var highLowPlotModel = new Chart.PlotModel { Title = "zebbleHighLowChart" };
            var s1 = new Chart.HighLow();
            var r = new Random(314);
            var price = 100.0;
            for (int x = 0; x < 24; x++)
            {
                price = price + r.NextDouble() + 0.1;
                var high = price + 10 + r.NextDouble() * 10;
                var low = price - (10 + r.NextDouble() * 10);
                var open = low + r.NextDouble() * (high - low);
                var close = low + r.NextDouble() * (high - low);
                s1.Data.Add(new Chart.HighLowItem(x, high, low, open, close));
            }

            highLowPlotModel.Series.Add(s1);
            highLowPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MaximumPadding = 0.3, MinimumPadding = 0.3 });
            await base.OnInitializing();
            await highLowPlotView.Add(highLowPlotModel);

        }
    }
}