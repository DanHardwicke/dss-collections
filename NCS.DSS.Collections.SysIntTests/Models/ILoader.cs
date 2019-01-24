using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.SysIntTests.Models
{
    interface ILoader
    {
        string LoaderRef { get; set; }
        string CustomerId { get; set; }
    }
}
