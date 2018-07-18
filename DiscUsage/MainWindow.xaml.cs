using DiscUsage.Model;
using DiscUsage.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiscUsage
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DiscCache discCache = new DiscCache();
        private DiscSpaceManager discSpaceManager = new DiscSpaceManager();
        private DiscSpaceViewModel viewModel = new DiscSpaceViewModel();

        private void DiscSpaceControl_Loaded(object sender, RoutedEventArgs e)
        {
            discCache.Created += discSpaceManager.Added;
            discCache.Loaded += discSpaceManager.Load;

            discSpaceManager.Loaded += DiscSpaceManager_Loaded;
            discCache.Load(@"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples");
        }

        private void DiscSpaceManager_Loaded(DiscSpace space)
        {
            viewModel.Add(discSpaceManager.Root.OrderedChildren);
            DiscSpaceControl.DataContext = viewModel;
        }
    }
}
