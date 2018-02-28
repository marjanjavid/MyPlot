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
    using OxyPlot;
    using OxyPlot.Series;

    partial class HeatMapChart
    {
        public override async Task OnInitializing()
        {
            var heatMapPlotModel = new Chart.PlotModel { Title = "HeatMapSeries" };

            // Color axis (the X and Y axes are generated automatically)
            heatMapPlotModel.Axes.Add(new LinearColorAxis
            {
                Palette = OxyPalettes.Rainbow(100)
            });

            // generate 1d normal distribution
            var singleData = new double[100];
            for (int x = 0; x < 100; ++x)
            {
                singleData[x] = Math.Exp((-1.0 / 2.0) * Math.Pow(((double)x - 50.0) / 20.0, 2.0));
            }

            // generate 2d normal distribution
            var data = new double[100, 100];
            for (int x = 0; x < 100; ++x)
            {
                for (int y = 0; y < 100; ++y)
                {
                    data[y, x] = singleData[x] * singleData[(y + 30) % 100] * 100;
                }
            }

            var heatMapSeries = new Chart.HeatMap
            {
                X0 = 0,
                X1 = 99,
                Y0 = 0,
                Y1 = 99,
                Interpolate = true,
                RenderMethod = HeatMapRenderMethod.Bitmap,
                Data = data
            };

            
            heatMapPlotModel.Series.Add(heatMapSeries);
            await base.OnInitializing();
            await heatMapPlotView.Add(heatMapPlotModel);
        }
    }
}