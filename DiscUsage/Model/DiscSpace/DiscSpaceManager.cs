using DiscUsage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DiscUsage.Model
{
    public delegate void DiscSpaceDelegate(DiscSpace space);

    public class DiscSpaceManager
    {
        public event DiscSpaceDelegate Created;
        public event DiscSpaceDelegate Updated;
        public event DiscSpaceDelegate Loaded;

        public DiscSpace Root;
        private Dictionary<IInfoCache, DiscSpace> mapping = new Dictionary<IInfoCache, DiscSpace>();
        public Int64 MinimalLimit = 1024 * 1024;

        private static DiscSpace CreateDiscSpace(DiscSpaceManager manager, DiscSpace parent, String name, String fullname)
        {
            return new DiscSpaceRectangle(manager, parent, name, fullname);
        }

        public void Load(IInfoCache info)
        {
            var space = Map(info);
            Update(info, space);

            space.IsLoaded = true;
            if (info is DirectoryCache)
            {
                var smallChildren = space.Children.Where(x => x.Length < MinimalLimit).ToList();
                smallChildren.ForEach(x=>mapping.Remove(MapBack(x)));
                space.OwnLength = smallChildren.Sum(x => x.Length);
                space.Children = space.Children.Where(x => x.Length >= MinimalLimit).ToList();
                
                space.ChildrenLength = space.Children.Sum(x => x.Length);
            }

            if (space.Length >= MinimalLimit)
            {
                RaiseCreatedForArgumentAndAllParentsIfNotAlreadyRaised(space);
                Loaded?.Invoke(space);
            }
        }

        private void Update(DiscSpace space)
        {
            Update(MapBack(space),space);
        }

        private void Update(IInfoCache info, DiscSpace space)
        {
            space.Count = info.Count;          
        }

        private void UpdateCurrentAndAllParents(DiscSpace current)
        {
            Update(current);
            Updated?.Invoke(current);
            if (current.Parent != null)
            {
                UpdateCurrentAndAllParents(current.Parent);
            }
        }

        private void UpdateAll()
        {
            foreach(var keyValuePair in mapping)
            {
                Update(keyValuePair.Key, keyValuePair.Value);
            }
        }

        /// <summary>
        /// A new cache info is added to the disc space manager. 
        /// This results in a new disc space, if a new info is given ans the info is not under the minimal limit.
        /// The manager updates all the parent disc spaces.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="forceCreation"> if this parameter is set to true, the mimimal limit is virtually set to 0.</param>
        public void Create(IInfoCache info)
        {
            var parentSpace = Map(info.Parent);
            var space = CreateDiscSpace(this, parentSpace, info.Name, info.FullName);
            mapping[info] = space;
            if (info is FileCache)
            {
                space.OwnLength = info.Length;
                space.Length = space.OwnLength;
                AddLengthToAllParents(parentSpace, space.OwnLength);
            }

            if (info.Parent == null)
            {
                Root = space;
            }

            if (space.Length >= MinimalLimit)
            {
                RaiseCreatedForArgumentAndAllParentsIfNotAlreadyRaised(space);                
            }

        }

        private void AddLengthToAllParents(DiscSpace space, long length)
        {
            if (space == null)
            {
                return;
            }
            space.OrderedChildren= space.Children.OrderByDescending(x => x.Length).Where(x => x.Length >= space.Manager.MinimalLimit).ToList();
            space.Length += length;
            if (!IsRoot(space))
            {
                AddLengthToAllParents(space.Parent, length);
            }
            
        }

        private List<DiscSpace> CreatedAlreadyRaised = new List<DiscSpace>();

        public bool IsRoot(DiscSpace space)
        {
            return space.Parent==null || space==Root;
        }

        private void RaiseCreatedForArgumentAndAllParentsIfNotAlreadyRaised(DiscSpace space)
        {
            var parent = space.Parent;
            if (!IsRoot(space))
            {
                RaiseCreatedForArgumentAndAllParentsIfNotAlreadyRaised(parent); ;
            }
            
            if (!CreatedAlreadyRaised.Contains(space))
            {
                CreatedAlreadyRaised.Add(space);
                Created?.Invoke(space);
            }
           
        }

        public Dictionary<IInfoCache, DiscSpace> Mapping => mapping;
        public DiscSpace Map(IInfoCache info)
        {
            if (info == null||!mapping.ContainsKey(info))
            {
                return null;
            }
            return mapping[info];
        }

        public IInfoCache MapBack(DiscSpace space)
        {
            if (!mapping.ContainsValue(space))
            {
                return null;
            }
            return mapping.FirstOrDefault(x => x.Value == space).Key;
        }

        public List<DiscSpace> OrderedByLevel
        {
            get
            {
                var orderedByLevel = Root.ChildrenRecursive.ToList();
                orderedByLevel.Add(Root);
                orderedByLevel = orderedByLevel.OrderBy(x => x.Level).ToList();
                return orderedByLevel;
            }
        }
    }
}
