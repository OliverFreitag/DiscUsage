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
using System.Timers;

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
        private System.Threading.SynchronizationContext _uiContext;
        public void Create(DiscSpace space)
        {
            if (_uiContext == null)
            {
                _uiContext = System.Threading.SynchronizationContext.Current;
            }
           
            var rectangle = (DiscSpaceRectangle)space;
            rectangle.ManagerRectangle = this;
            FocusedRectangle = Root;
            //var rectangle = (DiscSpaceRectangle)space;
            DiscSpaceRectangles.Add(rectangle);
            //var rectangles = DiscSpaceRectangles.OrderBy(x => x.Level).ToList();
            //DiscSpaceRectangles.Clear();
            //rectangles.ForEach(x => DiscSpaceRectangles.Add(x));
            Debug.Assert(rectangle.ManagerRectangle!=null);
            //RaiseAllEvents();

        }

        internal void Loaded(DiscSpace space)
        {
            if (space == Root)
            {
                int i = 0;
                IsTimerEnabled = false;
            }
            else
            {
                IsTimerEnabled = true;
            }
        }

        private void RaiseAllEvents()
        {
            foreach (var rectangle in DiscSpaceRectangles)
            {
                rectangle.RaisePropertiesChanged();
            }
        }

        private Timer _Timer;

        public bool IsTimerEnabled
        {
            get
            {
                return _Timer != null;
            }
            set
            {
                if (value)
                {
                    if (_Timer == null)
                    {
                        _Timer = new Timer(1000);
                        _Timer.Elapsed += _Timer_Elapsed;
                        _Timer.Start();
                    }
                }
                else
                {
                    if (_Timer != null)
                    {
                        _Timer.Stop();
                        _Timer = null;
                        _Timer_Elapsed(null, null);
                    }
                }
            }
        }
        private bool timerHackRunning = false;

        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timerHackRunning)
            {
                return;
            }
            timerHackRunning = true;
            _uiContext.Send(x => RaiseAllEvents(),null);
            timerHackRunning = false;
            
        }
    }
}
