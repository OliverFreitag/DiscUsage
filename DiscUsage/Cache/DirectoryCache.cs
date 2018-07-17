using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiscUsage
{
    public class DirectoryCache : InfoCache
    {
        public DirectoryInfo directoryInfo;
        public List<DirectoryCache> directories = new List<DirectoryCache>();
        public List<FileCache> files = new List<FileCache>();
        private InfoCache parent;

        public DirectoryCache(DirectoryInfo directoryInfo, InfoCache parent)
        {
            this.directoryInfo = directoryInfo;
            this.parent = parent;
        }

        public long Length => directories.Sum(x => x.Length) + files.Sum(x => x.Length);

        public string Name => directoryInfo.Name;

        public InfoCache Parent
        {
            get
            {
                return parent;
            }
        }

        public bool IsRoot => directoryInfo.Parent == null;
    }
}
