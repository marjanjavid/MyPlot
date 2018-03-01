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

    partial class IntervalBarChart
    {
        public override async Task OnInitializing()
        {
            var intervalBarPlotModel = new Chart.PlotModel { Title = "IntervalBarSeries" };

            var s1 = new Chart.IntervalBar { Title = "IntervalBarSeries 1" };
            s1.Data.Add(new IntervalBarItem { Start = 6, End = 8 });
            s1.Data.Add(new IntervalBarItem { Start = 4, End = 8 });
            s1.Data.Add(new IntervalBarItem { Start = 5, End = 11 });
            s1.Data.Add(new IntervalBarItem { Start = 4, End = 12 });
            intervalBarPlotModel.Series.Add(s1);
            var s2 = new Chart.IntervalBar { Title = "IntervalBarSeries 2" };
            s2.Data.Add(new IntervalBarItem { Start = 8, End = 9 });
            s2.Data.Add(new IntervalBarItem { Start = 8, End = 10 });
            s2.Data.Add(new IntervalBarItem { Start = 11, End = 12 });
            s2.Data.Add(new IntervalBarItem { Start = 12, End = 12.5 });
            intervalBarPlotModel.Series.Add(s2);

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Labels.Add("Activity A");
            categoryAxis.Labels.Add("Activity B");
            categoryAxis.Labels.Add("Activity C");
            categoryAxis.Labels.Add("Activity D");
            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0.1, MaximumPadding = 0.1 };
            intervalBarPlotModel.Axes.Add(categoryAxis);
            intervalBarPlotModel.Axes.Add(valueAxis);
            await base.OnInitializing();
            await intervalBarPlotView.Add(intervalBarPlotModel);
        }
    }
}