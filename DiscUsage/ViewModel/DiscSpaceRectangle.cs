using DiscUsage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DiscUsage.ViewModel
{
    public class DiscSpaceRectangle
    {
        DiscSpace space;
        public DiscSpaceRectangle(DiscSpace space)
        {
            this.space = space;
        }

        public double X => (space.Parent.Level % 2 == 0) ? Position : 0;
        public double Y => (space.Parent.Level % 2 == 1) ? Position : 0;

        public double Width => (space.Parent.Level % 2 == 0) ? Size : 300;
        public double Height => (space.Parent.Level % 2 == 1) ? Size : 300;
        public double Radius => 5;

        public Brush FillColor => Brushes.Blue;

        private double Size => (double)space.Length / (double)space.Parent.Length * (double)300.0*0.9;
        private double Position => (double)space.LengthOfAllPreviousChildren / (double)space.Parent.Length* (double)300.0;

    }
}
