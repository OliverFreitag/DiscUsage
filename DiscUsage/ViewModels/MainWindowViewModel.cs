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
        }

        private DiscCache discCache = new DiscCache();

        public DiscSpaceCanvasViewModel DiscSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();
        public DiscSpaceCanvasViewModel DiscSpaceCanvasViewModel2 = new DiscSpaceCanvasViewModel();

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
            IsLoading = true;
            discCache.Created += DiscSpaceCanvasViewModel.Manager.Create;
            discCache.Loaded += DiscSpaceCanvasViewModel.Manager.Load;

            DiscSpaceCanvasViewModel.Manager.Loaded += DiscSpaceCanvasViewModel.Loaded;
            //DiscSpaceCanvasViewModel.Manager.Updated += DiscSpaceCanvasViewModel.Update;
            DiscSpaceCanvasViewModel.Manager.Created += DiscSpaceCanvasViewModel.Create;
            DiscSpaceCanvasViewModel.PropertyChanged += DiscSpaceCanvasViewModel_PropertyChanged;
            var task=discCache.LoadAsync(@"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples");
            //var task = discCache.LoadAsync(@"C:\Users\Oliver");
            IsLoaded = true;
        }

        private void DiscSpaceCanvasViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName== "FocusedRectangle")
            {
                DiscSpaceCanvasViewModel2.DiscSpaceRectangles.Clear();
                if (DiscSpaceCanvasViewModel.FocusedRectangle != null)
                {
                    DiscSpaceCanvasViewModel.FocusedRectangle.ChildrenRecursive.ForEach(x => DiscSpaceCanvasViewModel2.DiscSpaceRectangles.Add((DiscSpaceRectangle)x));
                }
                
            }
        }

        public DelegateCommand LoadCommand { get; set; }

    }
}
