using DiscUsage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.ViewModel
{
    public class DiscSpaceRectangle
    {
        public DiscSpaceRectangle(DiscSpace space)
        {
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public System.Windows.Media.Brush FillColor { get; set; }
    }
}
