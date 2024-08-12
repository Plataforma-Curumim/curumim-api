using curumim_api.Adapters.Inbound.Http.Dto.RegisterBook;
using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases;
using System.Text.Json;

namespace curumim_api.Application.UseCase
{
    public class UseCaseRegisterBook : IUseCaseRegisterBook
    {
        public BaseReturn<DomainModel> Register(DomainModel domainModel)
        {
            try
            {
                var msgOut = new ResponseRegisterBook
                {
                    idBook = "c1318e10-4a0a-4f81-bc47-e16ee81a4a6d",
                    createAt = "2024/02/12 00:00:00Z",
                    state = 0,
                };
                domainModel.msgOUT = JsonSerializer.Serialize(msgOut);

                return new BaseReturn<DomainModel>().Success(domainModel);
            } 
            
            catch (Exception ex) 
            {
                var error = new BaseError("500", ex.Message);
                return new BaseReturn<DomainModel>().Error(EnumState.SYSTEM, error);
            }
        }
    }
}
