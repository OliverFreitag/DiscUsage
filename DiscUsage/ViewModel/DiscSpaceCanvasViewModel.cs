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
        private Dictionary<DiscSpace, DiscSpaceRectangle> mapping = new Dictionary<DiscSpace, DiscSpaceRectangle>();

        public ObservableCollection<DiscSpaceRectangle> DiscSpaceRectangles
        {
            get;
            set;
        }

        public DiscSpaceRectangle Root;

        public void Add(List<DiscSpace> spaces)
        {
            var spacesCollection = new ObservableCollection<DiscSpaceRectangle>();
         
            foreach (var space in spaces)
            {
                var discSpaceRectangle = new DiscSpaceRectangle(space);
                spacesCollection.Add(discSpaceRectangle);
                mapping[space] = discSpaceRectangle;
            }

            foreach(var rectangle in mapping.Values)
            {
                if (rectangle.space.Parent != null)
                {
                    rectangle.Parent = mapping[rectangle.space.Parent];
                    rectangle.Children = rectangle.space.OrderedChildren.ConvertAll(x => Map(x));
                }
            }
            
            DiscSpaceRectangles = spacesCollection;
            var root = DiscSpaceRectangles.First(x => x.Parent == null);
            root.Children = root.space.OrderedChildren.ConvertAll(x => Map(x));
            Root = root;
            DiscSpaceRectangles.Remove(root);
        }

        public DiscSpaceRectangle Map(DiscSpace space)
        {
            if (space==null || !mapping.ContainsKey(space))
            {
                return null;
            }
            return mapping[space];
        }
    }
}
