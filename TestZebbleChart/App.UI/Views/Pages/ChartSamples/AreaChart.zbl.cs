namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;

    partial class AreaChart
    {
        public override async Task OnInitializing()
        {
            var areaPlotModel = new Chart.PlotModel { Title = "zebbleAreaChart" };
            areaPlotModel.Series.Add(new Chart.Area(new List<Chart.DataPoint>
                {
                    new Chart.DataPoint(0, 50),
                    new Chart.DataPoint(10, 40),
                    new Chart.DataPoint(20, 60),
                    new Chart.DataPoint(0, 60),
                    new Chart.DataPoint(5, 80),
                    new Chart.DataPoint(20, 70)
                }));
            await base.OnInitializing();
            await areaPlotView.Add(areaPlotModel);
        }
    }
}