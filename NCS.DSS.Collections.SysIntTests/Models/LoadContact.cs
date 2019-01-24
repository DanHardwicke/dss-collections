using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.SysIntTests.Models
{
    class LoadContact : Contact, ILoader
    {
        public string LoaderRef { get; set; }
    }
}
