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

    partial class CandleStickChart
    {
        public override async Task OnInitializing()
        {
            var startTimeValue = DateTimeAxis.ToDouble(new DateTime(2016, 1, 1));
            var candleStickPlotModel = new Chart.PlotModel { Title = "zebbleCandleStick" };
            candleStickPlotModel.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, Minimum = startTimeValue - 7, Maximum = startTimeValue + 7 });
            candleStickPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
            var series = new Chart.CandleStick();
            series.Data.Add(new Chart.HighLowItem(startTimeValue, 100, 80, 92, 94));
            series.Data.Add(new Chart.HighLowItem(startTimeValue + 1, 102, 77, 94, 93));
            candleStickPlotModel.Series.Add(series);
            await base.OnInitializing();
            candleStickPlotView.Add(candleStickPlotModel);
        }
    }
}