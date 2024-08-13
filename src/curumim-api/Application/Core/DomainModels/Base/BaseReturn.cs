using curumim_api.Application.Core.Enums;

namespace curumim_api.Application.Core.DomainModels.Base
{
    public struct BaseReturn<TSuccess>
    {
        public EnumState Status { get; set; }
        public TSuccess? SucessObject { get; set; }
        public BaseError? ErrorObject { get; set; }

        public BaseReturn()
        {
            Status = EnumState.SUCCESS;
            SucessObject = default;
            ErrorObject = null;
        }

        public BaseReturn<TSuccess> Success(TSuccess success)
        {
            Status = EnumState.SUCCESS;
            SucessObject = success;

            return this;
        }

        public BaseReturn<TSuccess> Error(EnumState status, BaseError error)
        {
            Status = status;
            ErrorObject = error;

            return this;
        }

    }
}
