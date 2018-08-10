using DiscUsage.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            LoadCommand = new DelegateCommand(Load).ObservesCanExecute(()=>CanLoad);
            //PathDiscSpace.PropertyChanged += DiscSpaceCanvasViewModel_PropertyChanged;
            DiscSpaceCanvasViewModel.PropertyChanged += DiscSpaceCanvasViewModel_PropertyChanged;
            DiscSpaceCanvasViewModel.VisibleRectangles.CollectionChanged += DiscSpaceRectangles_CollectionChanged;

            RootDirectory = @"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples";
            
            discCache.Created += DiscSpaceCanvasViewModel.Manager.Create;
            discCache.Loaded += DiscSpaceCanvasViewModel.Manager.Load;

            DiscSpaceCanvasViewModel.Manager.Loaded += DiscSpaceCanvasViewModel.Loaded;
            //DiscSpaceCanvasViewModel.Manager.Updated += DiscSpaceCanvasViewModel.Update;
            DiscSpaceCanvasViewModel.Manager.Created += DiscSpaceCanvasViewModel.Create;
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
                if (DiscSpaceCanvasViewModel.SelectedRectangle != null)
                {
                    UpdatePathList(DiscSpaceCanvasViewModel.SelectedRectangle);
                    DiscSpaceCanvasViewModel.VisibleRoot = DiscSpaceCanvasViewModel.SelectedRectangle;
                }

            }
            
            // rectangle in the canvas has been focused
            if (e.PropertyName == "FocusedRectangle")
            {
                if (DiscSpaceCanvasViewModel.FocusedRectangle != null)
                {
                    SelectedDiscSpaces.Clear();
                    DiscSpaceCanvasViewModel.FocusedRectangle.Children.ForEach(x => SelectedDiscSpaces.Add(x));
                    RaisePropertyChanged("SelectedDiscSpaces");
                }

            }
        }

        private void UpdatePathList(DiscSpace rectangle)
        {
            PathDiscSpaces.Clear();
            var current = rectangle;
            while (current != null)
            {
                PathDiscSpaces.Insert(0,current);
                current = (DiscSpaceRectangle)current.Parent;
            }
        }

        private DiscCache discCache = new DiscCache();

        public DiscSpaceCanvasViewModel DiscSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();

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

        // disc space in list view has been selected
        private ObservableCollection<DiscSpace> _SelectedDiscSpaces = new ObservableCollection<DiscSpace>();

        public ObservableCollection<DiscSpace> SelectedDiscSpaces
        {
            get { return _SelectedDiscSpaces; }
            set { SetProperty(ref _SelectedDiscSpaces, value); }
        }


        private ObservableCollection<DiscSpace> _PathDiscSpaces = new ObservableCollection<DiscSpace>();

        public ObservableCollection<DiscSpace> PathDiscSpaces
        {
            get { return _PathDiscSpaces; }
            set { SetProperty(ref _PathDiscSpaces, value); }
        }

        private DiscSpace _SelectedPath;

        public DiscSpace SelectedPath
        {
            get { return _SelectedPath; }
            set {
                SetProperty(ref _SelectedPath, value);
                UpdatePathList(_SelectedPath);
                DiscSpaceCanvasViewModel.VisibleRoot = (DiscSpaceRectangle)_SelectedPath;
            }
        }


        private Task loadTask;
        private void Load()
        {
            IsLoading = true;
            loadTask = discCache.LoadAsync(RootDirectory);
            IsLoaded = true;
            IsLoading = false;
        }

        public void Wait()
        {
            loadTask.Wait();
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
