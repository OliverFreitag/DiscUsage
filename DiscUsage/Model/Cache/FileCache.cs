using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DiscUsage.Model
{
    public class FileCache : InfoCache
    {
        public FileInfo Info { get; private set; }

        public FileCache(FileInfo file, InfoCache parent)
        {
            this.Info = file;
            this.parent = parent;
        }

        public long Length => Info.Length;

        public string Name => Info.Name;
        public InfoCache parent;
        public InfoCache Parent
        {
            get
            {
                return parent;
            }
        }

        public bool IsRoot => false;

        public int Count => 1;

        public string FullName => Info.FullName;
    }
}
