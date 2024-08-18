using curumim_api.Application.Core.Enums;
using System.Validation;

namespace curumim_api.Adapters.Inbound.Http.Models.Management.Book.EditBook.Validators
{
    public class ValidatorEditBook : FlatValidator<RequestEditBook>
    {
        public ValidatorEditBook()
        {
            ErrorIf(m => m.idBook is null, m => "Não pode ser nulo ou vazio", m => m.idBook);
            ErrorIf(m => m.root is null, m => "Não pode ser nulo ou vazio", m => m.root);
            ErrorIf(m => !Enum.IsDefined(typeof(EnumTypeEdit), m.typeEdit), m => "Tipo de edição inválida", m => m.typeEdit);
            ErrorIf(m => !Enum.IsDefined(typeof(EnumStateBook), m.state), m => "Status de livro inválido", m => m.state);
            ErrorIf(m => m.root is null, m => "Não pode ser nulo ou vazio", m => m.root);
            If(m => m.root is not null, @then: m =>
            {
                ErrorIf(m => m.root!.UserRootId is null, m => "Não pode ser vazio", m => m.root!.UserRootId);
                ErrorIf(m => m.root!.libraryId is null, m => "Não pode ser vazio", m => m.root!.libraryId);
            });
        }
    }
}
