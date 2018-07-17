using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.DiscSpace
{
    public class DiscSpaceManager
    {
        public DiscSpace Root;
        private Dictionary<InfoCache, DiscSpace> mapping = new Dictionary<InfoCache, DiscSpace>();
        public Int64 MinimalLimit = 1024 * 1024;

        public void Added(InfoCache info)
        {
            if (info.Length<MinimalLimit)
            {
                return;
            }
            var space = new DiscSpace(info);
            mapping[info] = space;
        }

        public Dictionary<InfoCache, DiscSpace> Mapping => mapping;
    }
}
