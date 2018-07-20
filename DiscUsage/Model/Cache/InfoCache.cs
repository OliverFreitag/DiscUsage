using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage.Model
{
    public interface InfoCache
    {
        Int64 Length { get; }
        int Count { get; }
        string Name { get; }
        string FullName { get; }
        InfoCache Parent { get; }
        bool IsRoot { get; }
    }
}
