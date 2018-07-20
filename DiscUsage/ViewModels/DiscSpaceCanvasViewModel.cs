using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscUsage.Model;
using System.Windows.Media;
using System.ComponentModel;
using Prism.Mvvm;

namespace DiscUsage.ViewModels
{
    public class DiscSpaceCanvasViewModel : BindableBase
    {
        private Dictionary<DiscSpace, DiscSpaceRectangle> mapping = new Dictionary<DiscSpace, DiscSpaceRectangle>();

        public DiscSpaceCanvasViewModel()
        {
        }

        private double _Height=600;
        public double Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height, value); }
        }

        private ObservableCollection<DiscSpaceRectangle> _DiscSpaceRectangles=new ObservableCollection<DiscSpaceRectangle>();
        public ObservableCollection<DiscSpaceRectangle> DiscSpaceRectangles
        {
            get { return _DiscSpaceRectangles; }
            set { SetProperty(ref _DiscSpaceRectangles,value); }
        }

        public DiscSpaceRectangle Root;

        private DiscSpaceRectangle _FocusedRectangle;
        public DiscSpaceRectangle FocusedRectangle
        {
            get { return _FocusedRectangle; }
            set { SetProperty(ref _FocusedRectangle, value); }
        }

        public void Update(DiscSpace space)
        {
            var discSpaceRectangle = Map(space);
            discSpaceRectangle.Children = discSpaceRectangle.space.OrderedChildren.ConvertAll(x => Map(x));
        }

        public void Add(DiscSpace space)
        {
            var discSpaceRectangle = new DiscSpaceRectangle(space, this);

            _DiscSpaceRectangles.Add(discSpaceRectangle);
            mapping[space] = discSpaceRectangle;

            if (discSpaceRectangle.space.Parent != null)
            {
                discSpaceRectangle.Parent = mapping[discSpaceRectangle.space.Parent];
                discSpaceRectangle.Parent.Children = discSpaceRectangle.Parent.space.OrderedChildren.ConvertAll(x => Map(x));
            }
            if (discSpaceRectangle.Parent == null)
            {
                Root = discSpaceRectangle;
            }
        }

        public void Loaded()
        {
            FocusedRectangle = Root;
            RaisePropertyChanged("DiscSpaceRectangles");
        }

        public DiscSpaceRectangle Map(DiscSpace space)
        {
            if (space == null || !mapping.ContainsKey(space))
            {
                return null;
            }
            return mapping[space];
        }
    }
}
