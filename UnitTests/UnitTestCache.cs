using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscUsage;
using System.Collections.Generic;
using System.Linq;
using DiscUsage.Model;

namespace UnitTests
{
    [TestClass]
    public class UnitTestCache
    {
        private string testDir = @"C:\Users\Oliver\source\repos\DiscUsage\UnitTests\Samples";

        [TestMethod]
        public void TestDirectoriesCached()
        {
            var discCache = new DiscCache();
            discCache.LoadAsync(testDir).Wait();
            var rootDriveCache = discCache.drivesCache[0];

            Assert.AreEqual(discCache.drivesCache.Count, 1,"number of root directories");
            Assert.AreEqual(rootDriveCache.directories.Count, 3, "number of first level directories");
            Assert.AreEqual(rootDriveCache.files.Count, 1, "number of first level files");
                            
            Assert.AreEqual(rootDriveCache.directories[0].directories.Count, 16, "number of directories in " + rootDriveCache.directories[0].Name);
            Assert.AreEqual(rootDriveCache.directories[1].directories.Count, 11, "number of directories in " + rootDriveCache.directories[1].Name);
            Assert.AreEqual(rootDriveCache.directories[2].directories.Count, 18, "number of directories in " + rootDriveCache.directories[2].Name);
        }

        [TestMethod]
        public void TestDirectoriesLoaded()
        {
            var discCache = new DiscCache();
            discCache.LoadAsync(testDir).Wait();
            var rootDriveCache = discCache.drivesCache[0];
            Assert.AreEqual(rootDriveCache.Length,                  40599922, "size of root directories");
            Assert.AreEqual(rootDriveCache.directories[0].Length,   16676785, "size of " + rootDriveCache.directories[0].Name);
            Assert.AreEqual(rootDriveCache.directories[1].Length,   1706954,  "size of " + rootDriveCache.directories[1].Name);
            Assert.AreEqual(rootDriveCache.directories[2].Length,   22211624, "size of " + rootDriveCache.directories[2].Name);
            Assert.AreEqual(rootDriveCache.files[0].Length,         4559,     "size of " + rootDriveCache.files[0].Name);
            Assert.AreEqual(40599922, 16676785 + 1706954 + 22211624+ 4559);
        }

        [TestMethod]
        public void TestDirectoriesLoadedEvents()
        {
            CreatedEvents.Clear();
            var discCache = new DiscCache();
            discCache.Created += DiscCache_Created;
            discCache.LoadAsync(testDir).Wait();
            discCache.Created -= DiscCache_Created;
            var rootDriveCache = discCache.drivesCache[0];
            Assert.AreEqual(CreatedEvents.Count, 4599);
            Assert.AreEqual(CreatedEvents.FindAll(x => x is FileCache).Sum(x => x.Length), rootDriveCache.Length);
        }

        private List<InfoCache> CreatedEvents = new List<InfoCache>();

        private void DiscCache_Created(InfoCache element)
        {
            CreatedEvents.Add(element);
            if (!element.IsRoot)
            {
                Assert.IsNotNull(element.Parent);
                if (element is DirectoryCache)
                {
                    Assert.IsTrue(((DirectoryCache)element.Parent).directories.Contains(element));
                }
                else
                {
                    Assert.IsTrue(((DirectoryCache)element.Parent).files.Contains(element));
                }
                
            }
        }
    }
}
