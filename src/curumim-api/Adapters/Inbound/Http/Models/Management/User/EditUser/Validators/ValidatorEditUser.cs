﻿using curumim_api.Application.Core.DomainModels.Entities;
using curumim_api.Application.Core.Enums;
using System.Validation;

namespace curumim_api.Adapters.Inbound.Http.Models.Management.User.EditUser.Validators
{
    public class ValidatorEditUser : FlatValidator<RequestEditUser>
    {
        public ValidatorEditUser()
        {
            ErrorIf(m => m.userId is null, m => "Não pode ser nulo ou vazio", m => m.userId);
            ErrorIf(m => !Enum.IsDefined(typeof(EnumTypeEdit), m.typeEdit), m => "Tipo de edição inválida", m => m.typeEdit);
            ErrorIf(m => m.root is null, m => "Não pode ser nulo ou vazio", m => m.root);
            If(m => m.root is not null, @then: m =>
            {
                ErrorIf(m => m.root!.UserRootId is null, m => "Não pode ser vazio", m => m.root!.UserRootId);
                ErrorIf(m => m.root!.libraryId is null, m => "Não pode ser vazio", m => m.root!.libraryId);
            });


        }
    }
}
