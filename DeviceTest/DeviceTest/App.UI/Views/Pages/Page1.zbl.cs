namespace UI.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;
    using Domain;
    using static Zebble.zebbleOxyPlot;

    partial class Page1
    {
        public override async Task OnInitializing()
        {
            /* TODO: Any custom initialization code here will run 
               BEFORE child views are created from ZBL markup.*/
               
         await base.OnInitializing();


            var myPlotModel = new zebbleOxyPlot.PlotModel
            {
                Title = "myPlotModel"
            };
            myPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            myPlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });
            myPlotView.Add(myPlotModel);

            /* TODO: Any configuration code here will run 
               AFTER child views are created from ZBL markup. */
        }

        /* TODO: If needed, add event handlers here.
         
        Task On...Tapped()
        {
               
        }

        */
    }
}