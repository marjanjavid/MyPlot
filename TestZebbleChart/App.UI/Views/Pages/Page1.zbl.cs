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

    partial class Page1
    {
        public override async Task OnInitializing()
        {
            try
            {

            
            //line plotmodel
            var linePlotModel = new Chart.PlotModel
            {
                Title = "zebbleLineChart",
                Chart = new Chart.Line(new List<Chart.DataPoint>
            {
                  new Chart.DataPoint(0.0, 6.0),
                  new Chart.DataPoint(1.4, 2.1),
                  new Chart.DataPoint(2.0, 4.2),
                  new Chart.DataPoint(3.3, 2.3),
                  new Chart.DataPoint(4.7, 7.4),
                  new Chart.DataPoint(6.0, 6.2),

            })
            };
            //area plotmodel
            var areaPlotModel = new Chart.PlotModel
            {
                Title = "zebbleAreaChart",
                Chart = new Chart.Area(new List<Chart.DataPoint>
                {
                    new Chart.DataPoint(0, 50),
                    new Chart.DataPoint(10, 40),
                    new Chart.DataPoint(20, 60),
                    new Chart.DataPoint(0, 60),
                    new Chart.DataPoint(5, 80),
                    new Chart.DataPoint(20, 70)
                })
            };
            //pie plotmodel
            var piePlotModel = new Chart.PlotModel
            {
                Title = "zebbleAreaChart",
                Chart = new Chart.Pie(new List<Chart.PieSlice>
                {
                    new Chart.PieSlice("Africa", 1030),
                    new Chart.PieSlice("Americas", 929),
                    new Chart.PieSlice("Asia", 4157),
                    new Chart.PieSlice("Europe", 739),
                    new Chart.PieSlice("Oceania", 35)
                })
            };

            //bar plotmodel
            var barPlotModel = new Chart.PlotModel
            {
                Title = "zebbleBarChart",
                Chart = new Chart.Bar(new List<Chart.Item>
                {
                    new Chart.Item(25),
                    new Chart.Item(137),
                    new Chart.Item(13),
                    new Chart.Item(40),
                })
            };

            //column plotmodel
            var columnPlotModel = new Chart.PlotModel
            {
                Title = "zebbleColumnChart",
                Chart = new Chart.Column(new List<Chart.Item>
                {
                    new Chart.Item(25),
                    new Chart.Item(137),
                    new Chart.Item(13),
                    new Chart.Item(40),
                })
            };

            //box plotmodel
            var random = new Random(31);
            const int boxes = 10;
            var boxPlotModel = new Chart.PlotModel
            {
                Title = "zebbleBoxChart",
                Chart = new Chart.Box()


            };
                ((Chart.Box)boxPlotModel.Chart).Data = new List<Chart.BoxPlotItem>();
            for (var i = 0; i < boxes; i++)
            {
                double x = i;
                var points = 5 + random.Next(15);
                var values = new List<double>();
                for (var j = 0; j < points; j++)
                {
                    values.Add(random.Next(0, 20));
                }

                values.Sort();
                var median = Chart.Box.GetMedian(values);
                var mean = values.Average();
                int r = values.Count % 2;
                double firstQuartil = Chart.Box.GetMedian(values.Take((values.Count + r) / 2));
                double thirdQuartil = Chart.Box.GetMedian(values.Skip((values.Count - r) / 2));

                var iqr = thirdQuartil - firstQuartil;
                var step = iqr * 1.5;
                var upperWhisker = thirdQuartil + step;
                upperWhisker = values.Where(v => v <= upperWhisker).Max();
                var lowerWhisker = firstQuartil - step;
                lowerWhisker = values.Where(v => v >= lowerWhisker).Min();

                var outliers = new[] { upperWhisker + random.Next(1, 10), lowerWhisker - random.Next(1, 10) };
                ((Chart.Box)boxPlotModel.Chart).Data.Add(new Chart.BoxPlotItem(x, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker));
                
            }

            await base.OnInitializing();

            //await linePlotView.Add(linePlotModel);
            //await areaPlotView.Add(areaPlotModel);
            //await piePlotView.Add(piePlotModel);
            //await barPlotView.Add(barPlotModel);
            //await columnPlotView.Add(columnPlotModel);
            await boxPlotView.Add(boxPlotModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }




    }
}