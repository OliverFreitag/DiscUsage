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
    /// Interaktionslogik für DiscSpaceView.xaml
    /// </summary>
    public partial class DiscSpaceView : UserControl
    {

        DiscSpaceViewModel _vm;
        public DiscSpaceView()
        {
            InitializeComponent();
            _vm = (DiscSpaceViewModel)this.DataContext;
        }

        public ObservableCollection<DiscSpace> DiscSpaces
        {
            get { return (ObservableCollection<DiscSpace>)GetValue(DiscSpacesProperty); }
            set { SetValue(DiscSpacesProperty, value); }
        }

        public static readonly DependencyProperty DiscSpacesProperty =
            DependencyProperty.Register("DiscSpaces", typeof(ObservableCollection<DiscSpace>),
                typeof(DiscSpaceView), new PropertyMetadata(null, OnDiscSpacesSet));

        private static void OnDiscSpacesSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DiscSpaceView)d)._vm.SourceDiscSpaces = e.NewValue as ObservableCollection<DiscSpace>;
        }

    }
}
