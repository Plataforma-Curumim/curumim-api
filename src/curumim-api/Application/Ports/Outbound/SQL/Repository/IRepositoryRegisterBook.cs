﻿using curumim_api.Application.Core.DomainModels;

namespace curumim_api.Application.Ports.Outbound.SQL.Repository
{
    public interface IRepositoryRegisterBook
    {
        public Task<DomainModel> Register(DomainModel domainModel);
    }
}
