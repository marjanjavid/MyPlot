using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public class Area : IPlotType
    {
        internal List<DataPoint> points;
        public List<DataPoint> Data
        {
            get => points;
            set
            {
                if (points == value) return;
                points = value;
            }
        }
        //public Area(List<DataPoint> data)
        //{
        //    this.points = data;
        //}
        public Area()
        {

        }
    }
}
