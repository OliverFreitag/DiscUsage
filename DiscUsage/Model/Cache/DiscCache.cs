using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Timers;

namespace DiscUsage.Model
{
    public delegate void DiscCacheDelegate(IInfoCache element);
    public class DiscCache
    {
        public List<DirectoryCache> drivesCache = new List<DirectoryCache>();

        public event DiscCacheDelegate Created;
        public event DiscCacheDelegate Loaded;
        public event DiscCacheDelegate Timer;

        public DiscCache()
        {
        }
        private SynchronizationContext _uiContext; 
        public async Task LoadAsync(string directory)
        {
            _uiContext = SynchronizationContext.Current;

            await Task.Run(() =>
                Load(directory, null));

        }

        private void Load(string directory, DirectoryCache parent)
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

        private void RaiseCreatedEvent(IInfoCache cache)
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

        private void RaiseLoadedEvent(IInfoCache cache)
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

        private DirectoryCache Load(DirectoryCache parent,DirectoryInfo directory)
        {
            var directoryCache = new DirectoryCache(directory, parent);
            RaiseCreatedEvent(directoryCache);

            //todo: deal with exceptions
            try
            {
                var subDirectories = directory.GetDirectories();
                foreach (var subDirectory in subDirectories)
                {
                    var subDirectoryCache = Load(directoryCache, subDirectory);
                }
                var files = directory.GetFiles();
                foreach (var file in files)
                {
                    var fileCache = Load(file, directoryCache);
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                // handle exception
                //throw;
            }


            RaiseLoadedEvent(directoryCache);

            return directoryCache;
        }

        private FileCache Load(FileInfo file, DirectoryCache parent)
        {
            var fileCache = new FileCache(file,parent);
            RaiseCreatedEvent(fileCache);
            RaiseLoadedEvent(fileCache);
            return fileCache;
        }

        private System.Timers.Timer _Timer;

        public bool IsTimerEnabled
        {
            get
            {
                return _Timer != null;
            }
            set
            {
                if (value)
                {
                    if (_Timer == null)
                    {
                        _Timer = new System.Timers.Timer(1000);
                        _Timer.Elapsed += _Timer_Elapsed;
                        _Timer.Start();
                    }
                }
                else
                {
                    if (_Timer != null)
                    {
                        _Timer.Stop();
                        _Timer = null;
                        _Timer_Elapsed(null, null);
                    }
                }
            }
        }

        private void _Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Timer.Invoke(null);
        }
    }
}
