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
            PathDiscSpace.PropertyChanged += DiscSpaceCanvasViewModel_PropertyChanged;
            DiscSpaceCanvasViewModel.PropertyChanged += DiscSpaceCanvasViewModel_PropertyChanged;
            DiscSpaceCanvasViewModel.DiscSpaceRectangles.CollectionChanged += DiscSpaceRectangles_CollectionChanged;
        }

        private void DiscSpaceRectangles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                UpdatePathList(DiscSpaceCanvasViewModel.VisibleRoot);
            }
        }

        private void DiscSpaceCanvasViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // rectangle in the canvas has been selected
            if (e.PropertyName == "SelectedRectangle")
            {
                UpdatePathList(DiscSpaceCanvasViewModel.SelectedRectangle);
                DiscSpaceCanvasViewModel.VisibleRoot = DiscSpaceCanvasViewModel.SelectedRectangle;
            }
            // disc space in list view has been selected
            if (e.PropertyName == "SelectedDiscSpace")
            {
                if (PathDiscSpace.SelectedDiscSpace == null)
                {
                    return;
                }
                // select this disc space
                UpdatePathList(PathDiscSpace.SelectedDiscSpace);
                DiscSpaceCanvasViewModel.VisibleRoot = (DiscSpaceRectangle)PathDiscSpace.SelectedDiscSpace;
            }
        }

        private void UpdatePathList(DiscSpace rectangle)
        {
            PathDiscSpace.SourceDiscSpaces.Clear();
            var current = rectangle;
            while (current != null)
            {
                PathDiscSpace.SourceDiscSpaces.Insert(0,current);
                current = (DiscSpaceRectangle)current.Parent;
            }
        }

        private DiscCache discCache = new DiscCache();

        public DiscSpaceCanvasViewModel DiscSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();
        public DiscSpaceListViewModel PathDiscSpace =new DiscSpaceListViewModel();
        public DiscSpaceListViewModel SelectedDiscSpace = new DiscSpaceListViewModel();

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
            var task=discCache.LoadAsync(RootDirectory);

            IsLoaded = true;
        }

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
