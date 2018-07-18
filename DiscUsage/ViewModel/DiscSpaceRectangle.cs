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
        private double CanvasWidth=600;
        private double CanvasHeight = 600;
        private double Margin = 6;
        private double _strokeWidth = 2;
        private double _CornerRadius=8;

        public DiscSpaceRectangle(DiscSpace space)
        {
            this.space = space;
        }

        public double X => (Parent == null) ? 0 : (space.Level % 2 == 1) ? Position + Parent.X: Parent.X+Margin/2;
        public double Y => (Parent == null) ? 0 : (space.Level % 2 == 0) ? Position + Parent.Y: Parent.Y+Margin/2;

        public double Width => (Parent == null)? CanvasWidth : (space.Level % 2 == 1) ? Size : Parent.Width-Margin;
        public double Height => (Parent == null) ? CanvasHeight : (space.Level % 2 == 0) ? Size : Parent.Height-Margin;
        public double Radius => Math.Min(_CornerRadius, Math.Min(Width,Height)/2);

        public Brush FillColor => Brushes.Blue; //brushes[space.Level%brushes.Count];
        public double StrokeWidth => this._strokeWidth;

        public DiscSpaceRectangle Parent { get; internal set; }
        public List<DiscSpaceRectangle> Children { get; internal set; }

        private double Size => (Parent == null) ? CanvasHeight : (double)space.Length / (double)Parent.space.Length * Parent.Size - Margin;
        private double Position => (Parent == null) ? 0 : (double)space.LengthOfAllPreviousChildren / (double)Parent.space.Length * Parent.Size+Margin/2;

    }
}
