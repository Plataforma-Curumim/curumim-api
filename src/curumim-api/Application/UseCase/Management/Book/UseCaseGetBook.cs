using curumim_api.Adapters.Inbound.Http.Models.Management.Book.GetBook;
using curumim_api.Adapters.Inbound.Http.Models.Management.Book.RegisterBook;
using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.Book;
using curumim_api.Application.Ports.Outbound.SQL.Repository;
using System.Text.Json;

namespace curumim_api.Application.UseCase.Management.Book
{
    public class UseCaseGetBook(IRepositoryProcedure repository) : IUseCaseGetBook
    {
        private readonly IRepositoryProcedure _repository = repository;
        private readonly string _procedureName = Environment.GetEnvironmentVariable("PROCEDURE_GET_BOOK")!;

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

                var msgOut = new ResponseGetBook
                {
                    state = EnumStateBook.AVAILABLE.ToString(),
                    idBook = Guid.NewGuid().ToString(),
                    isbn = "978-8532523051",
                    title = "Harry Potter e a Pedra Filosofal: 1",
                    subtitle = null,
                    author = "J. K. Rowling",
                    sinopse = "Harry Potter é um garoto órfão que vive infeliz com seus tios, os Dursleys. Ele recebe uma carta contendo um convite para ingressar em Hogwarts, uma famosa escola especializada em formar jovens bruxos. Inicialmente, Harry é impedido de ler a carta por seu tio, mas logo recebe a visita de Hagrid, o guarda-caça de Hogwarts, que chega para levá-lo até a escola. Harry adentra um mundo mágico que jamais imaginara, vivendo diversas aventuras com seus novos amigos, Rony Weasley e Hermione Granger.",
                    gender = "fantasia e ficção",
                    language = "inglês",
                    urlImage = "https://upload.wikimedia.org/wikipedia/pt/thumb/c/c1/Capa_HP1.jpg/230px-Capa_HP1.jpg",
                    publishers = null,
                    publishDate = "1º de setembro de 1998",
                    physicalDimensions = null,
                    publishPlaces = null,
                    numberOfPages = 309,
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
