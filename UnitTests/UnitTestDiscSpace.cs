using System;
using DiscUsage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DiscUsage.Model;

namespace UnitTests
{
    [TestClass]
    public class UnitTestDiscSpace
    {
        private readonly string testDir = @"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples";

        [TestMethod]
        public void TestAdded()
        {
            var discCache = new DiscCache();
            var discSpace = new DiscSpaceManager();
            discCache.Created += discSpace.Create;
            discCache.Loaded += discSpace.Load;

            discCache.LoadAsync(testDir).Wait();
            Assert.AreEqual(discCache.drivesCache.Count, 1);
            Assert.AreEqual(discCache.drivesCache[0].Length, 40599922);
            Assert.AreEqual(discSpace.OrderedByLevel.Count, 38);
            Assert.IsTrue(discSpace.Mapping.Values.ToList()[0].Length>discSpace.MinimalLimit);
        }

        private List<DiscSpace> CreatedDiscSpaces = new List<DiscSpace>();
        private DiscSpaceManager discSpaceManager = null;

        [TestMethod]
        public void TestAddedEvents()
        {
            CreatedDiscSpaces.Clear();
            var discCache = new DiscCache();
            var discSpace = new DiscSpaceManager();
            discSpaceManager = discSpace;
            discCache.Created += discSpace.Create;
            discCache.Loaded += discSpace.Load;

            discSpace.Created += DiscSpace_Created;

            discCache.LoadAsync(testDir).Wait();

            discCache.Created -= discSpace.Create;
            discSpace.Created -= DiscSpace_Created;

            Assert.AreEqual(discCache.drivesCache.Count, 1);
            Assert.AreEqual(discCache.drivesCache[0].Length, 40599922);
            Assert.AreEqual(discSpace.OrderedByLevel.Count, 38);
            Assert.IsTrue(discSpace.Mapping.Values.ToList()[0].Length > discSpace.MinimalLimit);

            Assert.AreEqual(new HashSet<DiscSpace>(CreatedDiscSpaces).Count, CreatedDiscSpaces.Count);
            var diffSet = new HashSet<DiscSpace>(CreatedDiscSpaces).Where(x => !discSpace.Mapping.Values.Contains(x));
            Assert.AreEqual(diffSet.Count(), 0);
            var list = discSpace.OrderedByLevel;
            list.Reverse();
            foreach (var space in list)
            {
                var info=discSpace.MapBack(space);
                Assert.AreEqual(info.Name, space.Name);
                if (info is DirectoryCache)
                {
                    var directory = (DirectoryCache)info;
                    Assert.AreEqual(directory.Count, info.Count);
                }
                
                Assert.AreEqual(info.Length, space.Length);
            }

            var cache=CreatedDiscSpaces.ConvertAll(x => discSpace.MapBack(x));
            Assert.AreEqual(new HashSet<InfoCache>(cache).Count, cache.Count);
            //Assert.AreEqual(CreatedDiscSpaces.Count, discSpace.OrderedByLevel.Count);
            var missing = discSpace.OrderedByLevel.Where(x => !CreatedDiscSpaces.Contains(x));
            Assert.AreEqual(missing.Count(), 0);
        }

        private void DiscSpace_Created(DiscSpace space)
        {
            CreatedDiscSpaces.Add(space);

            if (space.Manager.MapBack(space).Parent!=null)
            {
                Assert.IsNotNull(space.Parent);
                Assert.IsTrue(space.Parent.Children.Contains(space));
            }

            //Assert.AreSame(space, discSpaceManager.Map(space.cache));
        }

        [TestMethod]
        public void TestRecursive()
        {
            var discCache = new DiscCache();
            var discSpace = new DiscSpaceManager();

            discCache.Created += discSpace.Create;
            discCache.Loaded += discSpace.Load;

            discCache.LoadAsync(testDir).Wait();

            Assert.AreEqual(discCache.drivesCache.Count, 1);
            Assert.AreEqual(discCache.drivesCache[0].Length, 40599922);

            Assert.AreEqual(discSpace.Mapping.Values.Sum(x=>x.OwnLength), 40599922);

            Assert.AreEqual(discSpace.OrderedByLevel.Count, 38);
           // Assert.AreEqual(discSpace.Root.ChildrenRecursive.Count, discSpace.Mapping.Count-1);

            Assert.AreEqual(discSpace.Root.Level, 0);
            Assert.AreEqual(discSpace.Root.Children.Count, 3);

            Assert.AreEqual(discSpace.Root.Children[0].Level, 1);
            Assert.AreEqual(discSpace.Root.Children[1].Level, 1);
            Assert.AreEqual(discSpace.Root.Children[2].Level, 1);

            Assert.AreEqual(discSpace.Root.Length, 40599922);

            Assert.AreEqual(discSpace.Root.OrderedChildren[0].ChildrenRecursive.Count, 19);
            Assert.AreEqual(discSpace.Root.OrderedChildren[1].ChildrenRecursive.Count, 15);
            Assert.AreEqual(discSpace.Root.OrderedChildren[2].ChildrenRecursive.Count, 0);

            Assert.AreEqual(discSpace.Root.OrderedChildren[0].Count, 18);
            Assert.AreEqual(discSpace.Root.OrderedChildren[1].Count, 16);
            Assert.AreEqual(discSpace.Root.OrderedChildren[2].Count, 11);

            Assert.AreEqual(discSpace.Root.OrderedChildren[0].Length, 22211624);
            Assert.AreEqual(discSpace.Root.OrderedChildren[1].Length, 16676785);
            Assert.AreEqual(discSpace.Root.OrderedChildren[2].Length, 1706954);

            Assert.AreEqual(discSpace.Root.OrderedChildren[0].LengthOfAllPreviousChildren, 0);
            Assert.AreEqual(discSpace.Root.OrderedChildren[1].LengthOfAllPreviousChildren, 22211624);
            Assert.AreEqual(discSpace.Root.OrderedChildren[2].LengthOfAllPreviousChildren, 22211624 + 16676785);

            Assert.AreEqual(discSpace.Root.OrderedChildren[0].Children.Count, 2);
            Assert.AreEqual(discSpace.Root.OrderedChildren[0].Children[0].Level, 2);
            Assert.AreEqual(discSpace.Root.OrderedChildren[0].Children[1].Level, 2);

        }
    }
}
