using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.SysIntTests.Models
{
    class Loader
    {
        public Loader( string loaderRef, string customerId)
        {
            LoaderReference = loaderRef;
            CustomerID = customerId;
        }

        public string LoaderReference { get; set; }
        public string CustomerID { get; set; }
    }
}
