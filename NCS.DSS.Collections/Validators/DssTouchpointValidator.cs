using DFC.Common.Standard.Logging;
using DFC.HTTP.Standard;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace NCS.DSS.Collections.Validators
{
    public class DssTouchpointValidator : IDssTouchpointValidator
    {
        private readonly IHttpRequestHelper _httpRequestHelper;
        private readonly ILoggerHelper _loggerHelper;
        private readonly IDssCorrelationValidator _correlationValidator;
        public DssTouchpointValidator(IHttpRequestHelper httpRequestHelper, ILoggerHelper loggerHelper, IDssCorrelationValidator correlationValidator)
        {
            _httpRequestHelper = httpRequestHelper;
            _loggerHelper = loggerHelper;
            _correlationValidator = correlationValidator;
        }
        public string Extract(HttpRequest req, ILogger logger)
        {
            var touchpointId = _httpRequestHelper.GetDssTouchpointId(req);

            if (string.IsNullOrEmpty(touchpointId))
            {
                _loggerHelper.LogInformationMessage(logger, _correlationValidator.Extract(req, logger), "Unable to locate 'TouchpointId' in request header.");
                return null;
            }

            return touchpointId;
        }
    }
}
