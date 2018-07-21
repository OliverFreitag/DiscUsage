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
           // Load();
            LoadCommand = new DelegateCommand(Load).ObservesCanExecute(()=>CanLoad);
        }

        private DiscCache discCache = new DiscCache();
        private DiscSpaceManager discSpaceManager = new DiscSpaceManager();

        public DiscSpaceViewModel DiscSpaceViewModel = new DiscSpaceViewModel();
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

        public ObservableCollection<DiscSpace> DiscSpaces => DiscSpaceViewModel.SourceDiscSpaces;

        private void Load()
        {
            IsLoading = true;
            discCache.Created += discSpaceManager.Added;
            discCache.Loaded += discSpaceManager.Load;

            discSpaceManager.Loaded += DiscSpaceManager_Loaded;
            discSpaceManager.Created += DiscSpaceCanvasViewModel.Add;
            discSpaceManager.Updated += DiscSpaceCanvasViewModel.Update;

            discCache.LoadAsync(@"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples");
            DiscSpaceCanvasControl_Loaded();
            IsLoaded = true;
        }

        public DelegateCommand LoadCommand { get; set; }

        private void DiscSpaceManager_Loaded(DiscSpace space)
        {
            DiscSpaceViewModel.Add(discSpaceManager.Root.OrderedChildren);
            RaisePropertyChanged("DiscSpaces");
            //DiscSpaceControl.DataContext = discSpaceViewModel;
        }

        private void DiscSpaceCanvasControl_Loaded()
        {
            DiscSpaceCanvasViewModel.Loaded();
            RaisePropertyChanged("DiscSpaceCanvasViewModel");
            //DiscSpaceCanvasControl.DataContext = discSpaceCanvasViewModel;
        }
    }
}
