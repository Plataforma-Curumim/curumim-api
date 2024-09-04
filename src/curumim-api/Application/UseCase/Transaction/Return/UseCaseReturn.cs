using System.Text.Json;
using curumim_api.Adapters.Inbound.Http.Models.Transaction.Return;
using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Transaction.Return;
using curumim_api.Application.Ports.Outbound.SQL.Repository;

namespace curumim_api.Application.UseCase.Transaction.Return;

public class UseCaseReturn(IRepositoryProcedure repository) : IUseCaseReturn
{
    private readonly IRepositoryProcedure _repository = repository;
    private readonly string _procedureName = Environment.GetEnvironmentVariable("PROCEDURE_RETURN")!;

    public //async
        BaseReturn<DomainModel> Return(DomainModel domainModel)
    {
        try
        {
            /*
            var responseRepository = await _repository.SendAsync(domainModel);

            if (responseRepository.state != 0)
            {
                var sqlError = JsonSerializer.Deserialize<SqlBaseError>(responseRepository.msgErro!);
                var error = new BaseError(sqlError!);
                return new BaseReturn<DomainModel>().Error(Enum.Parse<EnumState>(sqlError!.typeError!), error!);
            }
            */

            var msgOut = new ResponseReturn
            {
                dateReturn= DateTime.Now.ToString(),
                state = EnumStateTransaction.DONE.ToString(),
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