using curumim_api.Adapters.Inbound.Http.Models.Management.User.RegisterUser;
using curumim_api.Application.Core.Enums;
using System.Validation;

namespace curumim_api.Adapters.Inbound.Http.Models.Management.User.RegisterUser.Validators
{
    public class ValidatorRegisterUser : FlatValidator<RequestRegisterUser>
    {
        public ValidatorRegisterUser()
        {
            ErrorIf(m => m.root is null, m => "Não pode ser nulo ou vazio", m => m.root);
            If(m => m.root is not null, @then: m =>
            {
                ErrorIf(m => m.root!.UserRootId is null, m => "Não pode ser vazio", m => m.root!.UserRootId);
                ErrorIf(m => m.root!.libraryId is null, m => "Não pode ser vazio", m => m.root!.libraryId);
            });

            ErrorIf(m => m.name is null, m => "Não pode ser nulo ou vazio", m => m.name);
            ErrorIf(m => m.cpfCnpj is null, m => "Não pode ser nulo ou vazio", m => m.cpfCnpj);
            ErrorIf(m => m.email is null, m => "Não pode ser nulo ou vazio", m => m.email);
            ErrorIf(m => m.username is null, m => "Não pode ser nulo ou vazio", m => m.username);
            ErrorIf(m => m.password is null, m => "Não pode ser nulo ou vazio", m => m.password);
            ErrorIf(m => m.dateOfBirth == default, m => "Não pode ser nulo ou vazio", m => m.dateOfBirth);
            ErrorIf(m => m.numberPhone is null, m => "Não pode ser nulo ou vazio", m => m.numberPhone);
            ErrorIf(m => m.address is null, m => "Não pode ser nulo ou vazio", m => m.address);
            ErrorIf(m => !Enum.IsDefined(typeof(EnumTypeUser), m.typeUser), m => "Tipo de usuario inválido", m => m.typeUser);

        }
    }
}
