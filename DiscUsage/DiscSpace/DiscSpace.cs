using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.DiscSpace
{
    public class DiscSpace
    {
        private InfoCache cache;
       
        public List<DiscSpace> Children = new List<DiscSpace>();
        public DiscSpace Parent;

        public DiscSpace(InfoCache cache)
        {
            this.cache = cache;
        }

        public Int64 Length => cache.Length;
    }
}
