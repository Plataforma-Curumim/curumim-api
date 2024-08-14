using curumim_api.Adapters.Inbound.Http.Models.Register.RegisterUser;
using curumim_api.Adapters.Outbound.SQL.Models;
using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Register;
using curumim_api.Application.Ports.Outbound.SQL.Repository.Register;
using System.Data.SqlClient;
using System.Text.Json;

namespace curumim_api.Application.UseCase.Register
{
    public class UseCaseRegisterUser(IRepositoryRegisterUser repository) : IUseCaseRegisterUser
    {
        private readonly IRepositoryRegisterUser _repository = repository;
        public //async
            BaseReturn<DomainModel> Register(DomainModel domainModel)
        {
            try
            {
                /*
                var responseRepository = await _repository.Register(domainModel);

                if (responseRepository.state != 0)
                {
                    var sqlError = JsonSerializer.Deserialize<SqlBaseError>(responseRepository.msgErro!);
                    var error = new BaseError(sqlError!);
                    return new BaseReturn<DomainModel>().Error(Enum.Parse<EnumState>(sqlError!.typeError!), error!);
                }
                */

                var msgOut = new ResponseRegisterUser
                {
                    idUser = "5d7409c2-3fee-4063-aea4-1985239bb1b3",
                    createAt = "2001/01/01 00:00:00Z",
                    state = "ATIVO",
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
