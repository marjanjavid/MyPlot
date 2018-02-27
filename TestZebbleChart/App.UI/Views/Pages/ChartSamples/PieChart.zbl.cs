namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;

    partial class PieChart
    {
        public override async Task OnInitializing()
        {
            var piePlotModel = new Chart.PlotModel { Title = "zebblePieChart" };
            piePlotModel.Series.Add(new Chart.Pie(new List<Chart.PieSlice>
                {
                    new Chart.PieSlice("Africa", 1030),
                    new Chart.PieSlice("Americas", 929),
                    new Chart.PieSlice("Asia", 4157),
                    new Chart.PieSlice("Europe", 739),
                    new Chart.PieSlice("Oceania", 35)
                }));
            await base.OnInitializing();
            await piePlotView.Add(piePlotModel);
        }
    }
}