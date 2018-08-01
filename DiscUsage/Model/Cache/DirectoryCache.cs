using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiscUsage.Model
{
    public class DirectoryCache : InfoCache
    {
        public DirectoryInfo Info { get; private set; }
        public List<DirectoryCache> directories = new List<DirectoryCache>();
        public List<FileCache> files = new List<FileCache>();
        private InfoCache parent;

        public DirectoryCache(DirectoryInfo directoryInfo, InfoCache parent)
        {
            this.Info = directoryInfo;
            this.parent = parent;
        }

        public long Length => directories.Sum(x => x.Length) + files.Sum(x => x.Length);

        public string Name => Info.Name;

        public InfoCache Parent
        {
            get
            {
                return parent;
            }
        }

        public bool IsRoot => Info.Parent == null;

        public int Count => directories.Count + files.Count;

        public int CountRecursive => 1 + files.Count + directories.Sum(x => x.CountRecursive);

        public string FullName => Info.FullName;
    }
}
