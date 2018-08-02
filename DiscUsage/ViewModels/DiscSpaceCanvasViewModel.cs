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
using System.Diagnostics;

namespace DiscUsage.ViewModels
{
    public class DiscSpaceCanvasViewModel : DiscSpaceViewModel
    {

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

        //public void Update(DiscSpace space)
        //{
        //    //Update((DiscSpaceRectangle)space);
        //}

        //private void Update(DiscSpaceRectangle discSpaceRectangle)
        //{
        //    discSpaceRectangle.RaisePropertiesChanged();
        //}

        public void Add(DiscSpace space)
        {

        }

        public void Loaded(DiscSpace space)
        {
            var rectangle = (DiscSpaceRectangle)space;
            rectangle.ManagerRectangle = this;
            FocusedRectangle = Root;
            //var rectangle = (DiscSpaceRectangle)space;
            DiscSpaceRectangles.Add(rectangle);
            //var rectangles = DiscSpaceRectangles.OrderBy(x => x.Level).ToList();
            //DiscSpaceRectangles.Clear();
            //rectangles.ForEach(x => DiscSpaceRectangles.Add(x));
            Debug.Assert(rectangle.ManagerRectangle!=null);
            RaiseAllEvents();
            if (space == Root)
            {
                int i = 0;
            }
        }

        private void RaiseAllEvents()
        {
            foreach (var rectangle in DiscSpaceRectangles)
            {
                rectangle.RaisePropertiesChanged();
            }
        }
    }
}
