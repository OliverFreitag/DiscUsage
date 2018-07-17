using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiscUsage
{
    public delegate void DiscCacheDelegate(InfoCache element);
    public class DiscCache
    {
        public List<DirectoryCache> drivesCache = new List<DirectoryCache>();

        public event DiscCacheDelegate Created;
        public event DiscCacheDelegate Loaded;

        public DiscCache()
        {
        }

        public void Load(string directory)
        {
            Load(directory,null);
        }

        public void Load(string directory, InfoCache parent)
        {
            var info = new DirectoryInfo(directory);
            drivesCache.Add(Load(parent,info));
        }

        public void Load()
        {
            var drives = DriveInfo.GetDrives();
            foreach(var drive in drives)
            {
                var directoryCache=Load(null,drive.RootDirectory);
                drivesCache.Add(directoryCache);
            }
            
        }

        private DirectoryCache Load(InfoCache parent,DirectoryInfo directory)
        {
            var directoryCache = new DirectoryCache(directory, parent);
            directoryCache.directoryInfo = directory;
            var subDirectories = directory.GetDirectories();
            foreach (var subDirectory in subDirectories)
            {
                var subDirectoryCache=Load(directoryCache, subDirectory);
                directoryCache.directories.Add(subDirectoryCache);
                Created?.Invoke(subDirectoryCache);
            }
            var files = directory.GetFiles();
            foreach (var file in files)
            {
                var fileCache = Load(file,directoryCache);
                directoryCache.files.Add(fileCache);
                Created?.Invoke(fileCache);
            }
            if (parent == null)
            {
                Loaded?.Invoke(null);
            }
            return directoryCache;
        }

        private FileCache Load(FileInfo file, DirectoryCache parent)
        {
            var fileCache = new FileCache(file,parent);
            fileCache.file = file;
         //   fileCache.Length = file.Length;
            return fileCache;
        }
    }
}
