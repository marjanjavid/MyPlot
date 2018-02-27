namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;

    partial class BarChart
    {
        public override async Task OnInitializing()
        {
            var barPlotModel = new Chart.PlotModel { Title = "zebbleBarChart" };
            barPlotModel.Series.Add(new Chart.Bar(new List<Chart.Item>
                {
                    new Chart.Item(25),
                    new Chart.Item(137),
                    new Chart.Item(13),
                    new Chart.Item(40),
                }));
            await base.OnInitializing();
            await barPlotView.Add(barPlotModel);
        }
    }
}