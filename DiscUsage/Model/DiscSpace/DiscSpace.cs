using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.Model
{
    public class DiscSpace
    {
        public InfoCache cache;
       
        public List<DiscSpace> Children = new List<DiscSpace>();
        public DiscSpace Parent;

        public DiscSpace(InfoCache cache, DiscSpace parent)
        {
            this.cache = cache;
            this.Parent = parent;
        }

        public Int64 Length => cache.Length;
        public String Name => cache.Name;
        public int Count => cache.Count;

        public List<DiscSpace> OrderedChildren => Children.OrderByDescending( x=> x.Length).ToList();
    }
}
