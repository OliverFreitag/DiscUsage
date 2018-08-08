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

        public DiscSpaceManager Manager { get; private set; }
        public DiscSpace(DiscSpaceManager manager, DiscSpace parent, string name, string fullname)
        {
            this.Parent = parent;
            Name = name;
            FullName = fullname;
            Manager = manager;
            Children = new List<DiscSpace>();
            parent?.Children.Add(this);
            IsLoaded = false;
        }

        public DiscSpace Parent { get; internal set; }
        public List<DiscSpace> Children { get; internal set; }
        public string Name { get; private set; }
        public string FullName { get; set; }

        /// <summary>
        /// Length of all files and directories which are not part of the children space, 
        /// but belong into this disc space.
        /// </summary>
        public Int64 OwnLength { get; internal set; }

        public Int64 Length { get; internal set; }

        public Int64 ChildrenLength { get; internal set; }

        public bool IsLoaded { get; internal set; }

        public bool IsRoot => Parent==null || Manager.IsRoot(this);

        /// <summary>
        /// Length of this disc space, which is the sum of length of all files in all sub directories.
        /// </summary>
        public Int64 LengthSlow => IsLoaded ? OwnLength+ChildrenLength :  OwnLength + Children.Sum(x => x.Length);
        public Int64 LengthOfAllPreviousChildren => Parent.OrderedChildren.Where(x => x.IndexInParentOrderedCollection < IndexInParentOrderedCollection).Sum(x => x.Length);

        public Int64 ParentLength => IsRoot ? 0 : Parent.Length;
        public int Count { get; internal set; }

        List<DiscSpace> Flatten(List<DiscSpace> e)
        {
            return e.Concat( e.SelectMany(c => Flatten(c.Children))).ToList();
        }

        public List<DiscSpace> ChildrenRecursive => Flatten(Children).Where(x=>x.Length>= Manager.MinimalLimit).ToList();

        public List<DiscSpace> OrderedChildren { get; internal set; }

        public int Level => IsRoot ? 0 : Parent.Level + 1;
        public int IndexInParentOrderedCollection => IsRoot ? 0 : Parent.OrderedChildren.IndexOf(this);
        
    }
}
