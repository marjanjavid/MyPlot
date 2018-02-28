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
            barPlotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "CakeAxis",
                ItemsSource = new[]
                        {
                            "Apple cake",
                            "Baumkuchen",
                            "Bundt Cake",
                            "Chocolate cake",
                            "Carrot cake"
                         }
            });
            await base.OnInitializing();
            await barPlotView.Add(barPlotModel);
        }
    }
}