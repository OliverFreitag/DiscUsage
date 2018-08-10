using DiscUsage.Model;
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
    /// Interaktionslogik für DiscSpaceListView.xaml
    /// </summary>
    public partial class DiscSpaceListView : UserControl
    {
        public DiscSpaceListView()
        {
            InitializeComponent();
        }

        public ObservableCollection<DiscSpace> DiscSpacesAtControl
        {
            get {
                return (ObservableCollection<DiscSpace>)GetValue(DiscSpacesProperty); }
            set {
                SetValue(DiscSpacesProperty, value); }
        }

        public static readonly DependencyProperty DiscSpacesProperty = DependencyProperty.Register(
            "DiscSpacesAtControl", 
            typeof(ObservableCollection<DiscSpace>),
            typeof(DiscSpaceListView),
            new PropertyMetadata(null, OnDiscSpacesSet));

        private static void OnDiscSpacesSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //((DiscSpaceListView)d).._vm.DiscSpaces = e.NewValue as ObservableCollection<DiscSpace>;
        }

        public DiscSpace SelectedDiscSpace
        {
            get { return (DiscSpace)GetValue(SelectedDiscSpaceProperty); }
            set { SetValue(SelectedDiscSpaceProperty, value); }
        }

        public static readonly DependencyProperty SelectedDiscSpaceProperty = DependencyProperty.Register(
            "SelectedDiscSpace", 
            typeof(DiscSpace),
            typeof(DiscSpaceListView), 
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        private static void OnSelected(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //((DiscSpaceListView)d).._vm.DiscSpaces = e.NewValue as ObservableCollection<DiscSpace>;
        }
    }
}
