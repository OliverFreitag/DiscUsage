using System;
using System.Linq;
using DiscUsage.Model;
using DiscUsage.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestDiscSpaceRectangle
    {
        private string testDir = @"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples";

        [TestMethod]
        public void TestMethodLoadAndParents()
        {
            var discCache = new DiscCache();
            var discSpace = new DiscSpaceManager();
            var discSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();
            discCache.Created += discSpace.Added;
            discSpace.Created += discSpaceCanvasViewModel.Add;
            discCache.Load(testDir);

            
            discSpaceCanvasViewModel.Loaded();
            foreach(var rectangle in discSpaceCanvasViewModel.DiscSpaceRectangles)
            {
                Assert.AreEqual(rectangle.Parent, discSpaceCanvasViewModel.Map(rectangle.space.Parent));
            }
            Assert.IsNotNull(discSpaceCanvasViewModel.Root);

            Assert.AreEqual(discSpaceCanvasViewModel.DiscSpaceRectangles.Where(x => x.Parent == discSpaceCanvasViewModel.Root).Count(), 3);

            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[0].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[1].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[2].Height, 600 - 6);

            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[0].X, 3);
            Assert.AreNotEqual(discSpaceCanvasViewModel.Root.Children[1].X, 3);
            Assert.AreNotEqual(discSpaceCanvasViewModel.Root.Children[2].X, 3);

            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[0].Y, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[1].Y, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[2].Y, 3);

            var first = discSpaceCanvasViewModel.Root.Children[0];
            Assert.AreEqual(first.Children.Count(), 2);
            Assert.AreEqual(first.Children[0].Width, first.Width-6);
            Assert.AreEqual(first.Children[1].Width, first.Width-6);

            Assert.AreEqual(first.Children[0].X, first.X+3);
            Assert.AreEqual(first.Children[1].X, first.X+3);

            Assert.AreEqual(first.Children[0].Y, first.Y+3);
            Assert.AreNotEqual(first.Children[1].Y, first.Y+3);

            var second = discSpaceCanvasViewModel.Root.Children[1];
            Assert.AreEqual(second.Children.Count(), 2);
            Assert.AreEqual(second.Children[0].Width, second.Width-6);
            Assert.AreEqual(second.Children[1].Width, second.Width-6);

            Assert.AreEqual(second.Children[0].Parent, second);
            Assert.AreEqual(second.Children[1].Parent, second);

            Assert.AreEqual(second.Children[0].X, second.X+3);
            Assert.AreEqual(second.Children[1].X, second.X+3);

            Assert.AreEqual(second.Children[0].Y, second.Y+3);
            Assert.AreNotEqual(second.Children[1].Y, second.Y+3);
        }

        private void disc(DiscSpace space)
        {
            throw new NotImplementedException();
        }
    }
}
