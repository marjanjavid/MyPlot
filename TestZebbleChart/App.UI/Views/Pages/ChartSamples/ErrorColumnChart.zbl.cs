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

    partial class ErrorColumnChart
    {
        public override async Task OnInitializing()
        {
            var errorColumnPlotModel = new Chart.PlotModel { Title = "ErrorColumnChart" };

            errorColumnPlotModel.Series.Add(new Chart.ErrorColumn()
            {
                Title = "Series 1",
                Data = new List<Chart.ErrorColumnItem>
                {
                    new Chart.ErrorColumnItem(){ Value = 25, Error = 2},
                    new Chart.ErrorColumnItem(){ Value = 137, Error = 25 },
                    new Chart.ErrorColumnItem(){ Value = 18, Error = 4 },
                    new Chart.ErrorColumnItem(){ Value = 40, Error = 29 },
                }
            });

            errorColumnPlotModel.Series.Add(new Chart.ErrorColumn()
            {
                Title = "Series 2",
                Data = new List<Chart.ErrorColumnItem>
                {
                    new Chart.ErrorColumnItem(){ Value = 35, Error = 20},
                    new Chart.ErrorColumnItem(){ Value = 17, Error = 7  },
                    new Chart.ErrorColumnItem(){ Value = 118, Error = 44 },
                    new Chart.ErrorColumnItem(){ Value = 49, Error = 29 },
                }
            });

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom };
            categoryAxis.Labels.Add("Category A");
            categoryAxis.Labels.Add("Category B");
            categoryAxis.Labels.Add("Category C");
            categoryAxis.Labels.Add("Category D");

            var valueAxis = new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
            errorColumnPlotModel.Axes.Add(categoryAxis);
            errorColumnPlotModel.Axes.Add(valueAxis);

            await base.OnInitializing();
            await ErrorColumnPlotView.Add(errorColumnPlotModel);

        }
    }
}