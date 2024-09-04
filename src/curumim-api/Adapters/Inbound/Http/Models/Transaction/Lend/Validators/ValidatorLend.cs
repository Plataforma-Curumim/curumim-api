using System.Validation;

namespace curumim_api.Adapters.Inbound.Http.Models.Transaction.Lend.Validators;

public class ValidatorLend: FlatValidator<RequestLend>
{
    public ValidatorLend()
    {
        ErrorIf(m => m.bookId is null, m => "Não pode ser nulo ou vazio", m => m.bookId);
        ErrorIf(m => m.userId is null, m => "Não pode ser nulo ou vazio", m => m.userId);
    }
}