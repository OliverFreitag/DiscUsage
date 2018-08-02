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
    public class DiscSpaceCanvasViewModel : DiscSpaceViewModel
    {
        //private Dictionary<DiscSpace, DiscSpaceRectangle> mapping = new Dictionary<DiscSpace, DiscSpaceRectangle>();

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

        public DiscSpaceRectangle Root => (DiscSpaceRectangle)Manager.Root;

        private DiscSpaceRectangle _FocusedRectangle;
        public DiscSpaceRectangle FocusedRectangle
        {
            get { return _FocusedRectangle; }
            set { SetProperty(ref _FocusedRectangle, value); }
        }

        public void Update(DiscSpace space)
        {
            //var discSpaceRectangle = Manager.Map(space);
            Update((DiscSpaceRectangle)space);
        }

        public void Update(DiscSpaceRectangle discSpaceRectangle)
        {
            //discSpaceRectangle.OwnLength = space.OwnLength;
            //discSpaceRectangle.LengthOfAllPreviousChildren = space.LengthOfAllPreviousChildren;
            discSpaceRectangle.RaisePropertiesChanged();
        }

        private void UpdateAll()
        {

            foreach(var keyValuePair in Manager.Mapping)
            {
                Update(keyValuePair.Value);
            }
        }

        public void Add(DiscSpace space)
        {
            //var discSpaceRectangle = new DiscSpaceRectangle(space.Manager,space.Parent,space.Name,space.FullName);
            ////discSpaceRectangle.Children = space.Children.ConvertAll(x=>(DiscSpace)Map(x));
            //_DiscSpaceRectangles.Add(discSpaceRectangle);
            //mapping[space] = discSpaceRectangle;

            //if (discSpaceRectangle.Parent != null)
            //{
            //    discSpaceRectangle.Parent = mapping[discSpaceRectangle.Parent];
            //    discSpaceRectangle.Parent.Children = space.Parent.Children.ConvertAll(x => (DiscSpace)Map(x));
            //}
            //if (discSpaceRectangle.Parent == null)
            //{
            //    Root = discSpaceRectangle;
            //}
            var rectangle = (DiscSpaceRectangle)space;
            rectangle.ManagerRectangle = this;
            RaiseAllEvents();
        }

        public void Loaded(DiscSpace space)
        {
            FocusedRectangle = Root;
            DiscSpaceRectangles.Add((DiscSpaceRectangle)space);
            RaiseAllEvents();
        }

        //public DiscSpaceRectangle Map(DiscSpace space)
        //{
        //    if (space == null || !mapping.ContainsKey(space))
        //    {
        //        return null;
        //    }
        //    return mapping[space];
        //}

        //public DiscSpace MapBack(DiscSpaceRectangle space)
        //{
        //    if (!mapping.ContainsValue(space))
        //    {
        //        return null;
        //    }
        //    return mapping.FirstOrDefault(x => x.Value == space).Key;
        //}

        private void RaiseAllEvents()
        {
            UpdateAll();
            RaisePropertyChanged("DiscSpaceRectangles");
            foreach (var s in DiscSpaceRectangles)
            {
                s.RaisePropertiesChanged();
            }
        }
    }
}
