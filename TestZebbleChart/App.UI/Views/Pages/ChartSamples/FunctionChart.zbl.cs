namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;

    partial class FunctionChart
    {
        public override async Task OnInitializing()
        {
            var functionPlotModel = new Chart.PlotModel { Title = "FunctionChart"  };

            functionPlotModel.Series.Add(new Chart.Function(Math.Sin, -10, 10, 0.1, "sin(x)"));
            functionPlotModel.Series.Add(new Chart.Function(Math.Cos, -10, 10, 0.1, "cos(x)"));
            functionPlotModel.Series.Add(new Chart.Function(t => 5 * Math.Cos(t), t => 5 * Math.Sin(t), 0, 2 * Math.PI, 1000, "cos(t),sin(t)"));
            await base.OnInitializing();
            await functionPlotView.Add(functionPlotModel);

        }
    }
}