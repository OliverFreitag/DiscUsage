using System;
using System.Collections.Generic;
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
            //var discSpace = new DiscSpaceManager();
            var discSpaceCanvasViewModel = new DiscSpaceCanvasViewModel();

            discCache.Created += discSpaceCanvasViewModel.Manager.Create;
            discCache.Loaded += discSpaceCanvasViewModel.Manager.Load;

            //discSpaceCanvasViewModel.Manager.Created += discSpaceCanvasViewModel.Add;
            //discSpaceCanvasViewModel.Manager.Updated += discSpaceCanvasViewModel.Update;
            discSpaceCanvasViewModel.Manager.Created += discSpaceCanvasViewModel.Loaded;
            discSpaceCanvasViewModel.Manager.Created += Manager_Created;

            discCache.LoadAsync(testDir).Wait();

            //  discSpaceCanvasViewModel.Loaded(null);

            foreach (var rectangle in discSpaceCanvasViewModel.DiscSpaceRectangles)
            {
                //var space = discSpaceCanvasViewModel.Manager.MapBack(rectangle);
                //var info = discSpaceCanvasViewModel.Manager.MapBack(space);
                //Assert.AreEqual(rectangle.Parent, rectangle.ManagerRectangle.Map(rectangle.Manager.Map(info.Parent)));
                Assert.IsNotNull(rectangle.ManagerRectangle);
            }

            Assert.IsNotNull(discSpaceCanvasViewModel.Root);

            Assert.AreEqual(discSpaceCanvasViewModel.DiscSpaceRectangles.Where(x => x.Parent == discSpaceCanvasViewModel.Root).Count(), 3);

            Assert.AreEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle.Count, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[0].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[1].Height, 600 - 6);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[2].Height, 600 - 6);

            //Assert.AreEqual(discSpaceCanvasViewModel.Root.Children[2].Width + discSpaceCanvasViewModel.Root.Children[2].X, 600 - 6);

            //Assert.AreEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[0].X, 3);
            //Assert.AreNotEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[1].X, 3);
            //Assert.AreNotEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[2].X, 3);

            Assert.AreEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[0].Y, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[1].Y, 3);
            Assert.AreEqual(discSpaceCanvasViewModel.Root.ChildrenRectangle[2].Y, 3);

            var first = discSpaceCanvasViewModel.Root.ChildrenRectangle[0];
            Assert.AreEqual(first.Children.Count(), 2);
            Assert.AreEqual(first.ChildrenRectangle[0].Width, first.Width-6);
            Assert.AreEqual(first.ChildrenRectangle[1].Width, first.Width-6);

            Assert.AreEqual(first.ChildrenRectangle[0].X, first.X+3);
            Assert.AreEqual(first.ChildrenRectangle[1].X, first.X+3);

            Assert.AreEqual(first.ChildrenRectangle[0].Y, first.Y+3);
            Assert.AreNotEqual(first.ChildrenRectangle[1].Y, first.Y+3);

            var second = discSpaceCanvasViewModel.Root.ChildrenRectangle[1];
            Assert.AreEqual(second.Children.Count(), 2);
            Assert.AreEqual(second.ChildrenRectangle[0].Width, second.Width-6);
            Assert.AreEqual(second.ChildrenRectangle[1].Width, second.Width-6);

            Assert.AreEqual(second.ChildrenRectangle[0].Parent, second);
            Assert.AreEqual(second.ChildrenRectangle[1].Parent, second);

            Assert.AreEqual(second.ChildrenRectangle[0].X, second.X+3);
            Assert.AreEqual(second.ChildrenRectangle[1].X, second.X+3);

            Assert.AreEqual(second.ChildrenRectangle[0].Y, second.Y+3);
            Assert.AreNotEqual(second.ChildrenRectangle[1].Y, second.Y+3);

            Assert.AreEqual(CreatedEvents.Count, discSpaceCanvasViewModel.DiscSpaceRectangles.Count);
        }

        private List<DiscSpaceRectangle> CreatedEvents = new List<DiscSpaceRectangle>();

        private void Manager_Created(DiscSpace space)
        {
            CreatedEvents.Add((DiscSpaceRectangle)space);
        }
    }
}
