using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Flags]
    internal enum SecurityPrivilage:byte
    {
        Guest=1,
        Developer=2,
        Secertary=4,
        DBA=8,
    }
}
