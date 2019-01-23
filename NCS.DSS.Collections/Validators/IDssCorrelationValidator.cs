using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace NCS.DSS.Collections.Validators
{
    public interface IDssCorrelationValidator
    {
        Guid Extract(HttpRequest req, ILogger logger);
    }
}
