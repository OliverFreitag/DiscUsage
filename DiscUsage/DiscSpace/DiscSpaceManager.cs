using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.DiscSpace
{
    public delegate void DiscSpaceDelegate(DiscSpace space);

    public class DiscSpaceManager
    {
        public event DiscSpaceDelegate Created;
        public DiscSpace Root;
        private Dictionary<InfoCache, DiscSpace> mapping = new Dictionary<InfoCache, DiscSpace>();
        public Int64 MinimalLimit = 1024 * 1024;

        public void Added(InfoCache info)
        {
            Added(info, false);
        }

        public void Added(InfoCache info, bool forceCreation=false)
        {
            if (info.Length<MinimalLimit && !forceCreation)
            {
                return;
            }
            if (Map(info) != null)
            {
                return;
            }
            DiscSpace parentSpace=null;
            if (info.Parent!=null)
            {
                parentSpace = Map(info.Parent);
                if (parentSpace==null)
                {
                    Added(info.Parent,true);
                    parentSpace = Map(info.Parent);
                }
            }
            var space = new DiscSpace(info, parentSpace);
            mapping[info] = space;
            if (parentSpace!=null)
            {
                parentSpace.Children.Add(space);
            }

            Created?.Invoke(space);
        }

        public Dictionary<InfoCache, DiscSpace> Mapping => mapping;
        public DiscSpace Map(InfoCache info)
        {
            if (!mapping.ContainsKey(info))
            {
                return null;
            }
            return mapping[info];
        }
    }
}
