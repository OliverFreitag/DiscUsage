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
        public Int64 ParentLength => cache.Parent.Length;
        public String Name => cache.Name;
        public String FullName => cache.FullName;
        public int Count => cache.Count;

        List<DiscSpace> Flatten(List<DiscSpace> e)
        {
            return e.Concat( e.SelectMany(c => Flatten(c.Children))).ToList();
        }

        public List<DiscSpace> ChildrenRecursive => Flatten(Children);

        public List<DiscSpace> OrderedChildren => Children.OrderByDescending( x=> x.Length).ToList();

        public int Level => (Parent == null) ? 0 : Parent.Level+1;
        public int IndexInParentOrderedCollection => (Parent == null) ? 0 : Parent.OrderedChildren.IndexOf(this);
            
        public long LengthOfAllPreviousChildren =>  Parent.OrderedChildren.Where(x => x.IndexInParentOrderedCollection<IndexInParentOrderedCollection)
            .Sum(x => x.Length);

    }
}
