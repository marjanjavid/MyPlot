namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using OxyPlot;

    partial class ContourChart
    {
        public override async Task OnInitializing()
        {
            double x0 = -3.1;
            double x1 = 3.1;
            double y0 = -3;
            double y1 = 3;

            //generate values
            Func<double, double, double> peaks = (x, y) =>
           3 * (1 - x) * (1 - x) * Math.Exp(-(x * x) - (y + 1) * (y + 1))
           - 10 * (x / 5 - x * x * x - y * y * y * y * y) * Math.Exp(-x * x - y * y)
           - 1.0 / 3 * Math.Exp(-(x + 1) * (x + 1) - y * y);
            var xx = ArrayBuilder.CreateVector(-3, 3, 0.05);
            var yy = ArrayBuilder.CreateVector(-3.1, 3.1, 0.05);

            var contourPlotModel = new Chart.PlotModel { Title = "zebbleContourChart" };

            contourPlotModel.Series.Add(new Chart.Contour()
            {
                Data = ArrayBuilder.Evaluate(peaks, xx, yy),
                ColumnCoordinates = xx,
                RowCoordinates = yy
            });
            await base.OnInitializing();
            await contourPlotView.Add(contourPlotModel);
        }
    }
}