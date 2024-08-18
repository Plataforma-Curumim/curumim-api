using curumim_api.Adapters.Inbound.Http.Models.Management.Book.RegisterBook;
using System.Validation;

namespace curumim_api.Adapters.Inbound.Http.Models.Management.Book.RegisterBook.Validators
{
    public class ValidatorRegisterBook : FlatValidator<RequestRegisterBook>
    {
        public ValidatorRegisterBook()
        {
            ErrorIf(m => m.title is null, m => "Não pode ser nulo ou vazio", m => m.title);
            ErrorIf(m => m.isbn is null, m => "Não pode ser nulo ou vazio", m => m.isbn);
            ErrorIf(m => m.author is null, m => "Não pode ser nulo ou vazio", m => m.author);
            ErrorIf(m => m.sinopse is null, m => "Não pode ser nulo ou vazio", m => m.sinopse);
            ErrorIf(m => m.gender is null, m => "Não pode ser nulo ou vazio", m => m.gender);
            ErrorIf(m => m.publishers is null || !m.publishers.Any(), m => "Não pode ser nulo ou vazio", m => m.publishers);
            ErrorIf(m => m.numberOfPages is null || m.numberOfPages < 1, m => "Não pode ser nulo ou menor que 1", m => m.numberOfPages);

            ErrorIf(m => m.root is null, m => "Não pode ser nulo ou vazio", m => m.root);
            If(m => m.root is not null, @then: m =>
            {
                ErrorIf(m => m.root!.UserRootId is null, m => "Não pode ser vazio", m => m.root!.UserRootId);
                ErrorIf(m => m.root!.libraryId is null, m => "Não pode ser vazio", m => m.root!.libraryId);
            });
        }
    }
}
