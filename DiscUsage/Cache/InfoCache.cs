using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscUsage
{
    public interface InfoCache
    {
        Int64 Length { get; }
        string Name { get; }
        InfoCache Parent { get; }
        bool IsRoot { get; }
    }
}
