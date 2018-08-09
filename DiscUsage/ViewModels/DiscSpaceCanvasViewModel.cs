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
            Manager.CreateNewDiscSpace += Manager_CreateNewDiscSpace;
            UseAdvancedAlgoForLayout = false;
        }

        private DiscSpace Manager_CreateNewDiscSpace(DiscSpaceManager manager, DiscSpace parent, string name, string fullname)
        {
            return new DiscSpaceRectangle(this,manager, parent, name, fullname);
        }

        private double _Width = 100;
        public double Width
        {
            get { return _Width; }
            set { SetProperty(ref _Width, value); }
        }

        private double _Height=100;
        public double Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height, value); }
        }

        private ObservableCollection<DiscSpaceRectangle> _VisibleRectangles=new ObservableCollection<DiscSpaceRectangle>();
        public ObservableCollection<DiscSpaceRectangle> VisibleRectangles
        {
            get { return _VisibleRectangles; }
            set { SetProperty(ref _VisibleRectangles,value); }
        }
        public ObservableCollection<DiscSpaceRectangle> Rectangles = new ObservableCollection<DiscSpaceRectangle>();

        private DiscSpaceRectangle _VisibleRoot;
        public DiscSpaceRectangle VisibleRoot
        {
            get { return _VisibleRoot; }
            set
            {
                SetProperty(ref _VisibleRoot, value);
                Rectangles.Clear();
                VisibleRectangles.Clear();
                Rectangles.Add(VisibleRoot);
                VisibleRoot.ChildrenRecursive.OrderBy(x=>x.Level).ToList().ForEach(x => Rectangles.Add((DiscSpaceRectangle)x));
      
                RaiseAllEvents();
            }
        }

        private DiscSpaceRectangle _FocusedRectangle;
        public DiscSpaceRectangle FocusedRectangle
        {
            get { return _FocusedRectangle; }
            set { SetProperty(ref _FocusedRectangle, value); }
        }

        private DiscSpaceRectangle _SelectedRectangle;
        public DiscSpaceRectangle SelectedRectangle
        {
            get { return _SelectedRectangle; }
            set { SetProperty(ref _SelectedRectangle, value); }
        }

        private System.Threading.SynchronizationContext _uiContext;

        public override void Create(DiscSpace space)
        {
            base.Create(space);
            if (_uiContext == null)
            {
                _uiContext = System.Threading.SynchronizationContext.Current;
            }

            var rectangle = (DiscSpaceRectangle)space;

            if (VisibleRoot == null || VisibleRoot.IsParentRecursive(rectangle))
            {
                if (!Rectangles.Contains(rectangle))
                {
                    Rectangles.Add(rectangle);
                }
                
            }
            if (space.Parent == null)
            {
                _VisibleRoot = rectangle;
            }
            Debug.Assert(rectangle.ManagerRectangle!=null);
        }

        public override void Loaded(DiscSpace space)
        {
            base.Loaded(space);
            if (space == Manager.Root)
            {
                int i = 0;
                IsTimerEnabled = false;
            }
            else
            {
                IsTimerEnabled = true;
            }
        }

        public void RaiseAllEvents()
        {

            foreach (var rectangle in Rectangles)
            {
                rectangle.ReCalcProperties();

            }
            var bigRectangles = Rectangles.Where(x => x.Width >= 6 && x.Height >= 6).ToList();

            // add
            var notInRectangles=bigRectangles.Where(x => !VisibleRectangles.Contains(x)).ToList();
            notInRectangles.ForEach(x => VisibleRectangles.Add(x));

            //remove
            var notInBigRectangles = VisibleRectangles.Where(x => !bigRectangles.Contains(x)).ToList();
            notInBigRectangles.ForEach(x => VisibleRectangles.Remove(x));

            foreach (var rectangle in VisibleRectangles)
            {
                rectangle.IsCurrentlyLoading = !rectangle.IsLoaded && rectangle.Children.Where(x => !x.IsLoaded && VisibleRectangles.Contains(x)).Count() == 0;
                rectangle.RaisePropertiesChanged();
            }
            var loading = VisibleRectangles.Where(x => x.IsCurrentlyLoading).ToList();
            //Debug.Assert(loading.Count== 1);
            if (loading.Count>1)
            {
                var i = 0;
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

        public bool UseAdvancedAlgoForLayout { get; set; }

        /// <summary>
        /// hack to avoid multiple timer waiting for update
        /// </summary>
        private bool timerHackRunning = false;

        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timerHackRunning)
            {
                return;
            }
            timerHackRunning = true;
            if (_uiContext != null)
            {
                _uiContext.Send(x => RaiseAllEvents(), null);
            }
            else
            {
                RaiseAllEvents();
            }
            
            timerHackRunning = false;
            
        }
    }
}
