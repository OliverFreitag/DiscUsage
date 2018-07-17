using System;
using DiscUsage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
            var discSpace = new DiscUsage.DiscSpace.DiscSpaceManager();
            discCache.Created += discSpace.Added;
            discCache.Load(testDir);
            Assert.AreEqual(discCache.drivesCache.Count, 1);
            Assert.AreEqual(discCache.drivesCache[0].Length, 40599922);
            Assert.AreEqual(discSpace.Mapping.Count, 37);
            Assert.IsTrue(discSpace.Mapping.Values.ToList()[0].Length>discSpace.MinimalLimit);
        }
    }
}
