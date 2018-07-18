using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscUsage.Model;
using System.Windows.Media;

namespace DiscUsage.ViewModel
{
    public class DiscSpaceCanvasViewModel
    {
        public ObservableCollection<DiscSpaceRectangle> DiscSpaceRectangles
        {
            get;
            set;
        }

        public void Add(List<DiscSpace> spaces)
        {
            var spacesCollection = new ObservableCollection<DiscSpaceRectangle>();
            var x = 0;
         
            foreach (var space in spaces)
            {
                var discSpaceRectangle = new DiscSpaceRectangle(space)
                {
                    FillColor = Brushes.Green
                };
                spacesCollection.Add(discSpaceRectangle);
                x += 50;
            }
            DiscSpaceRectangles = spacesCollection;
        }
    }
}
