using DFC.Common.Standard.Logging;
using Microsoft.Extensions.Logging;
using NCS.DSS.Collections.Cosmos.Provider;
using NSubstitute;

namespace NCC.DSS.Collections.Tests.Helpers
{
    public static class MockingHelper
    {        
        public static ILogger GetMockLogger()
        {
            return Substitute.For<ILogger>();            
        }        

        public static ILoggerHelper GetMockLoggerHelper()
        {
            return Substitute.For<ILoggerHelper>();            
        }

        public static IDocumentDBProvider GetMockDBProvider()
        {
            return Substitute.For<IDocumentDBProvider>();                        
        }
    }
}
