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

        public bool IsLoaded { get; set; }
        public bool IsLoading { get; set; }
        public bool CanLoad => !IsLoaded || !IsLoading;


        public ObservableCollection<DiscSpace> DiscSpaces => DiscSpaceViewModel.SourceDiscSpaces;

        private void Load()
        {
            IsLoading = true;
            discCache.Created += discSpaceManager.Added;
            discCache.Loaded += discSpaceManager.Load;

            discSpaceManager.Loaded += DiscSpaceManager_Loaded;
            discCache.Load(@"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples");
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
            DiscSpaceCanvasViewModel.Add(discSpaceManager.OrderedByLevel);
            RaisePropertyChanged("DiscSpaceCanvasViewModel");
            //DiscSpaceCanvasControl.DataContext = discSpaceCanvasViewModel;
        }
    }
}
