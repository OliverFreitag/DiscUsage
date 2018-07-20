using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using DiscUsage.Views;

namespace DiscUsage
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

    }
}
