﻿using curumim_api.Adapters.Inbound.Http.Models.Management.Book.RegisterBook;
using curumim_api.Application.Core.DomainModels;
using curumim_api.Application.Core.DomainModels.Base;
using curumim_api.Application.Core.Enums;
using curumim_api.Application.Ports.Inbound.UseCases.Management.Book;
using curumim_api.Application.Ports.Outbound.SQL.Repository;
using System.Text.Json;

namespace curumim_api.Application.UseCase.Management.Book
{
    public class UseCaseRegisterBook(IRepositoryProcedure repository) : IUseCaseRegisterBook
    {
        private readonly IRepositoryProcedure _repository = repository;
        private readonly string _procedureName = Environment.GetEnvironmentVariable("PROCEDURE_REGISTER_BOOK")!;

        public //async
            BaseReturn<DomainModel> Register(DomainModel domainModel)
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

                var msgOut = new ResponseRegisterBook
                {
                    idBook = Guid.NewGuid().ToString(),
                    createAt = DateTime.Now.ToString(),
                    state = EnumStateBook.AVAILABLE.ToString(),
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
