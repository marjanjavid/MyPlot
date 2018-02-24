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
                var linePlotModel = new Chart.PlotModel { Title = "zebbleLineChart" };
                linePlotModel.Series.Add(new Chart.Line(new List<Chart.DataPoint>
                {
                  new Chart.DataPoint(0.0, 6.0),
                  new Chart.DataPoint(1.4, 2.1),
                  new Chart.DataPoint(2.0, 4.2),
                  new Chart.DataPoint(3.3, 2.3),
                  new Chart.DataPoint(4.7, 7.4),
                  new Chart.DataPoint(6.0, 6.2),

                }));

                //area plotmodel
                var areaPlotModel = new Chart.PlotModel{Title = "zebbleAreaChart"};
                areaPlotModel.Series.Add(new Chart.Area(new List<Chart.DataPoint>
                {
                    new Chart.DataPoint(0, 50),
                    new Chart.DataPoint(10, 40),
                    new Chart.DataPoint(20, 60),
                    new Chart.DataPoint(0, 60),
                    new Chart.DataPoint(5, 80),
                    new Chart.DataPoint(20, 70)
                }));

                //pie plotmodel
                var piePlotModel = new Chart.PlotModel{Title = "zebbleAreaChart"};
                piePlotModel.Series.Add(new Chart.Pie(new List<Chart.PieSlice>
                {
                    new Chart.PieSlice("Africa", 1030),
                    new Chart.PieSlice("Americas", 929),
                    new Chart.PieSlice("Asia", 4157),
                    new Chart.PieSlice("Europe", 739),
                    new Chart.PieSlice("Oceania", 35)
                }));

                //bar plotmodel
                var barPlotModel = new Chart.PlotModel{Title = "zebbleBarChart"};
                barPlotModel.Series.Add(new Chart.Bar(new List<Chart.Item>
                {
                    new Chart.Item(25),
                    new Chart.Item(137),
                    new Chart.Item(13),
                    new Chart.Item(40),
                }));

                //column plotmodel
                var columnPlotModel = new Chart.PlotModel{Title = "zebbleColumnChart"};
                columnPlotModel.Series.Add(new Chart.Column(new List<Chart.Item>
                {
                    new Chart.Item(25),
                    new Chart.Item(137),
                    new Chart.Item(13),
                    new Chart.Item(40),
                }));

                //box plotmodel
                var random = new Random(31);
                const int boxes = 10;
                var boxPlotModel = new Chart.PlotModel{Title = "zebbleBoxChart"};
                var list = new List<Chart.BoxPlotItem>();
                for (var i = 0; i < boxes; i++)
                {
                    double myxx = i;
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
                    list.Add(new Chart.BoxPlotItem(myxx, lowerWhisker, firstQuartil, median, thirdQuartil, upperWhisker));

                }
                boxPlotModel.Series.Add(new Chart.Box(list));

                //contour plotmodel
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


                //RectangleBar plotmodel
                var rectangleBarPlotModel = new Chart.PlotModel{Title = "RectangleBarChart"};

                rectangleBarPlotModel.Series.Add(new Chart.RectangleBar("RectangleBarSeries 1",new List<Chart.RectangleBarItem>
                {
                    new Chart.RectangleBarItem(){ X0 = 2, X1 = 8, Y0 = 1, Y1 = 4},
                    new Chart.RectangleBarItem(){ X0 = 6, X1 = 12, Y0 = 6, Y1 = 7},
                }));

                rectangleBarPlotModel.Series.Add(new Chart.RectangleBar("RectangleBarSeries 2",new List<Chart.RectangleBarItem>
                {
                    new Chart.RectangleBarItem(){ X0 = 2, X1 = 8, Y0 = -4, Y1 = -1},
                    new Chart.RectangleBarItem(){ X0 = 6, X1 = 12, Y0 = -7, Y1 = -6},
                }));


                //TwoColorLine plotmodel

                var temperatures = new[] { 5, 0, 7, 7, 4, 3, 5, 5, 11, 4, 2, 3, 2, 1, 0, 2, -1, 0, 0, -3, -6, -13, -10, -10, 0, -4, -5, -4, 3, 0, -5 };
                var dataPoints = new List<Chart.DataPoint>();
                for (int i = 0; i < temperatures.Length; i++)
                {
                    dataPoints.Add(new Chart.DataPoint(i + 1, temperatures[i]));
                }
                var twoColorLinePlotModel = new Chart.PlotModel { Title = "TwoColorLineChart" };
                twoColorLinePlotModel.Series.Add(new Chart.TwoColorLine() {
                    Color = Colors.Red ,
                    Color2 = Colors.LightBlue,
                    Limit = 0,
                    Data= dataPoints
                });
                
                await base.OnInitializing();

                // await linePlotView.Add(linePlotModel);
                //await areaPlotView.Add(areaPlotModel);
                //await piePlotView.Add(piePlotModel);
                //await barPlotView.Add(barPlotModel);
                //await columnPlotView.Add(columnPlotModel);
                //await boxPlotView.Add(boxPlotModel);
                //await contourPlotView.Add(contourPlotModel);
                //await rectangleBarPlotView.Add(rectangleBarPlotModel);
                await twoColorLinePlotView.Add(twoColorLinePlotModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }




    }
}