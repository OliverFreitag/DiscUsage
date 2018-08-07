using DiscUsage.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.ViewModels
{
    public class DiscSpaceListViewModel: DiscSpaceViewModel
    {
        private DiscSpace _selectedDiscSpaceRecursive;

        public DiscSpace SelectedDiscSpaceRecursive
        {
            get { return _selectedDiscSpaceRecursive; }
            set
            {
                SetProperty(ref _selectedDiscSpaceRecursive, value);
            }
        }
    }
}
