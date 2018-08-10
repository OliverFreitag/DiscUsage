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
    /// Interaktionslogik für DiscSpaceCanvasView.xaml
    /// </summary>
    public partial class DiscSpaceCanvasView : UserControl
    {
        public DiscSpaceCanvasView()
        {
            InitializeComponent();
        }

        public ObservableCollection<DiscSpaceRectangle> Rectangles
        {
            get { return (ObservableCollection<DiscSpaceRectangle>)GetValue(RectanglesProperty); }
            set { SetValue(RectanglesProperty, value); }
        }

        public static readonly DependencyProperty RectanglesProperty = DependencyProperty.Register(
            "Rectangles",
            typeof(ObservableCollection<DiscSpaceRectangle>),
            typeof(DiscSpaceCanvasView),
            new PropertyMetadata(null, OnDiscSpacesSet));

        private static void OnDiscSpacesSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //((DiscSpaceListView)d).._vm.DiscSpaces = e.NewValue as ObservableCollection<DiscSpace>;
        }

        public DiscSpace SelectedRectangle
        {
            get { return (DiscSpace)GetValue(SelectedRectangleProperty); }
            set { SetValue(SelectedRectangleProperty, value); }
        }

        public static readonly DependencyProperty SelectedRectangleProperty = DependencyProperty.Register(
            "SelectedRectangle",
            typeof(DiscSpace),
            typeof(DiscSpaceCanvasView),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );
    }
}
