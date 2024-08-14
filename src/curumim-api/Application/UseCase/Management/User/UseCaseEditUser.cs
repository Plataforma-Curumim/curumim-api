using curumim_api.Adapters.Inbound.Http.Models.Management.User.EditUser;
using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.User;
using curumim_api.Application.Ports.Outbound.SQL.Repository;
using System.Text.Json;

namespace curumim_api.Application.UseCase.Management.User
{
    public class UseCaseEditUser(IRepositoryProcedure repository) : IUseCaseEditUser
    {
        private readonly IRepositoryProcedure _repository = repository;
        private readonly string _procedureName = Environment.GetEnvironmentVariable("PROCEDURE_EDIT_USER")!;

        public //async
            BaseReturn<DomainModel> Edit(DomainModel domainModel)
        {
            try
            {
                /*
                var responseRepository = await _repository.SendAsync(domainModel, _procedureName);

                if (responseRepository.state != 0)
                {
                    var sqlError = JsonSerializer.Deserialize<SqlBaseError>(responseRepository.msgErro!);
                    var error = new BaseError(sqlError!);
                    return new BaseReturn<DomainModel>().Error(Enum.Parse<EnumState>(sqlError!.typeError!), error!);
                }
                */

                var msgOut = new ResponseEditUser
                {
                    modifiedAt= "2001/01/01 00:00:00Z",
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
