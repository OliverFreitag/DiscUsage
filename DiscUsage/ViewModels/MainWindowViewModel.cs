using DiscUsage.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            LoadCommand = new DelegateCommand(Load).ObservesCanExecute(()=>CanLoad);
            DiscSpaceCanvasViewModel.PropertyChanged += DiscSpaceCanvasViewModel_PropertyChanged1;
        }

        private void DiscSpaceCanvasViewModel_PropertyChanged1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //if (e.PropertyName== "FocusedRectangle")
            //{
            //    UpdateCurrentDirectory(DiscSpaceCanvasViewModel.FocusedRectangle);
            //}

            // rectangle in the canvas has been selected
            if (e.PropertyName == "SelectedRectangle")
            {
                UpdateCurrentDirectory(DiscSpaceCanvasViewModel.SelectedRectangle);
                DiscSpaceCanvasViewModel.VisibleRoot = DiscSpaceCanvasViewModel.SelectedRectangle;
            }
            // disc space in list view has been selected
            if (e.PropertyName == "SelectedDiscSpace")
            {
                if (DiscSpaceCanvasViewModel.SelectedDiscSpace == null)
                {
                    var i = 0;
                    return;
                }
                // select this disc space
                UpdateCurrentDirectory(DiscSpaceCanvasViewModel.SelectedDiscSpace);
                DiscSpaceCanvasViewModel.VisibleRoot = (DiscSpaceRectangle)DiscSpaceCanvasViewModel.SelectedDiscSpace;

            }
        }

        private void UpdateCurrentDirectory(DiscSpace rectangle)
        {
            DiscSpaceListViewModel.SourceDiscSpaces.Clear();
            var current = rectangle;
            while (current != null)
            {
                DiscSpaceListViewModel.SourceDiscSpaces.Insert(0,current);
                current = (DiscSpaceRectangle)current.Parent;
              
            }

            DiscSpaceCanvasViewModel.SourceDiscSpaces.Clear();
            var current1 = rectangle;
            while (current1 != null)
            {
                DiscSpaceCanvasViewModel.SourceDiscSpaces.Insert(0, current1);
                current1 = (DiscSpaceRectangle)current1.Parent;

            }
        }

        private DiscCache discCache = new DiscCache();

        public DiscSpaceCanvasViewModel DiscSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();
        public DiscSpaceCanvasViewModel DiscSpaceCanvasViewModel2 = new DiscSpaceCanvasViewModel();
        // public DiscSpaceViewModel DiscSpaceViewModel = new DiscSpaceViewModel();
        public DiscSpaceListViewModel DiscSpaceListViewModel =new DiscSpaceListViewModel();

        private bool _IsLoaded;
        public bool IsLoaded {
            get { return _IsLoaded; }
            set {
                SetProperty(ref _IsLoaded, value);
                RaisePropertyChanged("CanLoad");
            }
        }

        private bool _IsLoading;
        public bool IsLoading {
            get { return _IsLoading; }
            set {
                SetProperty(ref _IsLoading, value);
                RaisePropertyChanged("CanLoad");
            }
        }
        public bool CanLoad => !IsLoaded || !IsLoading;

        public ObservableCollection<DiscSpace> DiscSpaces => DiscSpaceCanvasViewModel.SourceDiscSpaces;

        private void Load()
        {
            RootDirectory = @"C:\";
            IsLoading = true;
            discCache.Created += DiscSpaceCanvasViewModel.Manager.Create;
            discCache.Loaded += DiscSpaceCanvasViewModel.Manager.Load;

            DiscSpaceCanvasViewModel.Manager.Loaded += DiscSpaceCanvasViewModel.Loaded;
            //DiscSpaceCanvasViewModel.Manager.Updated += DiscSpaceCanvasViewModel.Update;
            DiscSpaceCanvasViewModel.Manager.Created += DiscSpaceCanvasViewModel.Create;
            DiscSpaceCanvasViewModel.PropertyChanged += DiscSpaceCanvasViewModel_PropertyChanged;
            var task=discCache.LoadAsync(RootDirectory);

            //var task = discCache.LoadAsync(@"C:\");
            IsLoaded = true;
        }

        private void DiscSpaceCanvasViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //if (e.PropertyName== "FocusedRectangle")
            //{
            //    DiscSpaceCanvasViewModel2.DiscSpaceRectanglesInternal.Clear();
            //    if (DiscSpaceCanvasViewModel.FocusedRectangle != null)
            //    {
            //        var parentAndChildren = DiscSpaceCanvasViewModel.Manager.Mapping.Values.Where(x => DiscSpaceCanvasViewModel.FocusedRectangle.ChildrenRecursive.Contains(x) || x == DiscSpaceCanvasViewModel.FocusedRectangle).ToList();
            //        Copy(parentAndChildren).ForEach(x => DiscSpaceCanvasViewModel2.DiscSpaceRectanglesInternal.Add((DiscSpaceRectangle)x));
            //        DiscSpaceCanvasViewModel2.RaiseAllEvents();
            //    }
            //}
        }

        //private List<DiscSpaceRectangle> Copy(List<DiscSpace> spaces)
        //{
        //    var manager = DiscSpaceCanvasViewModel2.Manager;
        //    List<DiscSpaceRectangle> rectangles = new List<DiscSpaceRectangle>();
        //    var mapping = new Dictionary<DiscSpace, DiscSpaceRectangle>();
        //    foreach(var space in spaces.OrderBy(x=>x.Level))
        //    {
        //        var parent =space.Parent == null ? null : mapping.ContainsKey(space.Parent)?mapping[space.Parent]:null;
        //        var rectangle = new DiscSpaceRectangle(manager, parent, space.Name, space.FullName)
        //        {
        //            Length = space.Length,
        //            Count = space.Count,
        //            IsLoaded = space.IsLoaded,
        //            ManagerRectangle= DiscSpaceCanvasViewModel2
        //            //OrderedChildren = space.OrderedChildren.Select(x => (DiscSpace)mapping[x]).ToList()

        //        };
        //        mapping[space] = rectangle;
        //        rectangles.Add(rectangle);
        //    }
        //    foreach (var space in spaces)
        //    {
        //        var rectangle = mapping[space];
        //        if (space.OrderedChildren != null)
        //        {
        //            rectangle.OrderedChildren = space.OrderedChildren.Select(x => (DiscSpace)mapping[x]).ToList();
        //        }
                
        //    }
        //    return rectangles;
        //}

        public DelegateCommand LoadCommand { get; set; }

        private String _RootDirectory;
        public String RootDirectory {
            get { return _RootDirectory; }
            set {
                SetProperty(ref _RootDirectory, value);
            }
        }

    
    }
}
