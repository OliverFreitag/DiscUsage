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
        private Dictionary<InfoCache, DiscSpace> mapping = new Dictionary<InfoCache, DiscSpace>();
        public Int64 MinimalLimit = 1024 * 1024;

        public void Added(InfoCache info)
        {
           Added(info, false);
        }

        public void Load(InfoCache info)
        {
            Loaded?.Invoke(Map(info));
        }

        private void Update(DiscSpace space)
        {
            Update(MapBack(space),space);
        }

        private void Update(InfoCache info, DiscSpace space)
        {
            //var space = Map(info);
            //space.Level= (space.Parent == null) ? 0 : space.Parent.Level + 1;
            space.Count = info.Count;
            space.Length = info.Length;
            //if (info is DirectoryCache)
            //{
            //    var directory = (DirectoryCache)info;
            //    space.Children = directory.directories.ConvertAll(x => Map(x)).FindAll(x=>x!=null);
            //}

            if (space.Parent != null)
            {
                space.LengthOfAllPreviousChildren = space.Parent.OrderedChildren.Where(x => x.IndexInParentOrderedCollection < space.IndexInParentOrderedCollection).Sum(x => x.Length);
            }
           
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
        public void Added(InfoCache info, bool forceCreation = false)
        {
            if (info.Length < MinimalLimit && !forceCreation)
            {
                return;
            }
            if (Map(info) != null)
            {
                UpdateAll();
                return;
            }
            DiscSpace parentSpace = null;
            if (info.Parent != null)
            {
                parentSpace = Map(info.Parent);
                if (parentSpace == null)
                {
                    Added(info.Parent, true);
                    parentSpace = Map(info.Parent);
                }
                else
                {
                    UpdateCurrentAndAllParents(parentSpace);
                }
            }
            var space = new DiscSpace(this,parentSpace,info.Name, info.FullName);
            
            mapping[info] = space;
            Update(info,space);
            if (parentSpace != null)
            {
                parentSpace.Children.Add(space);
            }
            if (space.Parent == null)
            {
                Root = space;
            }

            Created?.Invoke(space);
            UpdateAll();
        }

        public Dictionary<InfoCache, DiscSpace> Mapping => mapping;
        public DiscSpace Map(InfoCache info)
        {
            if (info == null||!mapping.ContainsKey(info))
            {
                return null;
            }
            return mapping[info];
        }

        public InfoCache MapBack(DiscSpace space)
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
