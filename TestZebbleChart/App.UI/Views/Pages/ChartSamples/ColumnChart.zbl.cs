namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;

    partial class ColumnChart
    {
        public override async Task OnInitializing()
        {
            var columnPlotModel = new Chart.PlotModel { Title = "zebbleColumnChart" };
            columnPlotModel.Series.Add(new Chart.Column(new List<Chart.Item>
                {
                    new Chart.Item(25),
                    new Chart.Item(137),
                    new Chart.Item(13),
                    new Chart.Item(40),
                }));
            await base.OnInitializing();
            await columnPlotView.Add(columnPlotModel);
        }
    }
}