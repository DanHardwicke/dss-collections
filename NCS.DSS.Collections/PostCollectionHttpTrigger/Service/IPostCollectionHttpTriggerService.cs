using NCS.DSS.Collections.Models;
using System.Threading.Tasks;

namespace NCS.DSS.Collections.PostCollectionHttpTrigger.Service
{
    public interface IPostCollectionHttpTriggerService
    {
        Task<Collection> ProcessRequestAsync(Collection collection);
    }
}
