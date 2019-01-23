using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.SysIntTests.Singletons
{
    public sealed class AzureSearchSingleton
    {
        private static readonly Lazy<AzureSearchSingleton> lazy =
        new Lazy<AzureSearchSingleton>(() => new AzureSearchSingleton());

        public static AzureSearchSingleton Instance { get { return lazy.Value; } }

        private AzureSearchSingleton()
        {
        }
        /* static readonly Lazy<AzureSearchSingleton> lazy = new Lazy<AzureSearchSingleton>(() => new AzureSearchSingleton());
         private AzureSearchSingleton() { }

         public static AzureSearchSingleton Instance => lazy.Value;
         */
        private bool dataSetupExecuted = false;

        public bool DataSetupExecuted
        {
            get { return this.dataSetupExecuted; }
            set { this.dataSetupExecuted = value; }
        }

    }
}
