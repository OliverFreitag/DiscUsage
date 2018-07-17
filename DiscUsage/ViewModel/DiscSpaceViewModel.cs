using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DiscUsage.ViewModel
{
    public class DiscSpaceViewModel
    {
        public DiscSpaceViewModel()
        {
        }

        public ObservableCollection<DiscSpace.DiscSpace> DiscSpaces
        {
            get;
            set;
        }

        public void Add(List<DiscSpace.DiscSpace> spaces)
        {
            var spacesCollection = new ObservableCollection<DiscSpace.DiscSpace>();
            foreach(var space in spaces)
            {
                spacesCollection.Add(space);
            }
        }
    }
}
