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
        private List<Brush> brushes = new List<Brush> { Brushes.Gray, Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Orange, Brushes.LightBlue, Brushes.Yellow, Brushes.LightGray };
        public DiscSpace space;
        private double CanvasWidth=300;
        private double CanvasHeight = 300;

        public DiscSpaceRectangle(DiscSpace space)
        {
            this.space = space;
        }

        public double X => (Parent == null) ? 0 : (space.Level % 2 == 1) ? Position + Parent.X: Parent.X;
        public double Y => (Parent == null) ? 0 : (space.Level % 2 == 0) ? Position + Parent.Y: Parent.Y;

        public double Width => (Parent == null)? CanvasWidth : (space.Level % 2 == 1) ? Size : Parent.Width;
        public double Height => (Parent == null) ? CanvasHeight : (space.Level % 2 == 0) ? Size : Parent.Height;
        public double Radius => Math.Min(Width,Height)*0.05;

        public Brush FillColor => brushes[space.Level%brushes.Count];

        public DiscSpaceRectangle Parent { get; internal set; }
        public List<DiscSpaceRectangle> Children { get; internal set; }

        private double Size => (Parent == null) ? CanvasHeight : (double)space.Length / (double)Parent.space.Length * Parent.Size * (double)0.9;
        private double Position => (Parent == null) ? 0 : (double)space.LengthOfAllPreviousChildren / (double)Parent.space.Length * Parent.Size;

    }
}
