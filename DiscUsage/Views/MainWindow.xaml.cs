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
            this.DiscSpaceControl.DataContext = _vm.DiscSpaceCanvasViewModel;
            this.DiscSpaceCanvasControl.DataContext = _vm.DiscSpaceCanvasViewModel;
            this.DiscSpaceListControl.DataContext = _vm.DiscSpaceListViewModel;
            //this.DiscSpaceCanvasControl2.DataContext = _vm.DiscSpaceCanvasViewModel2;
        }

        //public ObservableCollection<DiscSpace> DiscSpaces
        //{
        //    get { return (ObservableCollection<DiscSpace>)GetValue(DiscSpacesProperty); }
        //    set { SetValue(DiscSpacesProperty, value); }
        //}

        //public static readonly DependencyProperty DiscSpacesProperty =
        //    DependencyProperty.Register("DiscSpaces", typeof(ObservableCollection<DiscSpace>),
        //        typeof(MainWindow), new PropertyMetadata(null, OnDiscSpacesSet));

        //private static void OnDiscSpacesSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //  //  ((MainWindow)d)._vm.DiscSpaces = e.NewValue as ObservableCollection<DiscSpace>;
        //}
    }
}
