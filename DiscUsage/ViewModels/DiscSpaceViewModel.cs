using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DiscUsage.Model;
using Prism.Commands;
using Prism;
using Prism.Mvvm;

namespace DiscUsage.ViewModels
{
    public class DiscSpaceViewModel : BindableBase
    {
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand BackupCommand { get; set; }
        public DelegateCommand HideCommand { get; set; }

        public DiscSpaceViewModel()
        {
            DeleteCommand = new DelegateCommand(OnDelete).ObservesCanExecute(()=> IsDiscSpaceSelected);
            BackupCommand = new DelegateCommand(OnBackup).ObservesCanExecute(() => IsDiscSpaceSelected);
            HideCommand = new DelegateCommand(OnHide).ObservesCanExecute(() => IsDiscSpaceSelected);
        }


        public bool IsDiscSpaceSelected => SelectedDiscSpace != null;
        private DiscSpace _selectedDiscSpace;

        public DiscSpace SelectedDiscSpace
        {
            get { return _selectedDiscSpace; }
            set {
                SetProperty(ref _selectedDiscSpace, value);
                RaisePropertyChanged("IsDiscSpaceSelected");
            }
        }

        private void OnDelete()
        {
            SourceDiscSpaces.Remove(SelectedDiscSpace);
        }

        private void OnBackup()
        {
            SourceDiscSpaces.Remove(SelectedDiscSpace);
        }

        private void OnHide()
        {
            SourceDiscSpaces.Remove(SelectedDiscSpace);
        }

        private ObservableCollection<DiscSpace> _SourceDiscSpaces;

        public ObservableCollection<DiscSpace> SourceDiscSpaces
        {
            get { return _SourceDiscSpaces; }
            set { SetProperty(ref _SourceDiscSpaces, value); }
        }

        public void Add(List<DiscSpace> spaces)
        {            
            var spacesCollection = new ObservableCollection<DiscSpace>();
            foreach(var space in spaces)
            {
                spacesCollection.Add(space);
            }
            SourceDiscSpaces = spacesCollection;
        }
    }
}
