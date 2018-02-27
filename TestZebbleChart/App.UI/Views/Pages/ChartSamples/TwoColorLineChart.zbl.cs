namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;

    partial class TwoColorLineChart
    {
        public override async Task OnInitializing()
        {
            var temperatures = new[] { 5, 0, 7, 7, 4, 3, 5, 5, 11, 4, 2, 3, 2, 1, 0, 2, -1, 0, 0, -3, -6, -13, -10, -10, 0, -4, -5, -4, 3, 0, -5 };
            var dataPoints = new List<Chart.DataPoint>();
            for (int i = 0; i < temperatures.Length; i++)
            {
                dataPoints.Add(new Chart.DataPoint(i + 1, temperatures[i]));
            }
            var twoColorLinePlotModel = new Chart.PlotModel { Title = "TwoColorLineChart" };
            twoColorLinePlotModel.Series.Add(new Chart.TwoColorLine()
            {
                Color = Colors.Red,
                Color2 = Colors.LightBlue,
                Limit = 0,
                Data = dataPoints
            });
            await base.OnInitializing();
            await twoColorLinePlotView.Add(twoColorLinePlotModel);
        }
    }
}