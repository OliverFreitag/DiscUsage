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
        public FileInfo file;

        public FileCache(FileInfo file, InfoCache parent)
        {
            this.file = file;
            this.parent = parent;
        }

        public long Length => file.Length;

        public string Name => file.Name;
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

        public string FullName => file.FullName;
    }
}
