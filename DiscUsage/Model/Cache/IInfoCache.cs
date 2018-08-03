using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.Model
{
    public interface IInfoCache
    {
        Int64 Length { get; }
        int Count { get; }
        string Name { get; }
        string FullName { get; }
        IInfoCache Parent { get; }
        bool IsRoot { get; }
    }
}
