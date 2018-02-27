namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;

    partial class RectangleBarChart
    {
        public override async Task OnInitializing()
        {
            var rectangleBarPlotModel = new Chart.PlotModel { Title = "RectangleBarChart" };

            rectangleBarPlotModel.Series.Add(new Chart.RectangleBar("RectangleBarSeries 1", new List<Chart.RectangleBarItem>
                {
                    new Chart.RectangleBarItem(){ X0 = 2, X1 = 8, Y0 = 1, Y1 = 4},
                    new Chart.RectangleBarItem(){ X0 = 6, X1 = 12, Y0 = 6, Y1 = 7},
                }));

            rectangleBarPlotModel.Series.Add(new Chart.RectangleBar("RectangleBarSeries 2", new List<Chart.RectangleBarItem>
                {
                    new Chart.RectangleBarItem(){ X0 = 2, X1 = 8, Y0 = -4, Y1 = -1},
                    new Chart.RectangleBarItem(){ X0 = 6, X1 = 12, Y0 = -7, Y1 = -6},
                }));
            await base.OnInitializing();
            await rectangleBarPlotView.Add(rectangleBarPlotModel);
        }
    }
}