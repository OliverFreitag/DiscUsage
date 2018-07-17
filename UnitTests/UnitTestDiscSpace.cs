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
        private string testDir = @"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples";

        [TestMethod]
        public void TestAdded()
        {
            var discCache = new DiscCache();
            var discSpace = new DiscSpaceManager();
            discCache.Created += discSpace.Added;
            discCache.Load(testDir);
            Assert.AreEqual(discCache.drivesCache.Count, 1);
            Assert.AreEqual(discCache.drivesCache[0].Length, 40599922);
            Assert.AreEqual(discSpace.Mapping.Count, 38);
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
            discCache.Created += discSpace.Added;
            discSpace.Created += DiscSpace_Created;
            discCache.Load(testDir);
            discCache.Created -= discSpace.Added;
            discSpace.Created -= DiscSpace_Created;
            Assert.AreEqual(discCache.drivesCache.Count, 1);
            Assert.AreEqual(discCache.drivesCache[0].Length, 40599922);
            Assert.AreEqual(discSpace.Mapping.Count, 38);
            Assert.IsTrue(discSpace.Mapping.Values.ToList()[0].Length > discSpace.MinimalLimit);

            Assert.AreEqual(new HashSet<DiscSpace>(CreatedDiscSpaces).Count, CreatedDiscSpaces.Count);
            var diffSet = new HashSet<DiscSpace>(CreatedDiscSpaces).Where(x => !discSpace.Mapping.Values.Contains(x));
            Assert.AreEqual(diffSet.Count(), 0);
            foreach(var diff in CreatedDiscSpaces)
            {
                Assert.IsNotNull(discSpace.Map(diff.cache));
            }
            var cache=CreatedDiscSpaces.ConvertAll(x => x.cache);
            Assert.AreEqual(new HashSet<InfoCache>(cache).Count, cache.Count);
            Assert.AreEqual(CreatedDiscSpaces.Count, discSpace.Mapping.Count);
        }

        private void DiscSpace_Created(DiscSpace space)
        {
            CreatedDiscSpaces.Add(space);
           // CreatedDiscSpaces.Add(space);
            if (space.cache.Parent!=null)
            {
                Assert.IsNotNull(space.Parent);
                Assert.IsTrue(space.Parent.Children.Contains(space));
            }

            Assert.AreSame(space, discSpaceManager.Map(space.cache));
        }
    }
}
