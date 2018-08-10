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

        public DiscSpaceManager Manager = new DiscSpaceManager();

        public DiscSpaceViewModel()
        {
            DeleteCommand = new DelegateCommand(OnDelete).ObservesCanExecute(()=> IsDiscSpaceSelected);
            BackupCommand = new DelegateCommand(OnBackup).ObservesCanExecute(() => IsDiscSpaceSelected);
            HideCommand = new DelegateCommand(OnHide).ObservesCanExecute(() => IsDiscSpaceSelected);
        }


        public bool IsDiscSpaceSelected => Selected != null;
        private DiscSpace _selected;

        public DiscSpace Selected
        {
            get { return _selected; }
            set {
                SetProperty(ref _selected, value);
                RaisePropertyChanged("IsDiscSpaceSelected");
            }
        }

        private void OnDelete()
        {
            DiscSpaces.Remove(Selected);
        }

        private void OnBackup()
        {
            DiscSpaces.Remove(Selected);
        }

        private void OnHide()
        {
            DiscSpaces.Remove(Selected);
        }

        private ObservableCollection<DiscSpace> _DiscSpaces = new ObservableCollection<DiscSpace>();

        public ObservableCollection<DiscSpace> DiscSpaces
        {
            get { return _DiscSpaces; }
            set { SetProperty(ref _DiscSpaces, value); }
        }

        public virtual void Create(DiscSpace space)
        {
            //if (space.Parent == Manager.Root)
            //{
            //    SourceDiscSpaces.Add(space);
            //}
            
        }

        public void Add(List<DiscSpace> spaces)
        {

            var spacesCollection = new ObservableCollection<DiscSpace>();
            foreach (var space in spaces)
            {
                spacesCollection.Add(space);
            }
            DiscSpaces = spacesCollection;
        }

        public virtual void Loaded(DiscSpace space)
        {
           
        }
    }
}
