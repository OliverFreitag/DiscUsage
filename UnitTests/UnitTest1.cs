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
            Assert.AreEqual(mainWindowViewModel.IsLoading, true);
            mainWindowViewModel.Wait();
            Assert.AreEqual(mainWindowViewModel.IsLoaded, true);
        }

    }
}
