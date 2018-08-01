using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace DiscUsage.Model
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
        private SynchronizationContext _uiContext; 
        public async Task LoadAsync(string directory)
        {
            _uiContext = SynchronizationContext.Current;
            //Load(directory, null);
            await Task.Run(() =>
                Load(directory, null));

            //task.Wait();
        }

        private void Load(string directory, InfoCache parent)
        {
            var info = new DirectoryInfo(directory);
            drivesCache.Add(Load(parent,info));
        }

        public void Load()
        {
            _uiContext = SynchronizationContext.Current;
            var drives = DriveInfo.GetDrives();
            foreach(var drive in drives)
            {
                var directoryCache=Load(null,drive.RootDirectory);
                drivesCache.Add(directoryCache);
            }
            
        }

        private void RaiseCreatedEvent(InfoCache cache)
        {
            if (_uiContext == null)
            {
                Created?.Invoke(cache);
            }
            else
            {
                _uiContext.Send(x => Created?.Invoke(cache), null);
            }
        }

        private void RaiseLoadedEvent(InfoCache cache)
        {
            if (_uiContext == null)
            {
                Loaded?.Invoke(cache);
            }
            else
            {
                _uiContext.Send(x => Loaded?.Invoke(cache), null);
            }
        }

        private DirectoryCache Load(InfoCache parent,DirectoryInfo directory)
        {
            var directoryCache = new DirectoryCache(directory, parent);
            RaiseCreatedEvent(directoryCache);
            //directoryCache.directoryInfo = directory; 
            //todo: deal with exceptions
            var subDirectories = directory.GetDirectories();
            foreach (var subDirectory in subDirectories)
            {
                var subDirectoryCache=Load(directoryCache, subDirectory);
                directoryCache.directories.Add(subDirectoryCache);
                         
            }
            var files = directory.GetFiles();
            foreach (var file in files)
            {
                var fileCache = Load(file,directoryCache);
                directoryCache.files.Add(fileCache);
                RaiseCreatedEvent(fileCache);
            }
            //if (parent == null)
            //{
                RaiseLoadedEvent(parent);
            //}
            return directoryCache;
        }

        private FileCache Load(FileInfo file, DirectoryCache parent)
        {
            var fileCache = new FileCache(file,parent);
            //fileCache.file = file;
            RaiseCreatedEvent(fileCache);
            RaiseLoadedEvent(fileCache);
            //   fileCache.Length = file.Length;
            return fileCache;
        }
    }
}
