namespace Zebble
{
    using OxyPlot;
    using OxyPlot.Series;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;

    public partial class Chart : View, IRenderedBy<ChartRenderer>
    {
        public PlotModel plotModel = new PlotModel();
        bool showXAxis = true, showYAxix = true, isZoomable = true, isMovable = true;
        IPlotType chartType = new Area();
        public bool ShowXAxis
        {
            get => showXAxis;
            set
            {
                if (showXAxis == value) return;
                showXAxis = value;
            }
        }
        public bool ShowYAxix
        {
            get => showYAxix;
            set
            {
                if (showYAxix == value) return;
                showYAxix = value;
            }
        }
        public bool IsZoomable
        {
            get => isZoomable;
            set
            {
                if (isZoomable == value) return;
                isZoomable = value;
            }
        }
        public bool IsMovable
        {
            get => isMovable;
            set
            {
                if (isMovable == value) return;
                isMovable = value;
            }
        }
        private object Data { get; set; }
        public IPlotType ChartType
        {
            get => chartType;
            set
            {
                if (chartType == value) return;
                chartType = value;
            }
        }
        public async Task Add(PlotModel plotModel)
        {
            if(chartType is Area)
            {
                var areaSeries1 = new AreaSeries();
                areaSeries1.Points.AddRange(((Area)chartType).points.Cast<OxyPlot.DataPoint>().ToList());
                this.plotModel.Series.Add(areaSeries1);
            }
            this.plotModel = plotModel;
            //switch (chartType)
            //{
            //    case PlotType.Area:
            //        var areaSeries1 = new AreaSeries();
            //        areaSeries1.Points.Add(new DataPoint(0, 50));
            //        areaSeries1.Points.Add(new DataPoint(10, 140));
            //        areaSeries1.Points.Add(new DataPoint(20, 60));
            //        areaSeries1.Points2.Add(new DataPoint(0, 60));
            //        areaSeries1.Points2.Add(new DataPoint(5, 80));
            //        areaSeries1.Points2.Add(new DataPoint(20, 70));
            //        this.plotModel.Series.Add(areaSeries1);
            //        break;
            //    case PlotType.Bar:

            //        break;
            //    case PlotType.BoxPlot:
            //        break;
            //    case PlotType.CandleStick:
            //        break;
            //    case PlotType.Column:
            //        var columnSeries = new ColumnSeries();
            //        columnSeries.Items.Add(new Zebble.ColumnItem(100));
            //        this.plotModel.Series.Add(columnSeries);
            //        break;
            //    case PlotType.Contour:
            //        break;
            //    case PlotType.ErrorColumn:
            //        break;
            //    case PlotType.Function:
            //        break;
            //    case PlotType.HeatMap:
            //        break;
            //    case PlotType.HighLow:
            //        break;
            //    case PlotType.IntervalBar:
            //        break;
            //    case PlotType.Line:
            //        var lineSeries = new LineSeries
            //        {
            //            MarkerType = MarkerType.Circle,
            //            MarkerSize = 4,
            //            MarkerStroke = OxyColors.White
            //        };
            //        lineSeries.Points.Add(new DataPoint(0.0, 6.0));
            //        lineSeries.Points.Add(new DataPoint(1.4, 2.1));
            //        lineSeries.Points.Add(new DataPoint(2.0, 4.2));
            //        lineSeries.Points.Add(new DataPoint(3.3, 2.3));
            //        lineSeries.Points.Add(new DataPoint(4.7, 7.4));
            //        lineSeries.Points.Add(new DataPoint(6.0, 6.2));
            //        lineSeries.Points.Add(new DataPoint(8.9, 8.9));

            //        this.plotModel.Series.Add(lineSeries);
            //        break;
            //    case PlotType.Pie:
            //        var ps = new PieSeries
            //        {
            //            StrokeThickness = 2.0,
            //            InsideLabelPosition = 0.8,
            //            AngleSpan = 360,
            //            StartAngle = 0
            //        };
            //        ps.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = true });
            //        ps.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            //        ps.Slices.Add(new PieSlice("Asia", 4157));
            //        ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            //        ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            //        this.plotModel.Series.Add(ps);
            //        break;
            //    case PlotType.RectangleBar:
            //        break;
            //    case PlotType.Scatter:
            //        break;
            //    case PlotType.StairStep:
            //        break;
            //    case PlotType.Stem:
            //        break;
            //    case PlotType.TornadoBar:
            //        break;
            //    case PlotType.TwoColorArea:
            //        break;
            //    case PlotType.TwoColorLine:
            //        break;
            //    default:
            //        break;
            //}

        }
        public override void Dispose()
        {
            base.Dispose();
        }
        //public enum PlotType
        //{
        //    Area,
        //    Bar,
        //    BoxPlot,
        //    CandleStick,
        //    Column,
        //    Contour,
        //    ErrorColumn,
        //    Function,
        //    HeatMap,
        //    HighLow,
        //    IntervalBar,
        //    Line,
        //    Pie,
        //    RectangleBar,
        //    Scatter,
        //    StairStep,
        //    Stem,
        //    TornadoBar,
        //    TwoColorArea,
        //    TwoColorLine
        //}
    }
}