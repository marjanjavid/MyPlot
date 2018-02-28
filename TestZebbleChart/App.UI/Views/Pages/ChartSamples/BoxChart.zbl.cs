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

    partial class BoxChart
    {
        public override async Task OnInitializing()
        {
            var random = new Random(31);
            const int boxes = 10;
            var boxPlotModel = new Chart.PlotModel { Title = "zebbleBoxChart" };
            var list = new List<Chart.BoxPlotItem>();
            for (var i = 0; i < boxes; i++)
            {
                double myxx = i;
                var points = 5 + random.Next(15);
                var values = new List<double>();
                for (var j = 0; j < points; j++)
                {
                    values.Add(random.Next(0, 20));
                }

                values.Sort();
                var median = Chart.Box.GetMedian(values);
                var mean = values.Average();
                int r = values.Count % 2;
                double firstQuartil = Chart.Box.GetMedian(values.Take((values.Count + r) / 2));
                double thirdQuartil = Chart.Box.GetMedian(values.Skip((values.Count - r) / 2));

                var iqr = thirdQuartil - firstQuartil;
                var step = iqr * 1.5;
                var upperWhisker = thirdQuartil + step;
                upperWhisker = values.Where(v => v <= upperWhisker).Max();
                var lowerWhisker = firstQuartil - step;
                lowerWhisker = values.Where(v => v >= lowerWhisker).Min();

                var outliers = new[] { upperWhisker + random.Next(1, 10), lowerWhisker - random.Next(1, 10) };
                list.Add(new Chart.BoxPlotItem(myxx, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker));

            }
            boxPlotModel.Series.Add(new Chart.Box(list));
            boxPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
            boxPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0.1, MaximumPadding = 0.1 });
            await base.OnInitializing();
            await boxPlotView.Add(boxPlotModel);
        }
    }
}