using curumim_api.Adapters.Inbound.Http.Models.Management.User.GetUser;
using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.User;
using curumim_api.Application.Ports.Outbound.SQL.Repository;
using System.Text.Json;

namespace curumim_api.Application.UseCase.Management.User
{
    public class UseCaseGetUser(IRepositoryProcedure repository) : IUseCaseGetUser
    {
        public //async
           BaseReturn<DomainModel> Get(DomainModel domainModel)
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

                var msgOut = new ResponseGetUser
                {
                    name = "Heloise Marcela Campos",
                    cpfCnpj = "78928534488",
                    email = "heloise.marcela.campos@endoimplantes.com.br",
                    username = "helocela",
                    password = "hyBAHwgU19",
                    dateOfBirth = "01/03/2004",
                    numberPhone = "91994109636",
                    address = "Rua São Cristovão",
                    idRfid = Guid.NewGuid().ToString(),
                    typeUser = EnumTypeUser.READER.ToString(),

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
