using NCS.DSS.Collections.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.GetCollectionsHttpTrigger.Service
{
    public interface IGetCollectionsHttpTriggerService
    {
        Task<List<Collection>> ProcessRequestAsync(Guid touchpointId);
    }
}
