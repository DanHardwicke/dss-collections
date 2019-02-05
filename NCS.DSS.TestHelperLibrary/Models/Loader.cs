using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  NCS.DSS.TestHelperLibrary.Models
{
    class Loader
    {
        //public Loader()
        //{
        //    ParentId = "1";
        //}
        //public Loader( string loaderRef), string customerId)
        //{
        //    LoaderReference = loaderRef;
        // //   CustomerID = customerId;
        //  //  ParentIds = new OrderedDictionary();
        //}

        public string LoaderReference { get; set; }
       // public string CustomerID { get; set; }
      //  public OrderedDictionary ParentIds;

        public string ParentType { get; set; }
        public string ParentId { get; set; }
        public List<FamilyTreeItem> AllParents = new List<FamilyTreeItem>();
      //  public int order { get; set; }


    }
}
