using curumim_api.Application.Core.DomainModels;
using System.Text.Json;

namespace curumim_api.Adapters.Inbound.Http.Mappers.Shared
{
    public static class MapperShared<T>
    {
        public static DomainModel MapToDomain(T obj, string idempotenceKey)
        {
            return new DomainModel
            {
                idempotenceKey = idempotenceKey,
                msgIN = JsonSerializer.Serialize(obj)
            };
        }
    }
}
