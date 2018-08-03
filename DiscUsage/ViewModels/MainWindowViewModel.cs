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

            DiscSpaceCanvasViewModel.Manager.Created += DiscSpaceManager_Created;
            DiscSpaceCanvasViewModel.Manager.Loaded += DiscSpaceCanvasViewModel.Loaded;
            //DiscSpaceCanvasViewModel.Manager.Updated += DiscSpaceCanvasViewModel.Update;
            DiscSpaceCanvasViewModel.Manager.Created += DiscSpaceCanvasViewModel.Create;

            var task=discCache.LoadAsync(@"C:\Users\Oliver");
            //var task = discCache.LoadAsync(@"C:\Users\Oliver");
            IsLoaded = true;
        }

        public DelegateCommand LoadCommand { get; set; }
        private int Counter = 0;
        private void DiscSpaceManager_Created(DiscSpace space)
        {
            //DiscSpaceCanvasViewModel.Add(DiscSpaceCanvasViewModel.Manager.Root.OrderedChildren);
            //RaisePropertyChanged("DiscSpaces");
            //DiscSpaceControl.DataContext = discSpaceViewModel;
            Counter++;
        }

        //private void DiscSpaceCanvasControl_Loaded()
        //{
        //   // DiscSpaceCanvasViewModel.Loaded(null);
        //    //RaisePropertyChanged("DiscSpaceCanvasViewModel");
        //    //DiscSpaceCanvasControl.DataContext = discSpaceCanvasViewModel;
        //}
    }
}
