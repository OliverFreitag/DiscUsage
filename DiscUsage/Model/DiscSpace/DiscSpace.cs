using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.Model
{
    public class DiscSpace : BindableBase
    {
       // public InfoCache cache;

        //public List<DiscSpace> Children = new List<DiscSpace>();
     //   public DiscSpace Parent;

        public DiscSpaceManager Manager { get; private set; }
        public DiscSpace(DiscSpaceManager manager, DiscSpace parent, string name, string fullname)
        {
            this.Parent = parent;
            Name = name;
            FullName = fullname;
            //Level = level;
            Manager = manager;
            Children = new List<DiscSpace>();
        }

        public DiscSpace Parent { get; internal set; }
        public List<DiscSpace> Children { get; internal set; }
        public string Name { get; private set; }
        public string FullName { get; set; }
        public Int64 Length { get; internal set; }
        public Int64 LengthOfAllPreviousChildren { get; set; }
        //public int Level { get; internal set; }


       // public Int64 Length => cache.Length;
        public Int64 ParentLength => Parent.Length;
        //public String Name => cache.Name;
        //public String FullName => cache.FullName;
        public int Count { get; internal set; }

        List<DiscSpace> Flatten(List<DiscSpace> e)
        {
            return e.Concat( e.SelectMany(c => Flatten(c.Children))).ToList();
        }

        public List<DiscSpace> ChildrenRecursive => Flatten(Children);

        public List<DiscSpace> OrderedChildren => Children.OrderByDescending( x=> x.Length).ToList();

        public int Level => (Parent == null) ? 0 : Parent.Level + 1;
        public int IndexInParentOrderedCollection => (Parent == null) ? 0 : Parent.OrderedChildren.IndexOf(this);
            
        //public long LengthOfAllPreviousChildren =>  Parent.OrderedChildren.Where(x => x.IndexInParentOrderedCollection<IndexInParentOrderedCollection)
            //.Sum(x => x.Length);

    }
}
