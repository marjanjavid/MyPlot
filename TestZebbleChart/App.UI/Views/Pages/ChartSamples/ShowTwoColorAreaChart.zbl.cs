namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using static Zebble.Chart;

    partial class ShowTwoColorAreaChart
    {
        public override async Task OnInitializing()
        {
            var areaTemperatures = new[] { 5, 0, 7, 7, 4, 3, 5, 5, 11, 4, 2, 3, 2, 1, 0, 2, -1, 0, 0, -3, -6, -13, -10, -10, 0, -4, -5, -4, 3, 0, -5 };

            var areadataPoints = new List<Chart.DataPoint>();
            for (int i = 0; i < areaTemperatures.Length; i++)
            {
                areadataPoints.Add(new Chart.DataPoint(i + 1, areaTemperatures[i]));
            }
            var twoColorAreaPlotModel = new Chart.PlotModel { Title = "TwoColorAreaChart" };
            twoColorAreaPlotModel.Series.Add(new Chart.TwoColorArea()
            {
                Color = Colors.Tomato,
                Color2 = Colors.LightBlue,
                Limit = -1,
                Data = areadataPoints
            });
            await base.OnInitializing();
            await twoColorAreaPlotView.Add(twoColorAreaPlotModel);
        }
    }
}