using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DiscUsage.Model;

namespace DiscUsage.ViewModel
{
    public class DiscSpaceViewModel
    {
        public TestCommand DeleteCommand { get; set; }

        public DiscSpaceViewModel()
        {
            DeleteCommand = new TestCommand(OnDelete, CanDelete);
        }

        private DiscSpace _selectedDiscSpace;

        public DiscSpace SelectedDiscSpace
        {
            get
            {
                return _selectedDiscSpace;
            }
            set
            {
                _selectedDiscSpace = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnDelete()
        {
            DiscSpaces.Remove(SelectedDiscSpace);
        }

        private bool CanDelete()
        {
            return SelectedDiscSpace != null;
        }

        public ObservableCollection<DiscSpace> DiscSpaces
        {
            get;
            set;
        }

        public void Add(List<DiscSpace> spaces)
        {
            var spacesCollection = new ObservableCollection<DiscSpace>();
            foreach(var space in spaces)
            {
                spacesCollection.Add(space);
            }
            DiscSpaces = spacesCollection;
        }
    }
}
