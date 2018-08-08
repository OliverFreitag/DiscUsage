using DiscUsage.Model;
using DiscUsage.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DiscUsage.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainWindowViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = (MainWindowViewModel)this.DataContext;
            //this.DiscSpaceControl.DataContext = _vm.DiscSpaceCanvasViewModel;
            this.DiscSpaceCanvasControl.DataContext = _vm.DiscSpaceCanvasViewModel;
            this.PathListControl.DataContext = _vm.PathDiscSpace;
            this.SelectedSpacesListControl.DataContext = _vm.SelectedDiscSpace;
            //this.DiscSpaceCanvasControl2.DataContext = _vm.DiscSpaceCanvasViewModel2;
        }


    }
}
