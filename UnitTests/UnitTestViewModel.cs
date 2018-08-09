using System;
using DiscUsage.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestViewModel
    {
        [TestMethod]
        public void TestLoad()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.RootDirectory);
            mainWindowViewModel.LoadCommand.Execute();
            Assert.AreEqual(mainWindowViewModel.RootDirectory, @"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples");
            
            mainWindowViewModel.Wait();
            Assert.AreEqual(mainWindowViewModel.IsLoaded, true);
            Assert.AreEqual(mainWindowViewModel.IsLoading, false);
        }
        
        [TestMethod]
        public void TestLoadAndSetVisibleRoot()
        {
            var mainWindowViewModel = new MainWindowViewModel();
            Assert.IsNotNull(mainWindowViewModel.RootDirectory);
            mainWindowViewModel.LoadCommand.Execute();
            Assert.AreEqual(mainWindowViewModel.RootDirectory, @"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples");
            
            mainWindowViewModel.Wait();
            Assert.AreEqual(mainWindowViewModel.IsLoaded, true);
            Assert.AreEqual(mainWindowViewModel.IsLoading, false);

            Assert.AreEqual(mainWindowViewModel.DiscSpaces.Count, 0);
            Assert.AreEqual(mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRectangles.Count, 31);
            Assert.AreEqual(mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRoot, mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRectangles[0]);

            mainWindowViewModel.DiscSpaceCanvasViewModel.SelectedRectangle = (DiscSpaceRectangle)mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0];
            Assert.AreEqual(mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRoot,mainWindowViewModel.DiscSpaceCanvasViewModel.SelectedRectangle);

            mainWindowViewModel.DiscSpaceCanvasViewModel.SelectedRectangle = (DiscSpaceRectangle)mainWindowViewModel.DiscSpaceCanvasViewModel.Manager.Root;
            Assert.AreEqual(mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRoot, mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRectangles[0]);

            mainWindowViewModel.DiscSpaceCanvasViewModel.SelectedRectangle = (DiscSpaceRectangle)mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRoot.OrderedChildren[0];
            Assert.AreEqual(mainWindowViewModel.DiscSpaceCanvasViewModel.VisibleRoot, mainWindowViewModel.DiscSpaceCanvasViewModel.SelectedRectangle);

        }

    }
}
